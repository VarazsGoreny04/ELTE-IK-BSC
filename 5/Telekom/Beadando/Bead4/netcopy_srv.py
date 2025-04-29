from sys import argv
from socket import socket, AF_INET, SOCK_STREAM
from hashlib import md5

addrNetcopy = (argv[1], int(argv[2]))
m = md5()

with socket(AF_INET, SOCK_STREAM) as netcopy:
	netcopy.bind(addrNetcopy)
	netcopy.listen(1)

	print("Listening for new connection...")

	(connSock, clientAddr) = netcopy.accept()

	try:
		try:
			with connSock:
				data = connSock.recv(200)

				with open(argv[6], "wb") as f:
					while (data):
						m.update(data)
						f.write(data)
						data = connSock.recv(200)

			checkSum = m.hexdigest()
			print(checkSum)

			with socket(AF_INET, SOCK_STREAM) as tcp:
				addrTcp = (argv[3], int(argv[4]))
				tcp.connect(addrTcp)
				tcp.send(f"KI|{argv[5]}".encode())
				
				print("Message sent.")

				result = tcp.recv(1024).decode().split("|")

				if (result[1] == checkSum):
					print("CSUM OK")
				elif (result[1]  == "-"):
					print("TIMEOUT")
				else:
					print("CSUM CORRUPTED")

		except BlockingIOError:
			pass
	except KeyboardInterrupt:
		print("Interrupted.")