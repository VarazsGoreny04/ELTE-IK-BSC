package beadando;

import java.util.Random;
import java.util.Scanner;
import java.util.List;
import java.util.ArrayList;

public class Farm {
	public final int length;
	public final int refreshTime;
	private Tile[][] farm;

	public Farm() throws Exception {
		// Reading farm values
		Scanner scanner = new Scanner(System.in);

		int length = Read(scanner, "Length of farm (lowest is 14): ", 14);
		this.length = length % 3 == 2 && length > 13 ? length : 14;
		int sheepNumber = Read(scanner, "Number of sheeps (lowest is 1): ", 10);
		sheepNumber = sheepNumber > 0 ? sheepNumber : 10;
		int dogNumber = Read(scanner, "Number of dogs (lowest is 1): ", 5);
		dogNumber = dogNumber > 0 ? dogNumber : 5;
		int refreshTime = Read(scanner, "Refresh time (lowest is 200): ", 200);
		this.refreshTime = refreshTime > 199 ? refreshTime : 200;

		try {
			Runtime.getRuntime().exec("cls");
		} catch (Exception e) {
		}

		// Generating base farm (fence and fields)
		farm = new Tile[this.length][this.length];
		int lenInd = (this.length - 1);

		for (int x = 0; x < farm.length; ++x) {
			for (int y = 0; y < farm.length; ++y) {
				if (x == 0 || y == 0 || x == lenInd || y == lenInd)
					farm[x][y] = new Tile(new Fence());
				else
					farm[x][y] = new Tile(new Field());
			}
		}

		// Generating gates
		Random rnd = new Random();

		farm[0][rnd.nextInt(lenInd - 1) + 1] = new Tile(new Gate());
		farm[lenInd][rnd.nextInt(lenInd - 1) + 1] = new Tile(new Gate());
		farm[rnd.nextInt(lenInd - 1) + 1][0] = new Tile(new Gate());
		farm[rnd.nextInt(lenInd - 1) + 1][lenInd] = new Tile(new Gate());

		// Generating sheeps and dogs
		List<Point> sheepCoords = new ArrayList<Point>();
		List<Point> dogCoords = new ArrayList<Point>();

		{
			Animal helperDog = new Dog(farm, new Point(1, 1), 9, 200);

			for (int x = 1; x < farm.length - 1; ++x) {
				for (int y = 1; y < farm.length - 1; ++y) {
					if (!(farm[x][y].GetArea() instanceof Fence)) {
						Point current = new Point(x, y);

						if (helperDog.InnerCircle(current))
							sheepCoords.add(current);
						else
							dogCoords.add(current);
					}
				}
			}
		}

		Point point;

		for (int i = 0; i < sheepNumber; ++i) {
			point = sheepCoords.remove(rnd.nextInt(sheepCoords.size()));
			farm[point.x][point.y].SetArea(new Sheep(farm, point, i, this.refreshTime));
		}

		for (int i = 0; i < dogNumber; ++i) {
			point = dogCoords.remove(rnd.nextInt(dogCoords.size()));
			farm[point.x][point.y].SetArea(new Dog(farm, point, i, this.refreshTime));
		}
	}

	public static int Read(Scanner scanner, String question, int defaultValue) {
		System.out.print(question);

		try {
			String input = scanner.nextLine();

			return Integer.parseInt(input);
		} catch (Exception e) {
			return defaultValue;
		}
	}

	public void Run() {
		System.out.println("\033[H\033[2J");
		ShowFarm();

		for (int x = 0; x < farm.length; ++x) {
			for (int y = 0; y < farm.length; ++y) {
				farm[x][y].Run();
			}
		}

		try {
			Thread.sleep(100);

			while (Animal.go) {
				ShowFarm();
				Thread.sleep(200);
			}
		} catch (Exception e) {
		}

		Stop();

		StringBuilder sb = new StringBuilder();

		for (int x = 0; x < farm.length; ++x) {
			for (int y = 0; y < farm.length; ++y) {
				sb.append(farm[x][y].toString());
				sb.append(" ");
			}

			sb.append('\n');
		}

		System.out.println(sb.toString());
	}

	public void Stop() {
		for (int x = 0; x < farm.length; ++x) {
			for (int y = 0; y < farm.length; ++y)
				farm[x][y].Stop();
		}
	}

	public void ShowFarm() {
		StringBuilder sb = new StringBuilder();

		for (int x = 0; x < farm.length; ++x) {
			for (int y = 0; y < farm.length; ++y) {
				sb.append(farm[x][y].toString());
				sb.append(" ");
			}

			sb.append('\n');
		}

		System.out.println("\u001B[0;0H");
		System.out.println(sb.toString());
	}
}