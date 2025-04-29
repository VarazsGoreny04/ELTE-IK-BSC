from socket import socket, AF_INET, SOCK_STREAM
import sys

# Port
port = int(sys.argv[1])

sock = socket(AF_INET, SOCK_STREAM)
addr = ('127.0.0.1', 8000)

sock.connect(addr)

# Sending data
sock.send('Hello server!'.encode())

# Receiving response
data = sock.recv(16)
print(data.decode())

sock.close()
