package beadando;

import java.util.ArrayList;
import java.util.List;

public class Sheep extends Animal {
	public Sheep(Tile[][] farm, Point location, int number, int refreshTime) throws Exception {
		super(farm, location, refreshTime);

		if (number < 0 || number >= ('Z' - 'A') || !InnerCircle(location))
			throw new Exception();

		name = (int) 'A' + number;
	}

	protected void Move() {
		Point[] ps = new Point[9];

		{
			int i = 0;

			for (int j = -1; j <= 1; ++j) {
				for (int k = -1; k <= 1; ++k) {
					ps[i++] = Point.Add(location, new Point(j, k));
				}
			}
		}

		synchronized (GetTileAt(ps[0])) {
			synchronized (GetTileAt(ps[1])) {
				synchronized (GetTileAt(ps[2])) {
					synchronized (GetTileAt(ps[3])) {
						synchronized (GetTileAt(ps[4])) {
							synchronized (GetTileAt(ps[5])) {
								synchronized (GetTileAt(ps[6])) {
									synchronized (GetTileAt(ps[7])) {
										synchronized (GetTileAt(ps[8])) {
											List<Integer> haventChecked = new ArrayList<Integer>(4);

											for (int i = 0; i < Dir.array.length; ++i)
												haventChecked.add(i);

											C frontCheck;

											while (!haventChecked.isEmpty()) {
												frontCheck = FrontCheck();

												if (frontCheck == C.an) {
													Step(direction);

													return;
												} else {
													haventChecked.remove(haventChecked.indexOf(direction));

													if (haventChecked.isEmpty())
														return;
												}

												if (frontCheck == C.apitulate) {
													direction = (direction + 2) % Dir.array.length;

													if (!haventChecked.contains(direction))
														return;
												} else if (frontCheck == C.anT) {
													direction = haventChecked.get(rnd.nextInt(haventChecked.size()));
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
	}

	protected C FrontCheck() {
		Point[] front = new Point[3];

		front[0] = (Point.Add(location, Dir.array[direction]));
		front[1] = new Point(
				Dir.array[direction].x == 0 ? front[0].x + 1 : front[0].x,
				Dir.array[direction].y == 0 ? front[0].y + 1 : front[0].y);
		front[2] = new Point(
				Dir.array[direction].x == 0 ? front[0].x - 1 : front[0].x,
				Dir.array[direction].y == 0 ? front[0].y - 1 : front[0].y);

		for (int i = 0; i < front.length; ++i) {
			if (GetTileAt(front[i]).GetArea() instanceof Dog)
				return C.apitulate;
		}

		Area temp = GetTileAt(front[0]).GetArea();
		if (temp instanceof Fence || temp instanceof Sheep)
			return C.anT;

		return C.an;
	}

	protected void Step(int directionNum) {
		Point destination = Point.Add(location, Dir.array[directionNum]);
		Area temp = GetTileAt(destination).GetArea();

		if (temp instanceof Gate) {
			GetTileAt(location).SetArea(new Field());
			this.location = destination;
			Stop();

			BrokeTheGate();
		} else if (temp instanceof Field) {
			GetTileAt(destination).SetArea(this);
			GetTileAt(location).SetArea(temp);
			this.location = destination;
		}
	}

	public void BrokeTheGate() {
		go = false;
		try {
			Runtime.getRuntime().exec("cls");
		} catch (Exception e) {
		}

		StringBuilder sb = new StringBuilder();

		sb.append("\n\n\n\"");
		sb.append(toString());
		sb.append("\" has broke the gate!\n");

		System.out.println(sb.toString());
	}

	@Override
	public String toString() {
		return Character.toString((char) name);
	}
}