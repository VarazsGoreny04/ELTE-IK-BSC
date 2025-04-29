package beadando;

import java.util.ArrayList;
import java.util.List;

public class Dog extends Animal {

	public Dog(Tile[][] farm, Point location, int number, int refreshTime) throws Exception {
		super(farm, location, refreshTime);

		if (number < 0 || number > 9 || InnerCircle(location))
			throw new Exception();

		name = number;
	}

	public void Move() {
		Point[] ps = new Point[4];

		ps[0] = Point.Add(location, new Point(-1, 0));
		ps[1] = Point.Add(location, new Point(0, -1));
		ps[2] = Point.Add(location, new Point(0, 1));
		ps[3] = Point.Add(location, new Point(1, 0));

		synchronized (GetTileAt(ps[0])) {
		synchronized (GetTileAt(ps[1])) {
		synchronized (GetTileAt(location)) {
		synchronized (GetTileAt(ps[2])) {
		synchronized (GetTileAt(ps[3])) {
			List<Integer> haventChecked = new ArrayList<Integer>(4);

			for (int i = 0; i < Dir.array.length; ++i)
				haventChecked.add(i);

			C frontCheck;

			while (haventChecked.size() > 0) {
				frontCheck = FrontCheck();

				if (frontCheck == C.an) {
					Step(direction);

					return;
				} else {
					haventChecked.remove(haventChecked.indexOf(direction));

					if (haventChecked.isEmpty())
						return;
				}

				if (frontCheck == C.anT)
					direction = haventChecked.get(rnd.nextInt(haventChecked.size()));
			}
		}}}}}
	}

	protected C FrontCheck() {
		Point front = (Point.Add(location, Dir.array[direction]));

		return farm[front.x][front.y].GetArea() instanceof Field ? C.an : C.anT;
	}

	protected void Step(int directionNum) {
		Point destination = Point.Add(location, Dir.array[directionNum]);
		Area temp = GetTileAt(destination).GetArea();

		if (temp instanceof Field) {
			GetTileAt(destination).SetArea(this);
			GetTileAt(location).SetArea(temp);
			this.location = destination;
		}
	}

	@Override
	public String toString() {
		return Integer.toString(name);
	}
}