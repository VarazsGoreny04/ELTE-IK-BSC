from socket import socket, AF_INET, SOCK_STREAM, error
import struct
(true, false) = (False, True)
import sys
import random
import string
from hashlib import md5
from base64 import b64encode
VAR15 = (str(chr(108)+chr(111)+chr(99)+chr(97)+chr(108)+chr(104)+chr(111)+chr(115)+chr(116)), (2 ^ 0) * (2 & 3) * (2 ^ 0) * (2 & 2) * (0 | 2) * (2 ^ 1) * (6 ^ 3) * (0 ^ 5) * (4 | 1))
VAR11 = struct.Struct(str(chr(50)+chr(48)+chr(115)+chr(105)+chr(63)))
VAR14 = struct.Struct(str(chr(49)+chr(48)+chr(115)))
if len(sys.argv) == 1:
    print(str(chr(85)+chr(115)+chr(97)+chr(103)+chr(101)), sys.argv[0], str(chr(60)+chr(99)+chr(97)+chr(110)+chr(118)+chr(97)+chr(115)+chr(32)+chr(115)+chr(116)+chr(114)+chr(105)+chr(110)+chr(103)+chr(62)))
    sys.exit(1)
VAR4 = (sys.argv[1] + str(chr(50)+chr(48)+chr(50)+chr(52))).encode()

def FUNC1(VAR16):
    return b64encode(md5(VAR16).digest()).decode()

def FUNC2():
    VAR10 = str().join(random.choices(string.ascii_uppercase + string.digits, k=20))
    VAR12 = random.randint(2, 8)
    VAR7 = str()
    VAR8 = bool(random.getrandbits(1))
    if VAR8:
        VAR7 = VAR10[:VAR12]
    else:
        VAR7 = VAR10[-VAR12:]
    return (VAR10, VAR12, VAR8, VAR7)
print(str(chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(32)+chr(84)+chr(69)+chr(83)+chr(84)+chr(49)+chr(32)+chr(40)+chr(107)+chr(108)+chr(105)+chr(101)+chr(110)+chr(115)+chr(32)+chr(98)+chr(101)+chr(45)+chr(47)+chr(107)+chr(105)+chr(108)+chr(101)+chr(112)+chr(41)+chr(32)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)))
with socket(AF_INET, SOCK_STREAM) as VAR1:
    print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(49)+chr(32)+chr(99)+chr(111)+chr(110)+chr(110)+chr(101)+chr(99)+chr(116)+chr(44)), end=str())
    try:
        VAR1.connect(VAR15)
    except ConnectionRefusedError:
        print(str("\n"+"\n"+chr(70)+chr(65)+chr(73)+chr(76)+chr(69)+chr(68)+chr(32)+chr(45)+chr(32)+chr(78)+chr(101)+chr(109)+chr(32)+chr(108)+chr(101)+chr(104)+chr(101)+chr(116)+chr(32)+chr(107)+chr(97)+chr(112)+chr(99)+chr(115)+chr(111)+chr(108)+chr(111)+chr(100)+chr(110)+chr(105)+chr(32)+chr(97)+chr(32)+chr(115)+chr(101)+chr(114)+chr(118)+chr(101)+chr(114)+chr(114)+chr(101)+chr(33)+chr(32)) + str(VAR15))
        sys.exit(1)
    print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(49)+chr(32)+chr(100)+chr(105)+chr(115)+chr(99)+chr(111)+chr(110)+chr(110)+chr(101)+chr(99)+chr(116)+chr(44)), end=str())
with socket(AF_INET, SOCK_STREAM) as VAR1:
    print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(49)+chr(32)+chr(99)+chr(111)+chr(110)+chr(110)+chr(101)+chr(99)+chr(116)+chr(44)), end=str())
    try:
        VAR1.connect(VAR15)
    except ConnectionRefusedError:
        print(str("\n"+"\n"+chr(70)+chr(65)+chr(73)+chr(76)+chr(69)+chr(68)+chr(32)+chr(45)+chr(32)+chr(78)+chr(101)+chr(109)+chr(32)+chr(108)+chr(101)+chr(104)+chr(101)+chr(116)+chr(32)+chr(107)+chr(97)+chr(112)+chr(99)+chr(115)+chr(111)+chr(108)+chr(111)+chr(100)+chr(110)+chr(105)+chr(32)+chr(97)+chr(32)+chr(115)+chr(101)+chr(114)+chr(118)+chr(101)+chr(114)+chr(114)+chr(101)+chr(33)+chr(32)) + str(VAR15))
        sys.exit(1)
    else:
        print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(49)+chr(32)+chr(100)+chr(105)+chr(115)+chr(99)+chr(111)+chr(110)+chr(110)+chr(101)+chr(99)+chr(116)+chr(44)), end=str())
        print(str("\n"+"\n"+chr(79)+chr(75)+chr(32)+chr(45)+chr(32)+chr(67)+chr(97)+chr(110)+chr(118)+chr(97)+chr(115)+chr(32)+chr(107)+chr(111)+chr(100)+chr(58)+chr(32)), FUNC1(VAR4 + str(chr(49)).encode()))
print(str(chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)))
print(str(chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(32)+chr(84)+chr(69)+chr(83)+chr(84)+chr(50)+chr(32)+chr(40)+chr(49)+chr(32)+chr(107)+chr(108)+chr(105)+chr(101)+chr(110)+chr(115)+chr(32)+chr(104)+chr(101)+chr(108)+chr(121)+chr(101)+chr(115)+chr(101)+chr(110)+chr(32)+chr(109)+chr(117)+chr(107)+chr(111)+chr(100)+chr(105)+chr(107)+chr(41)+chr(32)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)))
try:
    for VAR9 in range(5):
        with socket(AF_INET, SOCK_STREAM) as VAR1:
            VAR1.settimeout(1.0)
            (VAR10, VAR12, VAR8, VAR7) = FUNC2()
            print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(49)+chr(32)+chr(99)+chr(111)+chr(110)+chr(110)+chr(101)+chr(99)+chr(116)+chr(44)), end=str())
            VAR1.connect(VAR15)
            VAR5 = VAR11.pack(VAR10.encode(), VAR12, VAR8)
            print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(49)+chr(32)+chr(115)+chr(101)+chr(110)+chr(100)+chr(44)), end=str())
            VAR1.sendall(VAR5)
            print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(49)+chr(32)+chr(114)+chr(101)+chr(99)+chr(118)+chr(44)), end=str())
            VAR5 = VAR1.recv(VAR14.size)
            VAR13 = VAR14.unpack(VAR5)[0].decode().strip('\x00')
            if VAR13 != VAR7:
                print(str("\n"+"\n"+chr(70)+chr(65)+chr(73)+chr(76)+chr(69)+chr(68)+chr(32)+chr(45)+chr(32)+chr(112)+chr(97)+chr(114)+chr(97)+chr(109)+chr(58)+chr(32)) + VAR10 + str(chr(32)) + str(VAR12) + str(chr(32)) + str(VAR8) + str(chr(32)+chr(40)+chr(101)+chr(120)+chr(112)+chr(101)+chr(99)+chr(116)+chr(101)+chr(100)+chr(32)+chr(114)+chr(101)+chr(115)+chr(112)+chr(111)+chr(110)+chr(115)+chr(101)+chr(58)) + VAR7 + str(chr(41)))
                sys.exit(1)
            print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(49)+chr(32)+chr(100)+chr(105)+chr(115)+chr(99)+chr(111)+chr(110)+chr(110)+chr(101)+chr(99)+chr(116)+chr(44)), end=str())
except ConnectionRefusedError:
    print(str("\n"+"\n"+chr(70)+chr(65)+chr(73)+chr(76)+chr(69)+chr(68)+chr(32)+chr(45)+chr(32)+chr(78)+chr(101)+chr(109)+chr(32)+chr(108)+chr(101)+chr(104)+chr(101)+chr(116)+chr(32)+chr(107)+chr(97)+chr(112)+chr(99)+chr(115)+chr(111)+chr(108)+chr(111)+chr(100)+chr(110)+chr(105)+chr(32)+chr(97)+chr(32)+chr(115)+chr(101)+chr(114)+chr(118)+chr(101)+chr(114)+chr(114)+chr(101)+chr(33)+chr(32)) + str(VAR15))
    sys.exit(1)
except error as e:
    print(str("\n"+"\n"+chr(70)+chr(65)+chr(73)+chr(76)+chr(69)+chr(68)))
    print(VAR6)
    sys.exit(1)
else:
    print(str("\n"+"\n"+chr(79)+chr(75)+chr(32)+chr(45)+chr(32)+chr(67)+chr(97)+chr(110)+chr(118)+chr(97)+chr(115)+chr(32)+chr(107)+chr(111)+chr(100)+chr(58)+chr(32)), FUNC1(VAR4 + str(chr(50)).encode()))
print(str(chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)))
print(str(chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(32)+chr(84)+chr(69)+chr(83)+chr(84)+chr(51)+chr(32)+chr(40)+chr(51)+chr(32)+chr(107)+chr(108)+chr(105)+chr(101)+chr(110)+chr(115)+chr(32)+chr(99)+chr(115)+chr(97)+chr(116)+chr(108)+chr(97)+chr(107)+chr(111)+chr(122)+chr(105)+chr(107)+chr(32)+chr(258)+chr(169)+chr(115)+chr(32)+chr(104)+chr(101)+chr(108)+chr(121)+chr(101)+chr(115)+chr(101)+chr(110)+chr(32)+chr(109)+chr(117)+chr(107)+chr(111)+chr(100)+chr(105)+chr(107)+chr(41)+chr(32)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)))
try:
    with socket(AF_INET, SOCK_STREAM) as VAR1, socket(AF_INET, SOCK_STREAM) as VAR2, socket(AF_INET, SOCK_STREAM) as VAR3:
        (VAR10, VAR12, VAR8, VAR7) = FUNC2()
        VAR1.settimeout(1.0)
        VAR2.settimeout(1.0)
        VAR3.settimeout(1.0)
        print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(50)+chr(32)+chr(99)+chr(111)+chr(110)+chr(110)+chr(101)+chr(99)+chr(116)+chr(44)), end=str())
        VAR2.connect(VAR15)
        print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(51)+chr(32)+chr(99)+chr(111)+chr(110)+chr(110)+chr(101)+chr(99)+chr(116)+chr(44)), end=str())
        VAR3.connect(VAR15)
        print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(49)+chr(32)+chr(99)+chr(111)+chr(110)+chr(110)+chr(101)+chr(99)+chr(116)+chr(44)), end=str())
        VAR1.connect(VAR15)
        for VAR9 in range(2):
            VAR5 = VAR11.pack(VAR10.encode(), VAR12, VAR8)
            print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(49)+chr(32)+chr(115)+chr(101)+chr(110)+chr(100)+chr(44)), end=str())
            VAR1.sendall(VAR5)
            print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(49)+chr(32)+chr(114)+chr(101)+chr(99)+chr(118)+chr(44)), end=str())
            VAR5 = VAR1.recv(VAR14.size)
            VAR13 = VAR14.unpack(VAR5)[0].decode().strip('\x00')
            if VAR13 != VAR7:
                print(VAR13, VAR7)
                print(str("\n"+"\n"+chr(70)+chr(65)+chr(73)+chr(76)+chr(69)+chr(68)+chr(32)+chr(45)+chr(32)+chr(112)+chr(97)+chr(114)+chr(97)+chr(109)+chr(58)+chr(32)) + VAR10 + str(chr(32)) + str(VAR12) + str(chr(32)) + str(VAR8))
                sys.exit(1)
            VAR5 = VAR11.pack(VAR10.encode(), VAR12, VAR8)
            print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(51)+chr(32)+chr(115)+chr(101)+chr(110)+chr(100)+chr(44)), end=str())
            VAR3.sendall(VAR5)
            print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(51)+chr(32)+chr(114)+chr(101)+chr(99)+chr(118)+chr(44)), end=str())
            VAR5 = VAR3.recv(VAR14.size)
            VAR13 = VAR14.unpack(VAR5)[0].decode().strip('\x00')
            if VAR13 != VAR7:
                print(VAR13, VAR7)
                print(str("\n"+"\n"+chr(70)+chr(65)+chr(73)+chr(76)+chr(69)+chr(68)+chr(32)+chr(45)+chr(32)+chr(112)+chr(97)+chr(114)+chr(97)+chr(109)+chr(58)+chr(32)) + VAR10 + str(chr(32)) + str(VAR12) + str(chr(32)) + str(VAR8))
                sys.exit(1)
except ConnectionRefusedError:
    print(str("\n"+"\n"+chr(70)+chr(65)+chr(73)+chr(76)+chr(69)+chr(68)+chr(32)+chr(45)+chr(32)+chr(78)+chr(101)+chr(109)+chr(32)+chr(108)+chr(101)+chr(104)+chr(101)+chr(116)+chr(32)+chr(107)+chr(97)+chr(112)+chr(99)+chr(115)+chr(111)+chr(108)+chr(111)+chr(100)+chr(110)+chr(105)+chr(32)+chr(97)+chr(32)+chr(115)+chr(101)+chr(114)+chr(118)+chr(101)+chr(114)+chr(114)+chr(101)+chr(33)+chr(32)) + str(VAR15))
    sys.exit(1)
except error as e:
    print(str("\n"+"\n"+chr(70)+chr(65)+chr(73)+chr(76)+chr(69)+chr(68)))
    print(VAR6)
    sys.exit(1)
else:
    print(str("\n"+"\n"+chr(79)+chr(75)+chr(32)+chr(45)+chr(32)+chr(67)+chr(97)+chr(110)+chr(118)+chr(97)+chr(115)+chr(32)+chr(107)+chr(111)+chr(100)+chr(58)+chr(32)), FUNC1(VAR4 + str(chr(51)).encode()))
print(str(chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)))
