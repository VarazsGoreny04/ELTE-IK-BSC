import socket
from struct import Struct

packer = Struct("ici")

with socket.socket(socket.AF_INET, socket.SOCK_DGRAM) as sock:
	addr = ("127.0.0.1", 8000)
	sock.bind(addr)

	try:
		try:
			(data, addr) = sock.recvfrom(20)
			(n1, op, n2) = packer.unpack(data)
			
			res = eval(str(n1) + op.decode() + str(n1))
			print(f"{n1} {op.decode()} {n2} = {res}")
			
			sock.sendto(res, addr)
		except BlockingIOError:
			pass
	except KeyboardInterrupt:
		print("Interrupted.")