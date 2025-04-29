import socket
import select

with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as sock:
	sock.setblocking(False)
	sock.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)

	addr = ("127.0.0.1", 8000)
	sock.bind(addr)
	sock.listen(0)
	print(f"Listening on: {addr}")

	inputs = [sock]
	outputs = []
	errors = []

	try:
		while (True):
			(readable, writable, exceptional) = select.select(inputs, outputs, errors, 1)

			for readSock in readable:

				if (readSock is sock): # new connection
					(connSock, connAddr) = readSock.accept()
					inputs.append(connSock)
					print(f"Connected: {connAddr}")
				else: # existing socket sends data
					data = readSock.recv(16)
					if (not data):
						print(f"Disconnected: {readSock.getpeername()}")
						inputs.remove(readSock)
					else:
						print(f"Data {data.decode()}")

			'''try:
				(connSock, connAddr) = sock.accept()
				print(f"Connected: {connAddr}")

				data = connSock.recv(16)
				print(data.decode())

				connSock.close()
			except (BlockingIOError):
				#print("Sleeping...")
				time.sleep(0.1)'''
	except (KeyboardInterrupt):
		print("Interrupted. Server is shutting down.")