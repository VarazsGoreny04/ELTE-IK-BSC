using ELTE.Snake.Persistence;
using System.Drawing;

namespace ELTE.Snake.Model;
public class SnakeGameModel
{
	private readonly ISnakeDataAccess _dataAccess;
	private SnakeTable _table;
	private readonly Random _random;

	public SnakeTable Table { get => _table; }

	public event EventHandler<SnakeFieldEventArgs>? Moving;
	public event EventHandler<SnakeEventArgs>? EndGame;
	public event EventHandler<SnakeEventArgs>? GameCreated;

	public SnakeGameModel(ISnakeDataAccess dataAccess)
	{
		_dataAccess = dataAccess;
		_table = new SnakeTable();
		_random = new Random();
	}

	public async Task NewGame(string path)
	{
		try
		{
			_table = await _dataAccess.LoadAsync(path);
		}
		catch (SnakeDataException ex)
		{
			throw new SnakeDataException(ex.Message);
		}

		OnGameCreated();
	}

	public async Task NewGame(uint tabelSize, string path)
	{
		try
		{
			_table = await _dataAccess.LoadAsync(tabelSize, path);
		}
		catch (SnakeDataException ex)
		{
			throw new SnakeDataException(ex.Message);
		}

		_table.Score = 0;

		NewApple();

		OnGameCreated();
	}

	public async Task SaveGameAsync(string path)
	{
		await _dataAccess.SaveAsync(path, _table);
	}

	public void SetDirection(Dir d)
	{
		if (Math.Abs(_table.LastDirection - d) != 2)
			_table.Direction = d;
	}

	private bool NewApple()
	{
		Point field;
		List<Point> emptyFields = new();

		for (int i = 0; i < _table.Size; ++i)
		{
			for (int j = 0; j < _table.Size; ++j)
			{
				field = new Point(i, j);

				if (!_table.Walls.Contains(field) && !_table.Snake.Contains(field))
					emptyFields.Add(field);
			}
		}

		if (emptyFields.Count == 0)
			return false;
		else
		{
			_table.SetApplePosition(emptyFields[_random.Next(emptyFields.Count)]);
			return true;
		}
	}

	private void CheckAndAdd()
	{
		if (_table.Snake.Contains(_table.Head) || _table.Walls.Contains(_table.Head) ||
		_table.Head.X < 0 || _table.Head.Y < 0 || _table.Head.X >= Table.Size || _table.Head.Y >= Table.Size)
		{
			OnGameOver();
			throw new IndexOutOfRangeException();
		}

		_table.Snake.Add(_table.Head);
	}

	public void Step()
	{
		try
		{
			_table.MoveHead(_table.Direction);

			if (_table.Head == _table.Apple)
			{
				CheckAndAdd();
				OnMoving(_table.Head, null);
				++_table.Score;
				OnCollectingApple(_table.Snake.Count + _table.Walls.Count == _table.Size * _table.Size, NewApple());
			}
			else
			{
				Point oldTail = _table.MoveTail();
				CheckAndAdd();
				OnMoving(_table.Head, oldTail);
			}
		}
		catch (IndexOutOfRangeException) { return; }

		_table.LastDirection = _table.Direction;
	}

	private void OnGameCreated()
	{
		GameCreated?.Invoke(this, new SnakeEventArgs(false, _table.Score, true));
	}

	private void OnMoving(Point head, Point? oldTail)
	{
		Moving?.Invoke(this, new SnakeFieldEventArgs(head, oldTail));
	}

	private void OnCollectingApple(bool isWon, bool emptyField)
	{
		EndGame?.Invoke(this, new SnakeEventArgs(isWon, _table.Score, emptyField));
	}

	private void OnGameOver()
	{
		EndGame?.Invoke(this, new SnakeEventArgs(false, _table.Score, false));
	}
}