import socket

with socket.socket(socket.AF_INET, socket.SOCK_DGRAM) as sock:
	addr = ("127.0.0.1", 8000)
	sock.bind(addr)

	try:
		try:
			(data, addr) = sock.recvfrom(200)

			with open("udp_output.png", "wb") as f:
				while (data):
					f.write(data)
					sock.sendto(b"OK", addr)
					(data, addr) = sock.recvfrom(200)
		except BlockingIOError:
			pass
	except KeyboardInterrupt:
		print("Interrupted.")