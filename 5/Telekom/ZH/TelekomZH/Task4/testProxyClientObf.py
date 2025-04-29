from socket import socket, AF_INET, SOCK_STREAM, timeout, error
import struct
(true, false) = (False, True)
import time
import random
import string
from hashlib import md5
from base64 import b64encode
import sys
VAR8 = (str(chr(108)+chr(111)+chr(99)+chr(97)+chr(108)+chr(104)+chr(111)+chr(115)+chr(116)), (3 & 2) * (3 & 2) * (2 & 3) * (2 | 0) * (5 | 5) * (5 & 5) * (7 & 5) * (1 | 4))
VAR6 = struct.Struct(str(chr(51)+chr(115)+chr(53)+chr(115)))
VAR7 = struct.Struct(str(chr(54)+chr(115)+chr(105)))
if len(sys.argv) == 1:
    print(str(chr(85)+chr(115)+chr(97)+chr(103)+chr(101)), sys.argv[0], str(chr(60)+chr(99)+chr(97)+chr(110)+chr(118)+chr(97)+chr(115)+chr(32)+chr(115)+chr(116)+chr(114)+chr(105)+chr(110)+chr(103)+chr(62)))
    sys.exit(1)
VAR3 = (sys.argv[1] + str(chr(50)+chr(112)+chr(48)+chr(114)+chr(50)+chr(120)+chr(52)+chr(121))).encode()

def FUNC1(VAR9):
    return b64encode(md5(VAR9).digest()).decode()
print(str(chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(32)+chr(84)+chr(69)+chr(83)+chr(84)+chr(49)+chr(32)+chr(40)+chr(49)+chr(32)+chr(107)+chr(108)+chr(105)+chr(101)+chr(110)+chr(115)+chr(32)+chr(98)+chr(101)+chr(45)+chr(47)+chr(107)+chr(105)+chr(108)+chr(101)+chr(112)+chr(41)+chr(32)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)))
with socket(AF_INET, SOCK_STREAM) as VAR1:
    try:
        VAR1.settimeout(5.0)
        print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(49)+chr(32)+chr(99)+chr(111)+chr(110)+chr(110)+chr(101)+chr(99)+chr(116)+chr(44)+chr(32)), end=str())
        VAR1.connect(VAR8)
        print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(49)+chr(32)+chr(100)+chr(105)+chr(115)+chr(99)+chr(111)+chr(110)+chr(110)+chr(101)+chr(99)+chr(116)+chr(44)+chr(32)), end=str())
    except ConnectionRefusedError:
        print(str("\n"+"\n"+chr(70)+chr(65)+chr(73)+chr(76)+chr(69)+chr(68)+chr(32)+chr(45)+chr(32)+chr(78)+chr(101)+chr(109)+chr(32)+chr(108)+chr(101)+chr(104)+chr(101)+chr(116)+chr(32)+chr(107)+chr(97)+chr(112)+chr(99)+chr(115)+chr(111)+chr(108)+chr(111)+chr(100)+chr(110)+chr(105)+chr(32)+chr(97)+chr(32)+chr(115)+chr(101)+chr(114)+chr(118)+chr(101)+chr(114)+chr(114)+chr(101)+chr(33)+chr(32)) + str(VAR8))
        sys.exit(1)
    except Exception as e:
        print(str("\n"+"\n"+chr(70)+chr(65)+chr(73)+chr(76)+chr(69)+chr(68)))
        print(VAR5)
        sys.exit(1)
    else:
        print(str("\n"+"\n"+chr(79)+chr(75)+chr(32)+chr(45)+chr(32)+chr(67)+chr(97)+chr(110)+chr(118)+chr(97)+chr(115)+chr(32)+chr(107)+chr(111)+chr(100)+chr(58)+chr(32)), FUNC1(VAR3 + str(chr(116)+chr(49)).encode()))
print(str(chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)))
print(str(chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(32)+chr(84)+chr(69)+chr(83)+chr(84)+chr(50)+chr(32)+chr(40)+chr(49)+chr(32)+chr(107)+chr(108)+chr(105)+chr(101)+chr(110)+chr(115)+chr(32)+chr(98)+chr(101)+chr(45)+chr(47)+chr(107)+chr(105)+chr(108)+chr(101)+chr(112)+chr(41)+chr(32)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)))
with socket(AF_INET, SOCK_STREAM) as VAR1:
    try:
        VAR1.settimeout(5.0)
        print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(49)+chr(32)+chr(99)+chr(111)+chr(110)+chr(110)+chr(101)+chr(99)+chr(116)+chr(44)+chr(32)), end=str())
        VAR1.connect(VAR8)
        print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(49)+chr(32)+chr(100)+chr(105)+chr(115)+chr(99)+chr(111)+chr(110)+chr(110)+chr(101)+chr(99)+chr(116)+chr(44)+chr(32)), end=str())
    except ConnectionRefusedError:
        print(str("\n"+"\n"+chr(70)+chr(65)+chr(73)+chr(76)+chr(69)+chr(68)+chr(32)+chr(45)+chr(32)+chr(78)+chr(101)+chr(109)+chr(32)+chr(108)+chr(101)+chr(104)+chr(101)+chr(116)+chr(32)+chr(107)+chr(97)+chr(112)+chr(99)+chr(115)+chr(111)+chr(108)+chr(111)+chr(100)+chr(110)+chr(105)+chr(32)+chr(97)+chr(32)+chr(115)+chr(101)+chr(114)+chr(118)+chr(101)+chr(114)+chr(114)+chr(101)+chr(33)+chr(32)) + str(VAR8))
        sys.exit(1)
    except Exception as e:
        print(str("\n"+"\n"+chr(70)+chr(65)+chr(73)+chr(76)+chr(69)+chr(68)))
        print(VAR5)
        sys.exit(1)
with socket(AF_INET, SOCK_STREAM) as VAR1:
    try:
        VAR1.settimeout(5.0)
        print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(49)+chr(32)+chr(99)+chr(111)+chr(110)+chr(110)+chr(101)+chr(99)+chr(116)+chr(44)+chr(32)), end=str())
        VAR1.connect(VAR8)
        print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(49)+chr(32)+chr(100)+chr(105)+chr(115)+chr(99)+chr(111)+chr(110)+chr(110)+chr(101)+chr(99)+chr(116)+chr(44)+chr(32)), end=str())
    except ConnectionRefusedError:
        print(str("\n"+"\n"+chr(70)+chr(65)+chr(73)+chr(76)+chr(69)+chr(68)+chr(32)+chr(45)+chr(32)+chr(78)+chr(101)+chr(109)+chr(32)+chr(108)+chr(101)+chr(104)+chr(101)+chr(116)+chr(32)+chr(107)+chr(97)+chr(112)+chr(99)+chr(115)+chr(111)+chr(108)+chr(111)+chr(100)+chr(110)+chr(105)+chr(32)+chr(97)+chr(32)+chr(115)+chr(101)+chr(114)+chr(118)+chr(101)+chr(114)+chr(114)+chr(101)+chr(33)+chr(32)) + str(VAR8))
        sys.exit(1)
    except Exception as e:
        print(str("\n"+"\n"+chr(70)+chr(65)+chr(73)+chr(76)+chr(69)+chr(68)))
        print(VAR5)
        sys.exit(1)
    else:
        print(str("\n"+"\n"+chr(79)+chr(75)+chr(32)+chr(45)+chr(32)+chr(67)+chr(97)+chr(110)+chr(118)+chr(97)+chr(115)+chr(32)+chr(107)+chr(111)+chr(100)+chr(58)+chr(32)), FUNC1(VAR3 + str(chr(116)+chr(50)).encode()))
print(str(chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)))
print(str(chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(32)+chr(84)+chr(69)+chr(83)+chr(84)+chr(51)+chr(32)+chr(40)+chr(49)+chr(32)+chr(107)+chr(108)+chr(105)+chr(101)+chr(110)+chr(115)+chr(32)+chr(109)+chr(117)+chr(107)+chr(111)+chr(100)+chr(105)+chr(107)+chr(41)+chr(32)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)))
with socket(AF_INET, SOCK_STREAM) as VAR1:
    try:
        VAR1.settimeout(5.0)
        print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(49)+chr(32)+chr(99)+chr(111)+chr(110)+chr(110)+chr(101)+chr(99)+chr(116)+chr(44)+chr(32)), end=str())
        VAR1.connect(VAR8)
        print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(49)+chr(32)+chr(115)+chr(101)+chr(110)+chr(100)+chr(32)+chr(67)+chr(76)+chr(82)+chr(44)+chr(32)), end=str())
        VAR4 = VAR6.pack(str(chr(67)+chr(76)+chr(82)).encode(), str().join(random.choices(string.ascii_uppercase + string.digits, k=5)).encode())
        VAR1.sendall(VAR4)
        print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(49)+chr(32)+chr(114)+chr(101)+chr(99)+chr(118)+chr(44)+chr(32)), end=str())
        VAR4 = VAR1.recv(VAR7.size)
        print(VAR4)
        unpacked_data = VAR7.unpack(VAR4)
        print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(49)+chr(32)+chr(100)+chr(105)+chr(115)+chr(99)+chr(111)+chr(110)+chr(110)+chr(101)+chr(99)+chr(116)+chr(44)+chr(32)), end=str())
    except ConnectionRefusedError:
        print(str("\n"+"\n"+chr(70)+chr(65)+chr(73)+chr(76)+chr(69)+chr(68)+chr(32)+chr(45)+chr(32)+chr(78)+chr(101)+chr(109)+chr(32)+chr(108)+chr(101)+chr(104)+chr(101)+chr(116)+chr(32)+chr(107)+chr(97)+chr(112)+chr(99)+chr(115)+chr(111)+chr(108)+chr(111)+chr(100)+chr(110)+chr(105)+chr(32)+chr(97)+chr(32)+chr(115)+chr(101)+chr(114)+chr(118)+chr(101)+chr(114)+chr(114)+chr(101)+chr(33)+chr(32)) + str(VAR8))
        sys.exit(1)
    except Exception as e:
        print(str("\n"+"\n"+chr(70)+chr(65)+chr(73)+chr(76)+chr(69)+chr(68)))
        print(VAR5)
        sys.exit(1)
    else:
        print(str("\n"+"\n"+chr(79)+chr(75)+chr(32)+chr(45)+chr(32)+chr(67)+chr(97)+chr(110)+chr(118)+chr(97)+chr(115)+chr(32)+chr(107)+chr(111)+chr(100)+chr(58)+chr(32)), FUNC1(VAR3 + str(chr(116)+chr(51)).encode()))
print(str(chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)))
print(str(chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(32)+chr(84)+chr(69)+chr(83)+chr(84)+chr(52)+chr(32)+chr(40)+chr(49)+chr(32)+chr(107)+chr(108)+chr(105)+chr(101)+chr(110)+chr(115)+chr(32)+chr(98)+chr(101)+chr(45)+chr(47)+chr(107)+chr(105)+chr(108)+chr(101)+chr(112)+chr(41)+chr(32)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)))
with socket(AF_INET, SOCK_STREAM) as VAR1:
    try:
        VAR1.settimeout(5.0)
        print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(49)+chr(32)+chr(99)+chr(111)+chr(110)+chr(110)+chr(101)+chr(99)+chr(116)+chr(44)+chr(32)), end=str())
        VAR1.connect(VAR8)
        print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(49)+chr(32)+chr(115)+chr(101)+chr(110)+chr(100)+chr(32)+chr(71)+chr(69)+chr(84)+chr(44)+chr(32)), end=str())
        VAR4 = VAR6.pack(str(chr(71)+chr(69)+chr(84)).encode(), str(chr(111)+chr(109)+chr(104)+chr(118)+chr(32)).encode())
        VAR1.sendall(VAR4)
        print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(49)+chr(32)+chr(114)+chr(101)+chr(99)+chr(118)+chr(44)+chr(32)), end=str())
        VAR4 = VAR1.recv(VAR7.size)
        unpacked_data = VAR7.unpack(VAR4)
        print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(49)+chr(32)+chr(100)+chr(105)+chr(115)+chr(99)+chr(111)+chr(110)+chr(110)+chr(101)+chr(99)+chr(116)+chr(44)+chr(32)), end=str())
    except ConnectionRefusedError:
        print(str("\n"+"\n"+chr(70)+chr(65)+chr(73)+chr(76)+chr(69)+chr(68)+chr(32)+chr(45)+chr(32)+chr(78)+chr(101)+chr(109)+chr(32)+chr(108)+chr(101)+chr(104)+chr(101)+chr(116)+chr(32)+chr(107)+chr(97)+chr(112)+chr(99)+chr(115)+chr(111)+chr(108)+chr(111)+chr(100)+chr(110)+chr(105)+chr(32)+chr(97)+chr(32)+chr(115)+chr(101)+chr(114)+chr(118)+chr(101)+chr(114)+chr(114)+chr(101)+chr(33)+chr(32)) + str(VAR8))
        sys.exit(1)
    except Exception as e:
        print(str("\n"+"\n"+chr(70)+chr(65)+chr(73)+chr(76)+chr(69)+chr(68)))
        print(VAR5)
        sys.exit(1)
    else:
        print(str("\n"+"\n"+chr(79)+chr(75)+chr(32)+chr(45)+chr(32)+chr(67)+chr(97)+chr(110)+chr(118)+chr(97)+chr(115)+chr(32)+chr(107)+chr(111)+chr(100)+chr(58)+chr(32)), FUNC1(VAR3 + str(chr(116)+chr(52)).encode()))
print(str(chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)))
print(str(chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(32)+chr(84)+chr(69)+chr(83)+chr(84)+chr(53)+chr(32)+chr(40)+chr(49)+chr(32)+chr(107)+chr(108)+chr(105)+chr(101)+chr(110)+chr(115)+chr(32)+chr(109)+chr(117)+chr(107)+chr(111)+chr(100)+chr(105)+chr(107)+chr(41)+chr(32)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)))
with socket(AF_INET, SOCK_STREAM) as VAR1:
    try:
        VAR1.settimeout(5.0)
        print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(49)+chr(32)+chr(99)+chr(111)+chr(110)+chr(110)+chr(101)+chr(99)+chr(116)+chr(44)+chr(32)), end=str())
        VAR1.connect(VAR8)
        print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(49)+chr(32)+chr(115)+chr(101)+chr(110)+chr(100)+chr(32)+chr(71)+chr(69)+chr(84)+chr(44)+chr(32)), end=str())
        VAR4 = VAR6.pack(str(chr(71)+chr(69)+chr(84)).encode(), str().join(random.choices(string.ascii_uppercase + string.digits, k=5)).encode())
        VAR1.sendall(VAR4)
        print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(49)+chr(32)+chr(114)+chr(101)+chr(99)+chr(118)+chr(44)+chr(32)), end=str())
        VAR4 = VAR1.recv(VAR7.size)
        unpacked_data = VAR7.unpack(VAR4)
        print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(49)+chr(32)+chr(115)+chr(101)+chr(110)+chr(100)+chr(32)+chr(82)+chr(70)+chr(83)+chr(44)+chr(32)), end=str())
        VAR4 = VAR6.pack(str(chr(82)+chr(70)+chr(83)).encode(), str().join(random.choices(string.ascii_uppercase + string.digits, k=5)).encode())
        VAR1.sendall(VAR4)
        print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(49)+chr(32)+chr(114)+chr(101)+chr(99)+chr(118)+chr(44)+chr(32)), end=str())
        VAR4 = VAR1.recv(VAR7.size)
        unpacked_data = VAR7.unpack(VAR4)
        print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(49)+chr(32)+chr(100)+chr(105)+chr(115)+chr(99)+chr(111)+chr(110)+chr(110)+chr(101)+chr(99)+chr(116)+chr(44)), end=str())
    except ConnectionRefusedError:
        print(str("\n"+"\n"+chr(70)+chr(65)+chr(73)+chr(76)+chr(69)+chr(68)+chr(32)+chr(45)+chr(32)+chr(78)+chr(101)+chr(109)+chr(32)+chr(108)+chr(101)+chr(104)+chr(101)+chr(116)+chr(32)+chr(107)+chr(97)+chr(112)+chr(99)+chr(115)+chr(111)+chr(108)+chr(111)+chr(100)+chr(110)+chr(105)+chr(32)+chr(97)+chr(32)+chr(115)+chr(101)+chr(114)+chr(118)+chr(101)+chr(114)+chr(114)+chr(101)+chr(33)+chr(32)) + str(VAR8))
        sys.exit(1)
    except Exception as e:
        print(str("\n"+"\n"+chr(70)+chr(65)+chr(73)+chr(76)+chr(69)+chr(68)))
        print(VAR5)
        sys.exit(1)
    else:
        print(str("\n"+"\n"+chr(79)+chr(75)+chr(32)+chr(45)+chr(32)+chr(67)+chr(97)+chr(110)+chr(118)+chr(97)+chr(115)+chr(32)+chr(107)+chr(111)+chr(100)+chr(58)+chr(32)), FUNC1(VAR3 + str(chr(116)+chr(53)).encode()))
print(str(chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)))
print(str(chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(32)+chr(84)+chr(69)+chr(83)+chr(84)+chr(54)+chr(32)+chr(40)+chr(50)+chr(32)+chr(107)+chr(108)+chr(105)+chr(101)+chr(110)+chr(115)+chr(32)+chr(107)+chr(97)+chr(112)+chr(99)+chr(115)+chr(111)+chr(108)+chr(111)+chr(100)+chr(105)+chr(107)+chr(41)+chr(32)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)))
with socket(AF_INET, SOCK_STREAM) as VAR1, socket(AF_INET, SOCK_STREAM) as VAR2:
    try:
        VAR1.settimeout(5.0)
        VAR2.settimeout(5.0)
        print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(49)+chr(32)+chr(99)+chr(111)+chr(110)+chr(110)+chr(101)+chr(99)+chr(116)+chr(44)+chr(32)), end=str())
        VAR1.connect(VAR8)
        print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(50)+chr(32)+chr(99)+chr(111)+chr(110)+chr(110)+chr(101)+chr(99)+chr(116)+chr(44)+chr(32)), end=str())
        VAR2.connect(VAR8)
        print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(50)+chr(32)+chr(115)+chr(101)+chr(110)+chr(100)+chr(44)+chr(32)), end=str())
        VAR4 = VAR6.pack(str(chr(71)+chr(69)+chr(84)).encode(), str().join(random.choices(string.ascii_uppercase + string.digits, k=5)).encode())
        VAR2.sendall(VAR4)
        print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(50)+chr(32)+chr(114)+chr(101)+chr(99)+chr(118)+chr(44)+chr(32)), end=str())
        VAR4 = VAR2.recv(VAR7.size)
        unpacked_data = VAR7.unpack(VAR4)
        print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(49)+chr(32)+chr(115)+chr(101)+chr(110)+chr(100)+chr(44)+chr(32)), end=str())
        VAR4 = VAR6.pack(str(chr(71)+chr(69)+chr(84)).encode(), str().join(random.choices(string.ascii_uppercase + string.digits, k=5)).encode())
        VAR1.sendall(VAR4)
        print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(49)+chr(32)+chr(114)+chr(101)+chr(99)+chr(118)+chr(44)+chr(32)), end=str())
        VAR4 = VAR1.recv(VAR7.size)
        unpacked_data = VAR7.unpack(VAR4)
        print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(49)+chr(32)+chr(100)+chr(105)+chr(115)+chr(99)+chr(111)+chr(110)+chr(110)+chr(101)+chr(99)+chr(116)+chr(44)+chr(32)), end=str())
        print(str(chr(67)+chr(108)+chr(105)+chr(101)+chr(110)+chr(116)+chr(50)+chr(32)+chr(100)+chr(105)+chr(115)+chr(99)+chr(111)+chr(110)+chr(110)+chr(101)+chr(99)+chr(116)+chr(44)+chr(32)), end=str())
    except ConnectionRefusedError:
        print(str("\n"+"\n"+chr(70)+chr(65)+chr(73)+chr(76)+chr(69)+chr(68)+chr(32)+chr(45)+chr(32)+chr(78)+chr(101)+chr(109)+chr(32)+chr(108)+chr(101)+chr(104)+chr(101)+chr(116)+chr(32)+chr(107)+chr(97)+chr(112)+chr(99)+chr(115)+chr(111)+chr(108)+chr(111)+chr(100)+chr(110)+chr(105)+chr(32)+chr(97)+chr(32)+chr(115)+chr(101)+chr(114)+chr(118)+chr(101)+chr(114)+chr(114)+chr(101)+chr(33)+chr(32)) + str(VAR8))
        sys.exit(1)
    except error as e:
        print(str("\n"+"\n"+chr(70)+chr(65)+chr(73)+chr(76)+chr(69)+chr(68)))
        print(VAR5)
        sys.exit(1)
    else:
        print(str("\n"+"\n"+chr(79)+chr(75)+chr(32)+chr(45)+chr(32)+chr(67)+chr(97)+chr(110)+chr(118)+chr(97)+chr(115)+chr(32)+chr(107)+chr(111)+chr(100)+chr(58)+chr(32)), FUNC1(VAR3 + str(chr(116)+chr(54)).encode()))
print(str(chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)+chr(35)))
