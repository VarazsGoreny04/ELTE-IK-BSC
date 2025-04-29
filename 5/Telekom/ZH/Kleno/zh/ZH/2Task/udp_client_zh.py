from socket import socket, AF_INET, SOCK_STREAM, timeout, SOL_SOCKET, SO_REUSEADDR, SOCK_DGRAM
import sys
import struct
from math import floor

TCP_IP = 'localhost'
TCP_PORT = 10000

server_addr = (TCP_IP, TCP_PORT)
packer = struct.Struct('6s i')
packer2 = struct.Struct('i 3s')

with socket(AF_INET, SOCK_DGRAM) as client:
    #client.connect(server_addr)
    data = packer.pack(b'h9mrbv', 532)
    client.sendto(data, server_addr)

    resp = client.recvfrom(20)[0].decode()
    print(resp)
    data = packer2.pack(532, bytes(''.join([resp[3], resp[7], resp[1]]), encoding='utf-8'))
    client.sendto(data, server_addr)

    print(client.recvfrom(20))