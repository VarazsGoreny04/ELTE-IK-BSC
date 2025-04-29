from sys import argv
from socket import socket, AF_INET, SOCK_STREAM
from select import select
from time import time

serverAddr = (argv[1], int(argv[2]))
checkSums = []

print(serverAddr)

with socket(AF_INET, SOCK_STREAM) as server:
	server.bind(serverAddr)
	server.listen(1)
	print("Listening for new connections...")

	inputs = [server]
	timeout = 1
	
	try:
		while (True):
			(readable, writeable, exceptional) = select(inputs, inputs, inputs, timeout)
			
			if (not (readable or writeable or exceptional)):
				print("Listening for new connections...")
				continue
			
			for sock in readable:
				if (sock is server): # new connection
					(client, client_addr) = sock.accept()
					inputs.append(client)
					print(f"\nConnected: {client_addr}")
				else: # an existing connection is readable
					data = sock.recv(1024)

					if (not data):
						print(f"\nLogout: {sock}\n")

						inputs.remove(sock)
						sock.close()
					else:
						mess = data.decode().split('|')
						
						if (mess[0] == "BE"):
							checkSums.append((time(), mess[1], mess[2], mess[3], mess[4]))
							sock.send("OK".encode())
							print("\nAcknowledged")
						elif (mess[0] == "KI"):
							i = 0
							
							while (i < len(checkSums) and checkSums[i][1] != mess[1]):
								i += 1

							if (i >= len(checkSums)):
								Exception
							else:
								if (time() - checkSums[i][0] < float(checkSums[i][2])):
									print("\nAccepted")
									sock.send(f"{checkSums[i][3]}|{checkSums[i][4]}".encode())
								else:
									print(f"\nRejected\nLogout: {sock}\n")
									sock.send(b"1|-")

									inputs.remove(sock)
									sock.close()

								checkSums.pop(i)
						else:
							Exception
	except (KeyboardInterrupt):
		print("Closing the server...")