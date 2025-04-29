import socket
from struct import Struct

packer1 = Struct("10s 6s 20s")
packer2 = Struct("10s 100s")

server_addr = ('oktnb147.inf.elte.hu', 11235)
	
with socket.socket(socket.AF_INET, socket.SOCK_DGRAM) as server:
	server.sendto(packer1.pack(b"UDPKliens",b"dvzcbt", b"wigco10yuk5dc0p9"), server_addr)
	print("Data sent.")

	(ackData,ackAddr) = server.recvfrom(packer2.size)

	mess = packer2.unpack(ackData)[1].decode()
	print(mess)

	server.sendto(("".join([mess[1], mess[5], mess[9]])).encode(), server_addr)

	(ackData,ackAddr) = server.recvfrom(packer2.size)

	mess = packer2.unpack(ackData)[1].decode()
	print(mess)