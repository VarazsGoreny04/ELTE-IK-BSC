package gy3;

public class Main {
	public static void main(String[] args) throws InterruptedException {
		Thread[] threads = new Thread[20];
		ThreadSafeMutableInteger t = new ThreadSafeMutableInteger(1);

		for (int i = 0; i < 20; ++i) {
			threads[i] = new Thread(() -> {
				for (int j = 0; j < 50; ++j) {
					t.getAndIncrement();
					t.incrementAndGet();
				}
			});
			threads[i].start();
		}
		Thread.sleep(1000);
		System.out.println(t.get());
	}
}