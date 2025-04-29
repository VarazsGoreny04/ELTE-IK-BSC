import socket
import time

with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as sock:
	addr = ("127.0.0.1", 8000)
	sock.connect(addr)
	msg = b"Hello server!"

	for i in range(0, 5):
		time.sleep(2)
		sock.send(msg)
		print(f"Message sent: {msg}")

		data = sock.recv(16)
		print(data.decode())
