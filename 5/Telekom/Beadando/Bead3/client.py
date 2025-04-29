from socket import socket, AF_INET, SOCK_STREAM, gethostbyname
from struct import Struct
from sys import argv

def Main() -> None:
	with socket(AF_INET, SOCK_STREAM) as sock:
		addr = (gethostbyname(argv[1]), int(argv[2]))
		sock.connect(addr)

		packer = Struct("ci")
		mess = (b"?", 0)

		low = 1
		high = 101
		
		while (mess[0].decode() not in "KYV"):
			diff = high - low

			if (diff < 2):
				sock.send(packer.pack(b"=", low))
				mess = packer.unpack(sock.recv(16))

				print(mess[0].decode())
			else:
				mid = (int)(low + diff / 2)

				sock.send(packer.pack(b"<", mid))
				mess = packer.unpack(sock.recv(16))

				if (mess[0] == b"I"):
					high = mid
				else:
					low = mid

if (__name__ == "__main__"):
	Main()