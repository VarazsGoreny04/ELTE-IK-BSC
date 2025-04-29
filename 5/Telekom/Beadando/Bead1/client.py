import sys
import json

dictionary = None
links = None
demands = None
duration = 0

orderNum = 1
inUse = []

def Main():
	global dictionary
	global links
	global demands

	with open(sys.argv[1], "r") as f:
		dictionary = json.load(f)

	links = dictionary["links"]
	demands = dictionary["simulation"]["demands"]

	for tick in range(1, dictionary["simulation"]["duration"]):
		OneTick(tick)

def OneTick(tick: int):
	global orderNum

	FreeCircuits(tick)

	for demand in demands:
		if (demand["start-time"] == tick):
			FindACircuit(tick, demand)
			orderNum += 1
			

def FindACircuit(tick: int, demand: dict):
	global dictionary
	global links
	global inUse

	neededCapacity = demand["demand"]
	a = demand["end-points"][0]
	b = demand["end-points"][-1]

	for route in dictionary["possible-circuits"]:
		if (a == route[0] and b == route[-1]):
			checked = []
			save = []

			for i in range(len(route) - 1):
				j = 0
				while (j < len(links) and 
					   not (links[j]["points"][0] == route[i] and
					   links[j]["points"][1] == route[i + 1] and
					   neededCapacity <= links[j]["capacity"])):
					j += 1
				
				if (j < len(links)):
					checked.append(j)

			if (len(checked) == len(route) - 1):
				for k in checked:
					links[k]["capacity"] -= neededCapacity
					save.append(tuple((demand["end-time"], k, neededCapacity)))

				inUse.append(((route[0], route[-1]), save))

				print(f"{orderNum}. igény foglalás: {a} <-> {b} st:{tick} - sikeres")
				return

	print(f"{orderNum}. igény foglalás: {a} <-> {b} st:{tick} - sikertelen")

def FreeCircuits(tick):
	global links

	for index in range(len(inUse)):
		used = False

		for data in inUse[index][1]:
			if (data[0] == tick):
				used = True
				links[data[1]]["capacity"] += data[2]

		if (used):
			global orderNum

			print(f"{orderNum}. igény felszabadítás: {inUse[index][0][0]} <-> {inUse[index][0][1]} st:{tick}")
			orderNum += 1

if __name__ == "__main__":
	Main()