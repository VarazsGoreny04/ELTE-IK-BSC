package gy2;

public class Resources {
	public static int goldLeftInMine = 12200;
	public static int goldInPocket = 0;
	public static int houseBuilt = 0;

	public static void mineGold() {
		if (goldLeftInMine >= Configuration.GOLDFOUND) {
			goldLeftInMine -= Configuration.GOLDFOUND;
			goldInPocket += Configuration.GOLDFOUND;
		}
	}

	public static void buildHouse() {
		if (goldInPocket >= Configuration.BUILDCOST) {
			goldInPocket -= Configuration.BUILDCOST;
			houseBuilt += 1;
		}
	}
}