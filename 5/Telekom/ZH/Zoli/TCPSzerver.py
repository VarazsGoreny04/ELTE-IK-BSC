# Írj egy TCP servert, amely a következőket tudja megvalósítani:
# -A szerver localhoston és 12000 porton induljon el
# - selecttel, több klienst ki tud szolgálni
# - A klienstől kapsz egy karaktersorozatot (20s) egy számot (i) és egy logiaki értéket (?).
# - Ha a logikai érték igaz akkor kapott üzenet elejére vedd a számnyi karaktert, ha hamis akkor végéről
# - Az így kapott üzenetet küldd vissza a kliensnek (10s)
# Töltsd le a testClientObf.py -t.
# A testClientObf.py-t a következő paramtérrel indíts el: xbyob9y6a5i9cae3ngmb


from socket import socket,AF_INET, SOCK_STREAM, timeout, SOL_SOCKET, SO_REUSEADDR
import struct
from select import select

server_addr = ('localhost', 12000)
unpacker = struct.Struct('20s i ?')
response = struct.Struct("10s")

with socket(AF_INET, SOCK_STREAM) as server:
	server.bind(server_addr)
	server.listen(1)
	server.setsockopt(SOL_SOCKET, SO_REUSEADDR, 1)
	
	socketek = [ server ]
	
	while True:
		r,w,e = select(socketek,[],[],1)
		
		if not (r or w or e):
			continue
		
		for s in r:
			if s is server:
				# kliens csatlakozik
				client, client_addr = s.accept()
				socketek.append(client)
				# print("Csatlakozott",client_addr)
			else:
				data = s.recv(unpacker.size)
				# ha 0 byte akkor kilepett a kliens
				if not data:
					socketek.remove(s)
					s.close()
					print("Kilepett")
				else:
					karaktersor, szam, logikai = unpacker.unpack(data)
					
					print("karaktersor:",karaktersor)
					print("szam: ", szam)
					print("logiaki", logikai)
					characters = karaktersor.decode()
					valasz = ""
					if logikai:
						valasz = characters[0:szam]
					else:
						length = len(characters)
						valasz = characters[length - szam:]
					print(valasz)
					v = response.pack(str(valasz).encode())
					s.sendall(v)