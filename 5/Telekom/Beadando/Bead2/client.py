import sys
import struct

def Main():
	Task1()
	Task2()

def Task1():
	for (fileName, fileDataFormat) in zip(sys.argv[1:5], ["? c 9s", "9s i f", "f c ?", "9s ? i"]):
		with open(fileName, "rb") as file:
			unpacker = struct.Struct(fileDataFormat)
			print(unpacker.unpack(file.read(unpacker.size)))

def Task2():
	print(struct.pack("18s i ?", b"elso", 86,         True))
	print(struct.pack("f ? c",   89.5,    False,      b"X"))
	print(struct.pack("i 16s f", 77,      b"masodik", 96.9))
	print(struct.pack("c i 19s", b"Z",    108,        b"harmadik"))

if __name__ == "__main__":
	Main() 