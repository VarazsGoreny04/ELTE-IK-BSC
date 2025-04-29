using ELTE.Snake.Model;
using System.Drawing;

namespace ELTE.Snake.Persistence;
public class SnakeTable
{
	private readonly uint _size;
	private uint _score;
	private readonly List<Size> _directions;
	private Dir _direction;
	private Dir _lastDirection;
	private readonly List<Point> _walls;
	private List<Point> _snake;
	private Point _head;
	private Point _apple;

	public uint Size { get => _size; }
	public Dir Direction { get => _direction; set => _direction = value; }
	public Dir LastDirection { get => _lastDirection; set => _lastDirection = value; }
	public List<Point> Walls { get => _walls; }
	public List<Point> Snake { get => _snake; }
	public Point Apple { get => _apple; set => _apple = value; }
	public Point Head { get => _head; set => _head = value; }
	public uint Score { get => _score; set => _score = value; }

	public SnakeTable() : this(10) { }

	public SnakeTable(uint tableSize)
	{
		if (tableSize < 0)
			throw new ArgumentOutOfRangeException(nameof(tableSize), "The table size is less than 0.");

		_size = tableSize;
		_direction = Dir.Right;
		_lastDirection = Dir.Right;
		_walls = new List<Point>();
		_snake = new List<Point>();
		_directions = new List<Size>()
		{
			new(0, 1),
			new(-1, 0),
			new(0, -1),
			new(1, 0)
		};
	}

	public void InitializeSnake(uint tableSize)
	{
		int middle = (int)tableSize / 2;
		_head = new Point(middle + 2, middle);
		_snake = new List<Point>
		{
			new(middle - 2, middle),
			new(middle - 1, middle),
			new(middle, middle),
			new(middle + 1, middle),
			_head
		};
	}

	public void MoveHead(Dir dir)
	{
		_head += _directions[(int)dir];
	}

	public Point MoveTail()
	{
		Point tail = _snake[0];
		_snake.RemoveAt(0);
		return tail;
	}

	public void SetApplePosition(Point position)
	{
		_apple = position;
	}

	public void AddWall(Point point)
	{
		if (point.X < 0 || point.Y < 0 || point.X >= Size || point.Y >= Size || Walls.Contains(point) || Snake.Contains(point))
			throw new SnakeDataException($"Invalid index! ({point.X}, {point.Y})");

		Walls.Add(point);
	}

	public void AddWall(List<Point> point)
	{
		foreach (Point p in point)
			AddWall(p);
	}

	public void AddSnake(List<Point> point)
	{
		foreach (Point p in point)
		{
			if (p.X < 0 || p.Y < 0 || p.X >= Size || p.Y >= Size || Walls.Contains(p) || Snake.Contains(p))
				throw new SnakeDataException($"Invalid index! ({p.X}, {p.Y})");

			Snake.Add(p);
		}
	}
}