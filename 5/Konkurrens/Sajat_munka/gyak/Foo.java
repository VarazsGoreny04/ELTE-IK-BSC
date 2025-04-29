package gyak;

import java.util.List;

import java.util.ArrayList;
/* import java.util.Collections;
import java.util.HashMap;
import java.util.concurrent.BlockingQueue;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.LinkedBlockingQueue;
import java.util.concurrent.locks.Lock;
import java.util.concurrent.locks.ReentrantLock;

public class SleepDemo {

	public static void main(String[] args) throws Exception {
		BlockingQueue b = new LinkedBlockingQueue<>();

		List<Integer> a = Collections.synchronizedList(new ArrayList<Integer>());

		for (int i = 0; i < 100; ++i) {
			a.add(i);
		}

		for (int i = 0; i < a.size(); ++i) {
			System.out.println(a.get(i));
		}
	}

	public void method() throws InterruptedException, ArithmeticException {
		wait();
		notify();
		notifyAll();
		throw new ArithmeticException();
	}

	private final Lock lock = new ReentrantLock();
	private int balance;

	public int balance() throws InterruptedException {
		lock.lock();
		lock.lockInterruptibly();
		try {
			return balance;
		} finally {
			lock.unlock();
		}
	}
} */

public class Foo {
	int n = 4;
	List<Foo> others = new ArrayList<>();

	public void add(int on) {
		/* Foo other = new Foo();
		other. */n = on;
	}

	public static void main(String[] args) throws InterruptedException {
		final Foo foo = new Foo();
		foo.add(5);
		new Thread(() -> foo.add(9)).start();

		Thread.sleep(100);
		System.out.println(foo.n);
	}
}