from socket import socket, AF_INET, SOCK_STREAM, timeout, SOL_SOCKET, SO_REUSEADDR
import sys
import struct
from select import select

TCP_IP = 'localhost'
TCP_PORT = 12000

server_addr = (TCP_IP, TCP_PORT)
packer = struct.Struct('20s i ?')
packer2 = struct.Struct('10s')

with socket(AF_INET, SOCK_STREAM) as server:
    server.bind(server_addr)
    server.listen(1)
    server.setsockopt(SOL_SOCKET, SO_REUSEADDR, 1)

    sockets = [server]

    while True:
        r,w,e = select(sockets, [], [], 1)

        if not (r or w or e):
            continue

        for s in r:
            if s is server:
                #Client connenction
                client, client_addr = s.accept()
                sockets.append(client)

            else:
                data = s.recv(packer.size)
                if not data:
                    sockets.remove(s)
                    s.close()

                else:
                    data = packer.unpack(data)
                    
                    if data[2]:
                        part = data[0][:data[1]]
                    else:
                        part = data[0][:-data[1]]
                    
                    s.send(packer2.pack(part))