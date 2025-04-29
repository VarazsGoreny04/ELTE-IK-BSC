public class First {
	public static void main(String[] args) {
		Thread t1 = new PositiveThread();
		Thread t2 = new Thread(() -> {
			for (int i = 0; i <= 1_000; ++i)
				System.out.print(i + ", " + -i + ", ");
		});
		t1.start();
		t2.start();
	}
}

class PositiveThread extends Thread {
	@Override
	public void run() {
		for (int i = 0; i <= 1_000; ++i) {
			System.out.print(i + ", ");
		}
	}
}