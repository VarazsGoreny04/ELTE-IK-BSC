# Külde el a következő üzenetet a teszt szerverre: ("TCPKliens",neptun kódod, "mvm5c1yd4l2g6qi5") (10s,6s,20s)
# A szerver válasz üzenete egy állapot és egy karaktersorozat. (10s,100s)
# A karaktersorozatból küldd vissza a 1. 2. 5. karaktert a szervernek. (3s)
# A szerver válasz üzenete egy állapot és egy karaktersorozat. (10s,100s)
# Ha sikeres akkor a karaktersorozatot írd be a canvasba.

from socket import socket,AF_INET, SOCK_STREAM, timeout, SOL_SOCKET, SO_REUSEADDR
import struct

server_addr = ("oktnb147.inf.elte.hu",11224)

packer1 = struct.Struct("10s 6s 20s")
data = packer1.pack("TCPKliens".encode(), "WSI1IC".encode(), "mvm5c1yd4l2g6qi5".encode())
packer_resp = struct.Struct("10s 100s")
packer2 = struct.Struct("3s")


with socket(AF_INET, SOCK_STREAM) as client:
	client.connect(server_addr)
	
	client.sendall(data)
	data = client.recv(packer_resp.size)
	state, karaktersor = packer_resp.unpack(data)
	print("State: ",state)
	print("karaktersor: ",karaktersor)
	
	valasz = ""
	characters = karaktersor.decode()
	valasz = str(characters[1]) + str(characters[2]) + str(characters[5])
	print (str(valasz))
	response = packer2.pack(str(valasz).encode())
	
	client.sendall(response)
	data = client.recv(packer_resp.size)
	state, karaktersor = packer_resp.unpack(data)
	print("State: ",state)
	print("karaktersor: ",karaktersor)
