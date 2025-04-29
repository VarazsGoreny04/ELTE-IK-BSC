import socket

with socket.socket(socket.AF_INET, socket.SOCK_DGRAM) as sock:
	addr = ("127.0.0.1", 8000)

	print(f"Message sent.")
	
	with open("udp.png", "rb") as f:
		data = f.read(200)
		while data:
			sock.sendto(data, addr)
			(ackData,ackAddr) = sock.recvfrom(5)
			print(ackData.decode())

			data = f.read(200)

		sock.sendto(b'', addr)