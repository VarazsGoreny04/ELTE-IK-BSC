
namespace Snake;

public class Snake
{
	private readonly List<Coordinate> body;
	private Coordinate head;
	private Direction direction;

	public List<Coordinate> Body => body;
	public Coordinate Head => head;
	public Direction Direction => direction;

	public Snake(Coordinate head)
	{
		body = new List<Coordinate>();
		this.head = head;
		direction = Direction.RIGHT;

		for (int i = 2; i >= 0; --i)
			body.Add(new Coordinate(head.X - i, head.Y));
	}

	public void Move(Direction dir)
	{		
		if ((int)dir + (int)direction == 0)
			dir = direction;

		int x = head.X;
		int y = head.Y;

		switch (dir)
		{
			case Direction.UP: --y; break;
			case Direction.DOWN: ++y; break;
			case Direction.LEFT: --x; break;
			case Direction.RIGHT: ++x; break;
			default: throw new Exception();
		}

		/*int x = head.X + Math.Sign((int)dir) * (Math.Abs((int)dir) - 1);
		int y = head.Y + Math.Sign((int)dir) * Math.Abs(Math.Abs((int)dir) - 2);*/

		head = new Coordinate(x, y);
		direction = dir;

		body.Add(head);
		body.RemoveAt(0);
	}
}