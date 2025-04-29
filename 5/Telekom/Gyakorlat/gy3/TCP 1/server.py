from socket import socket, AF_INET, SOCK_STREAM
import sys

try:
	#Handle port number
	if (len(sys.argv) < 1):
		print('Not enough parameter')
		exit(1)
	port = int(sys.argv[1])

	sock = socket(AF_INET, SOCK_STREAM)
	addr = ('127.0.0.1', port)

	sock.bind(addr)
	sock.listen(0)

	(conn_sock, conn_addr) = sock.accept()
	with conn_sock as c:
		# Receiving data
		print(f'Connected user: {conn_addr}')
		data = conn_sock.recv(16)
		print(data.decode())

		# Sending response
		conn_sock.send('Hello client!'.encode())
except:
	print('Error')
finally:
	sock.close()