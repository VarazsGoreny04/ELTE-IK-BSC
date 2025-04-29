import sys
import socket
import struct

udpAddr = ('127.0.0.1', 8000)
recivedAddr = ()
    
with socket.socket(socket.AF_INET, socket.SOCK_DGRAM) as sock:
	packer = struct.Struct("9si")
	sock.sendto("GET".encode(), udpAddr)
	(tcpAddr, addr) = sock.recvfrom(1024)
    
	recivedAddr = packer.unpack(tcpAddr)
	print(recivedAddr[0].decode(), recivedAddr[1])

with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as sock:
	packer = struct.Struct("fcf")
	sock.connect(recivedAddr)


	sock.send(packer.pack(float(sys.argv[1]), sys.argv[2].encode(), float(sys.argv[3])))
	print(sock.recv(16).decode())