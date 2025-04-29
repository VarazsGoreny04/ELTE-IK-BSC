from socket import socket, AF_INET, SOCK_STREAM, SOL_SOCKET, SO_REUSEADDR
from struct import Struct
from select import select

server_addr = ('localhost', 12000)

packer1 = Struct('20s i ?')
packer2 = Struct('10s')


with socket(AF_INET, SOCK_STREAM) as server:
    server.bind(server_addr)
    server.listen(1)
    print("Listening for new connections...")

    inputs = [server]
    timeout = 1
    
    try:
        while True:
            readable, writeable, exceptional = select(inputs, inputs, inputs, timeout)
            
            if not (readable or writeable or exceptional):
                continue
            
            for sock in readable:
                if sock is server: # new connection
                    client, client_addr = sock.accept()
                    inputs.append(client)
                    print("Connected: ", client_addr)
                else: # an existing connection is readable
                    data = sock.recv(packer1.size)
                    if not data:
                        #print("Logout: ", sock)
                        inputs.remove(sock)
                        sock.close()
                    else:
                        data = packer1.unpack(data)

                        print(data[0])
                        print(data[2])
                        
                        if data[2]:
                            print(data[0][:data[1]])
                            part = data[0][:data[1]]
                        else:
                            print((-data[1]))
                            print(data[0][-data[1]:])
                            part = data[0][-data[1]:]
                        
                        sock.send(packer2.pack(part))
    except KeyboardInterrupt:
        print("Closing the server...")