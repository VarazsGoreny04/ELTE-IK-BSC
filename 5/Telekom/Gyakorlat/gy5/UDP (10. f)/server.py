import socket

with socket.socket(socket.AF_INET, socket.SOCK_DGRAM) as sock:
	addr = ("127.0.0.1", 8000)
	sock.bind(addr)

	try:
		try:
			(data, addr) = sock.recvfrom(20)
			print(data.decode())
			sock.sendto(b"Hello Client!", addr)
		except BlockingIOError:
			pass
	except KeyboardInterrupt:
		print("Interrupted.")