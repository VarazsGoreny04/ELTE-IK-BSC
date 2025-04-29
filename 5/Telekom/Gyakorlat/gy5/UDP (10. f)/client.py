import socket

with socket.socket(socket.AF_INET, socket.SOCK_DGRAM) as sock:
	addr = ("127.0.0.1", 8000)
		
	sock.sendto(b"Hello Server!", addr)
	(ackData,ackAddr) = sock.recvfrom(20)
	print(ackData.decode())