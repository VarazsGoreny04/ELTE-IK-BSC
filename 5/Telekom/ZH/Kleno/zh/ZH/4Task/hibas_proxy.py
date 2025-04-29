from socket import socket, AF_INET, SOCK_STREAM, SOCK_DGRAM
import select
import struct

server_addr = ('', 10000)
server_addr2 = ('', 11000)

packer = struct.Struct("3s 5s")
packer_resp = struct.Struct("6s i")

cache = {}

def addCache(p,re):
	global cache
	for k in cache:
		cache[k]['idx'] +=1
	cache[p] = {'idx':1,'data':re}
	cache = {k:cache[k] for k in cache if cache[k]['idx']<=5}

with socket(AF_INET, SOCK_STREAM) as proxy, socket(AF_INET, SOCK_DGRAM) as pclient:
	proxy.bind(server_addr)
	proxy.listen(1)
	pclient.settimeout(1.0)
	rlist = [proxy]

	
	while True:
		r, w, e = select.select(rlist, rlist, rlist, 1)
		
		if not (r or w or e):
			continue
			
		for s in r:
			if s is proxy:
				client, client_addr = s.accept()
				client.settimeout(1.0)
				rlist.append(client)
			else:
				data = s.recv(packer.size)
				#print(data.decode())
				if not data:
					rlist.remove(s)
					s.close()
				else:
					m,p = packer.unpack(data)
					print(m)
					print(p)
					
					if m == b"GET":
						#if not p in cache:
						#	pclient.sendto(data, server_addr2)
						#	resp_data, _ = pclient.recvfrom(packer_resp.size)
						#	re = packer_resp.unpack(resp_data)
						#	addCache(re,p)
						#resp_data = packer_resp.pack(*cache[p]['data'], p)
						resp_data = packer_resp.pack(b'asdfgg', 12)
					elif m == b"CLR":
						cache = {}
						resp_data = packer_resp.pack(b"OK",0)
					elif m == b"RFS":
						for p in sorted(cache.items(), key=lambda x:x[1]['idx'], reverse=True):
							data = packer.pack(b"GET",p[0])
							pclient.sendall(data,server_addr2)
							resp_data, _ = pclient.recvfrom(packer_resp.size)
							re = packer_resp.unpack(resp_data)[0]
							addCache(p[0],re)
						resp_data = packer_resp.pack(b"OK",0)
					client.sendall(resp_data)