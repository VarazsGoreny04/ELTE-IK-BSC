import socket
import struct

with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as sock:
	packer = struct.Struct("fcf")
	addr = ("127.0.0.1", 9000)

	sock.bind(addr)
	sock.listen(0)
	print(f"Server is listening on {addr[0]}:{addr[1]}...")

	(conn, addr) = sock.accept()

	mess = conn.recv(packer.size)
	(num1, op, num2) = packer.unpack(mess)
	result = eval(f"{num1} {op.decode()} {num2}")
	print(f"{num1} {op.decode()} {num2} = {result}")
	conn.send(str(result).encode())