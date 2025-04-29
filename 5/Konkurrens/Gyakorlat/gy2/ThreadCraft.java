package gy2;

import java.util.ArrayList;
import java.util.List;

public class ThreadCraft extends Thread {
	private static int num = 0;
	private static boolean run = true;

	public static void main(String[] args) {
		List<Thread> workers = new ArrayList<>();

		for (int i = 0; i < Configuration.MINERCOUNT; ++i) {
			workers.add(new Thread(() -> mineAction()));
		}

		for (int i = 0; i < Configuration.BUILDERCOUNT; ++i) {
			workers.add(new Thread(() -> buildAction()));
		}

		Thread logging = new Thread(() -> loggingAction());

		for (Thread thread : workers) {
			thread.start();
		}

		logging.start();

		sleepForMsec(15200);

		run = false;

		sleepForMsec(1000);
		System.out.println(++num + ". alma" +
				"\nGold left in mine: " + Resources.goldLeftInMine +
				"\nGold in pocket:" + Resources.goldInPocket +
				"\nHouse built: " + Resources.houseBuilt);
	}

	public static void mineAction() {
		while (run) {
			sleepForMsec(Configuration.MINETIME);
			Resources.mineGold();
		}
	}

	public static void buildAction() {
		while (run) {
			sleepForMsec(Configuration.BUILDTIME);
			Resources.buildHouse();
		}
	}

	public static void loggingAction() {
		while (run) {
			sleepForMsec(Configuration.LOGTIME);
			System.out.println(++num + ". day" +
					"\nGold left in mine: " + Resources.goldLeftInMine +
					"\nGold in pocket:" + Resources.goldInPocket +
					"\nHouse built: " + Resources.houseBuilt);
		}
	}

	public static void sleepForMsec(int msec) {
		try {
			Thread.sleep(msec);
		} catch (InterruptedException e) {

		}
	}
}