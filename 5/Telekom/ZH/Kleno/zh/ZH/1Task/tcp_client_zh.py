from socket import socket, AF_INET, SOCK_STREAM, timeout, SOL_SOCKET, SO_REUSEADDR
import sys
import struct
from math import floor

TCP_IP = 'localhost'
TCP_PORT = 10000

server_addr = (TCP_IP, TCP_PORT)
packer = struct.Struct('6s i')
packer2 = struct.Struct('i 3s')

with socket(AF_INET, SOCK_STREAM) as client:
    client.connect(server_addr)
    data = packer.pack(b'h9mrbv', 643)
    client.send(data)

    resp = client.recv(20).decode()
    print(resp)
    data = packer2.pack(643, bytes(str(resp[:3]), encoding='utf-8'))
    client.send(data)

    print(client.recv(20))
