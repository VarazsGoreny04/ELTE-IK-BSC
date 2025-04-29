from socket import socket, AF_INET, SOCK_STREAM

# Creating socket
sock = socket(AF_INET, SOCK_STREAM)
addr = ('127.0.0.1', 8000)

sock.connect(addr)

# Sending data
sock.send('Szia '.encode())
sock.send('Trefi'.encode())
sock.send('!\n'.encode())
sock.send('Répa, retek, mogyoró,\n'.encode())
sock.send('Korán reggel ritkán rikkant a rigó!\n'.encode())
sock.send('\n'.encode())

sock.close()