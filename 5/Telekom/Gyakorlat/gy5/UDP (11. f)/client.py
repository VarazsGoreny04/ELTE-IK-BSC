import socket
from struct import Struct

packer = Struct("ici")

with socket.socket(socket.AF_INET, socket.SOCK_DGRAM) as sock:
	addr = ("127.0.0.1", 8000)

	sock.sendto(packer.pack(9, b"+", 10), addr)
	(ackData,ackAddr) = sock.recvfrom(8)
	print(ackData.decode())