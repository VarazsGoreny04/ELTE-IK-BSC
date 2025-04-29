import socket
import select

proxy_addr = ('127.0.0.1', 8000)

with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as proxy:
    proxy.bind(proxy_addr)
    proxy.listen(1)
    print("Listening for new connections...")

    inputs = [proxy]
    timeout = 1
    
    try:
        while True:
            readable, writeable, exceptional = select.select(inputs, inputs, inputs, timeout)
            
            if not (readable or writeable or exceptional):
                continue
            
            for sock in readable:
                if sock is proxy: # new connection
                    client, client_addr = sock.accept()
                    inputs.append(client)
                    print("Connected: ", client_addr)
                else: # an existing connection is readable
                    data = sock.recv(16)
                    if not data:
                        print("Logout: ", sock)
                        inputs.remove(sock)
                        sock.close()
                    else:
                        with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as server:
                            server.connect(("127.0.0.1", 9000))
                            server.send(data)
                            ack = server.recv(16)
                            sock.send(ack)
    except KeyboardInterrupt:
        print("Closing the server...")