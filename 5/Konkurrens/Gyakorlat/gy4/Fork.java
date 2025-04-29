package gy4;

public class Fork {
	public Object lock;

	public boolean Get() {
		synchronized (this) {
			return true;
		}
	}
}