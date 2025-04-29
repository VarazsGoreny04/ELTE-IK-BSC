import struct
import socket

values = (4, b"ab", 3.14)

packer = struct.Struct(">i2sf")
packed_data = packer.pack(*values)
print(packed_data)
print(packer.size)

packer = struct.Struct("<i2sf")
packed_data = packer.pack(*values)
print(packed_data)
print(packer.size)

unpacker = struct.Struct("<i2sf")
print(unpacker.unpack(packed_data))

print(socket.gethostbyname_ex(socket.gethostname()))

#with open("test.txt", "r") as f:
#	for line in f:
#		print(line, end = "")
#
#	f.seek(0, 0)
#
#	print("\n\n" + f.read(8))