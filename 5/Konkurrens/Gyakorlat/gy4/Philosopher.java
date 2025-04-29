package gy4;

public class Philosopher {
	private int index;
	private Fork[] forks;
	private boolean[] myForks;

	public Philosopher(int index, Fork[] forks) {
		this.index = index;
		this.forks = forks;
		myForks = new boolean[2];
	}

	public void Start() {
		while (true) {
			GetFork();
		}
	}

	private void GetFork() {
		myForks[0] = forks[index].Get();
		myForks[1] = forks[(index + 1) % forks.length].Get();

		
		if (myForks[0] && myForks[1])
			Eat();
		else
			Think();
	}

	private void Eat() {
		SleepForMsec(1);
		System.out.println("I am eating.");
	}

	private void Think() {
		SleepForMsec(1);
		System.out.println("I am thinking.");
	}

	public static void SleepForMsec(int msec) {
		try {
			Thread.sleep(msec);
		} catch (InterruptedException e) {

		}
	}
}