import socket
import struct

thisAddr = ("127.0.0.1", 8000)
serverAddr = ("127.0.0.1", 9000)
packer = struct.Struct("9si")

    
with socket.socket(socket.AF_INET, socket.SOCK_DGRAM) as sock:
	sock.bind(thisAddr)
	print("Waiting for any data...")
	(data, addr) = sock.recvfrom(1024)
	
	print(f"Connected: {addr}, ", end="")

	if (data == b"GET"):
		sock.sendto(packer.pack(serverAddr[0].encode(), serverAddr[1]), addr)
		print("Accepted")
	else:
		print("Rejected")