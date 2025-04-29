dictionary = {
    "haziPont": { "max": 20, "elert": 20, "minimum": 0.5 },
    "zhPont": { "max": 20, "elert": 11, "minimum": 0.5 },
    "mininetPont": { "max": 15, "minimum": 0.5 }
}

grades = {
	2: 50,
	3: 60,
	4: 75,
	5: 85
}

pointsYouHave = dictionary["haziPont"]["elert"] + dictionary["zhPont"]["elert"]

print(f"Eddig szerzett pont: {pointsYouHave}\n\nKelleni fog még:")

for x in grades.items():
	print(f"{x[0]} : {x[1] - pointsYouHave}")