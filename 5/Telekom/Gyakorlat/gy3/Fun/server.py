from socket import socket, AF_INET, SOCK_STREAM

sock = socket(AF_INET, SOCK_STREAM)
addr = ('127.0.0.1', 8000)

sock.bind(addr)
sock.listen(0)

while (True):
	(conn_sock, conn_addr) = sock.accept()
	with conn_sock as c:
		# Receiving data
		print(f'Connected user: {conn_addr}')
		data = conn_sock.recv(1024)
		print(data.decode(), end = '')