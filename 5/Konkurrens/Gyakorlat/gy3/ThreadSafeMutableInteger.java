package gy3;

public class ThreadSafeMutableInteger {
	private int integer;

	public ThreadSafeMutableInteger(int integer) {
		this.integer = integer;
	}

	public ThreadSafeMutableInteger() {
		this.integer = 0;
	}

	public int get() {
		synchronized (this) {
			return integer;
		}
	}

	public void set(int integer) {
		synchronized (this) {
			this.integer = integer;
		}
	}

	public int getAndIncrement() {
		return getAndAdd(1);
	}

	public int getAndDecrement() {
		return getAndAdd(-1);
	}

	public int getAndAdd(int v) {
		synchronized (this) {
			int res = this.integer;
			this.integer += v;
			return res;
		}
	}

	public int incrementAndGet() {
		return addAndGet(1);
	}

	public int decrementAndGet() {
		return addAndGet(-1);
	}

	public int addAndGet(int v) {
		synchronized (this) {
			this.integer += v;
			return integer;
		}
	}
}