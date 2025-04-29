package beadando;

public class Tile {
	private Area area;

	public Tile(Area area) {
		this.area = area;
	}

	public Area GetArea() {
		return area;
	}

	public void SetArea(Area area) {
		this.area = area;
	}

	public void Run() {
		area.Run();
	}

	public void Stop() {
		area.Stop();
	}

	@Override
	public String toString() {
		return area.toString();
	}
}