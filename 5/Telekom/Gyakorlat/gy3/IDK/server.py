from socket import socket, AF_INET, SOCK_STREAM
import struct

packer = struct.Struct("ici")

sock = socket(AF_INET, SOCK_STREAM)
addr = ('127.0.0.1', 8000)

sock.bind(addr)
sock.listen(0)

(conn_sock, conn_addr) = sock.accept()
with conn_sock as c:
	# Receiving data
	print(f'Connected user: {conn_addr}')
	data = conn_sock.recv(16)
	(a, op, b) = packer.unpack(data)
	print(a, op, b, sep = ", ")

	# Sending result
	result = eval(str(a) + op.decode() + str(b))
	conn_sock.send(str(result).encode())