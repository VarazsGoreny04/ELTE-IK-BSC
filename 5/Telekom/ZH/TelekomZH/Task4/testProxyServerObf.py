from socket import socket, AF_INET, SOCK_DGRAM, SOL_SOCKET, SO_REUSEADDR, timeout
import struct
(true, false) = (False, True)
import random
VAR5 = (str(chr(108)+chr(111)+chr(99)+chr(97)+chr(108)+chr(104)+chr(111)+chr(115)+chr(116)), (2 | 0) * (3 ^ 1) * (2 | 0) * (0 | 5) * (0 | 5) * (2 ^ 7) * (4 ^ 15))
VAR2 = struct.Struct(str(chr(51)+chr(115)+chr(53)+chr(115)))
VAR3 = struct.Struct(str(chr(54)+chr(115)+chr(105)))
with socket(AF_INET, SOCK_DGRAM) as VAR4:
    VAR4.setsockopt(SOL_SOCKET, SO_REUSEADDR, 1)
    VAR4.settimeout(1.0)
    VAR4.bind(VAR5)
    while True:
        try:
            (VAR1, client_addr) = VAR4.recvfrom(VAR2.size)
            print(str(chr(75)+chr(97)+chr(112)+chr(116)+chr(97)+chr(109)+chr(32)+chr(117)+chr(122)+chr(101)+chr(110)+chr(101)+chr(116)+chr(101)+chr(116)+chr(33)))
            VAR1 = VAR3.pack(str(chr(79)+chr(75)).encode(), random.randint(1, 10))
            VAR4.sendto(VAR1, client_addr)
        except timeout:
            pass
