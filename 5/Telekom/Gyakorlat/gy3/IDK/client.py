from socket import socket, AF_INET, SOCK_STREAM
import struct

packer = struct.Struct("ici")
values = (3, b'+', 4)
data = packer.pack(*values)

# Creating socket
sock = socket(AF_INET, SOCK_STREAM)
addr = ('127.0.0.1', 8000)

sock.connect(addr)

# Sending data
sock.send(data)

data = sock.recv(16)
print(data.decode())

sock.close()