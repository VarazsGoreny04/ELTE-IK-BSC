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
                    get_request = sock.recv(65000)
                    if not get_request:
                        print("Logout: ", sock)
                        inputs.remove(sock)
                        sock.close()
                    else:
                        with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as server:
                            school_addr = ("people.inf.elte.hu", 80)
                            server.connect(school_addr)
                            
                            # Creating URL
                            request = str(get_request.decode()).replace("GET /", "GET /pgm6rw/telkom").replace("localhost:8000", f"{school_addr[0]}:{school_addr[1]}")
                            print(request)
                            
                            # Send request
                            server.send(request.encode())
                            
                            # Send back to client
                            html = server.recv(65000)
                            sock.send(html)
    except KeyboardInterrupt:
        print("Closing the server...")