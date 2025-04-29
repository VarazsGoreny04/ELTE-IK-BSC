import socket

with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as sock:
    addr = ("127.0.0.1", 8000)
    sock.connect(addr)
    sock.send("Hello".encode())
    ack = sock.recv(16)
    print(ack.decode())