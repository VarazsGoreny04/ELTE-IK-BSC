from sys import argv
from socket import socket, AF_INET, SOCK_STREAM
from hashlib import md5

addrNetcopy = (argv[1], int(argv[2]))
m = md5()

with socket(AF_INET, SOCK_STREAM) as netcopy:
	netcopy.connect(addrNetcopy)

	print(f"Sending file...")
	
	with open(argv[6], "rb") as f:
		data = f.read(200)
		while (data):
			m.update(data)

			netcopy.send(data)
			data = f.read(200)

	checkSum = m.hexdigest()
	print(checkSum)

	with socket(AF_INET, SOCK_STREAM) as tcp:
		addrTcp = (argv[3], int(argv[4]))
		tcp.connect(addrTcp)
		tcp.send(f"BE|{argv[5]}|6|{len(checkSum)}|{checkSum}".encode())
		print("Message and checksum sent.")
		print(f"Recived: {tcp.recv(1024).decode()}")

	netcopy.sendto(b"", addrNetcopy)