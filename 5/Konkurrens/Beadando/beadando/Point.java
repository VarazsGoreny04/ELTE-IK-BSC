package beadando;

public class Point {
	public int x;
	public int y;

	public Point(int x, int y) {
		this.x = x;
		this.y = y;
	}

	public static Point Add(Point a, Point b) {
		return new Point(a.x + b.x, a.y + b.y);
	}
}