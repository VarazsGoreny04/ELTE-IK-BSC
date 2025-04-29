# Feladat1 - írj egy UDP klienst
# Küldd el a következő üzenetet a teszt szerverre: ("UDPKliens",neptun kódod, "e576g53r6q79shv7") (10s,6s,20s)
# A szerver válasz üzenete egy állapot és egy karaktersorozat. (10s,100s)
# A karaktersorozatból küldd vissza a 5. 7. 7. karaktert a szervernek. (3s)
# A szerver válasz üzenete egy állapot és egy karaktersorozat. (10s,100s)

from socket import socket, AF_INET, SOCK_DGRAM
import struct

server_addr = ("oktnb147.inf.elte.hu",11235)

packer1 = struct.Struct("10s 6s 20s")
data = packer1.pack("UDPKliens".encode(), "WSI1IC".encode(), "e576g53r6q79shv7".encode())
packer_resp = struct.Struct("10s 100s")
packer2 = struct.Struct("3s")

with socket(AF_INET, SOCK_DGRAM) as client:
	client.sendto(data, server_addr)
	data, _ = client.recvfrom(packer_resp.size)
	state, karaktersor = packer_resp.unpack(data)
	print("State: ",state)
	print("karaktersor: ",karaktersor)
	valasz = karaktersor[5] + karaktersor[7] + karaktersor[7]
	
	
	client.sendto(packer2.pack(str(valasz).encode()),server_addr)
	state = ""
	karaktersor = ""
	state, karaktersor = packer_resp.unpack(data)
	print("State: ",state)
	print("karaktersor: ",karaktersor)