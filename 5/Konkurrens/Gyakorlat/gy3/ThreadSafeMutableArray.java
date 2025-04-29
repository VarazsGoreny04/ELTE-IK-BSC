package gy3;

public class ThreadSafeMutableArray {
	private int[] data;
	private Object[] locks;

	public ThreadSafeMutableArray(int[] data) {
		this.data = java.util.Arrays.copyOf(data, data.length);
		locks = new Object[data.length];
		for (int i = 0; i < locks.length; ++i) {
			locks[i] = new Object();
		}
	}

	public int get(int index) {
		synchronized (locks[index]) {
			return data[index];
		}
	}

	public void set(int index, int value) {
		synchronized (locks[index]) {
			data[index] = value;
		}
	}
}
