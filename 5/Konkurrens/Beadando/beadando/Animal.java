package beadando;

import java.util.Random;

public abstract class Animal extends Area {
	protected static enum C {
		an,
		anT,
		apitulate,
	}

	protected static class Dir {
		public static Point North = new Point(0, 1);
		public static Point South = new Point(0, -1);
		public static Point East = new Point(1, 0);
		public static Point West = new Point(-1, 0);

		public static Point[] array = { North, East, South, West };
	}

	public static boolean go = true;
	private final int section;
	protected static final Random rnd = new Random();

	protected boolean active;
	protected Tile[][] farm;
	protected int name = 0;
	protected int direction;
	protected Point location;
	protected int refreshTime;

	public Animal(Tile[][] farm, Point location, int refreshTime) {
		this.section = (farm.length - 2) / 3;

		this.active = false;
		this.farm = farm;
		this.direction = rnd.nextInt(Dir.array.length);
		this.location = location;
		this.refreshTime = refreshTime;
	}

	@Override
	public void Run() {
		active = true;
		Thread self = new Thread(() -> Runable());

		self.start();
	}

	private void Runable() {
		while (active) {
			Move();
			try {
				Thread.sleep(refreshTime);
			} catch (Exception e) {
			}
		}
	}

	@Override
	public void Stop() {
		active = false;
	}

	public Tile GetTileAt(Point p) throws IndexOutOfBoundsException {
		return farm[p.x][p.y];
	}

	public boolean InnerCircle(Point p) {
		return p.x > (section) && p.x <= (2 * section) && p.y > (section) && p.y <= (2 * section);
	}

	protected abstract void Move();

	protected abstract C FrontCheck();

	protected abstract void Step(int directionNum);
}