import socket
from struct import Struct

packer1 = Struct("10s 6s 20s")
packer2 = Struct("10s 100s")

server_addr = ('oktnb147.inf.elte.hu', 11224 )
	
with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as server:
	server.connect(server_addr)
	server.send(packer1.pack(b"TCPKliens",b"dvzcbt", b"7y5eu2vfxp3iwtd5"))
	print("Data sent.")

	ackData = server.recv(packer2.size)

	mess = packer2.unpack(ackData)[1].decode()
	print(mess)

	server.send(("".join([mess[2], mess[3], mess[5]])).encode())

	ackData = server.recv(packer2.size)

	mess = packer2.unpack(ackData)[1].decode()
	print(mess)