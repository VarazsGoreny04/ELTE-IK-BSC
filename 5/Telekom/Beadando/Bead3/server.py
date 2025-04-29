from socket import socket, AF_INET, SOCK_STREAM, SOL_SOCKET, SO_REUSEADDR, gethostbyname
from random import randrange
from struct import Struct
from select import select
from sys import argv

rnd = randrange(1, 101)
end = False
packer = Struct("ci")

def Main() -> None:
	#print(rnd)

	with socket(AF_INET, SOCK_STREAM) as sock:
		sock.setblocking(False)
		sock.setsockopt(SOL_SOCKET, SO_REUSEADDR, 1)

		addr = (gethostbyname(argv[1]), int(argv[2]))
		sock.bind(addr)
		sock.listen(0)

		mess = packer.pack(b"?", 0)

		inputs = [sock]
		outputs = []
		errors = []

		try:
			while (True):
				(readable, _, _) = select(inputs, outputs, errors, 1)

				for readSock in readable:
					if (readSock is sock):
						(connSock, _) = readSock.accept()
						inputs.append(connSock)
					else:
						data = readSock.recv(16)

						if (not data):
							inputs.remove(readSock)
						else:
							mess = packer.unpack(data)
							print(mess)

							if (end):
								readSock.send(packer.pack(b"V", 0))
							else:
								readSock.send(packer.pack(Evaluate(mess[0], mess[1]), 0))
		except (KeyboardInterrupt):
			print("Interrupted. Server is shutting down.")

def Evaluate(op: str, num: int) -> str:
	if (op == b"="):
		if (rnd == num):
			global end
			end = True

			return b"Y"
		else:
			return b"K"
	else:
		if (eval(str(rnd) + op.decode() + str(num))):
			return b"I"
		else:
			return b"N"

if (__name__ == "__main__"):
	Main()