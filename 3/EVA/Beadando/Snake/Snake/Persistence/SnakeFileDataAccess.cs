using ELTE.Snake.Model;
using System.Drawing;

namespace ELTE.Snake.Persistence;
public class SnakeFileDataAccess : ISnakeDataAccess
{
	private readonly string? _directory = string.Empty;

	public SnakeFileDataAccess(string? saveDirectory = null)
	{
		_directory = saveDirectory;
	}

	public async Task<string> AsyncLineReader(StreamReader sr)
	{
		string line = await sr.ReadLineAsync() ?? string.Empty;
		return string.Concat(line.Where(c => !char.IsWhiteSpace(c)));
	}

	public List<Point> PointReader(string[] pieces)
	{
		List<Point> points = new();

		foreach (string piece in pieces)
		{
			if (piece == string.Empty)
				continue;

			string[] oneCoord = piece.Split(',');
			Point newWall;

			if (oneCoord.Length != 2)
				throw new SnakeDataException($"Invalid number of dimensions! ({piece})");
			else if (!int.TryParse(oneCoord[0], out int x) || !int.TryParse(oneCoord[1], out int y))
				throw new SnakeDataException($"Invalid format! ({oneCoord[0]}, {oneCoord[1]})");
			else if (points.Contains(newWall = new Point(x, y)))
				throw new SnakeDataException($"Can't put wall on a coordinate of the snake! ({oneCoord[0]}, {oneCoord[1]})");

			points.Add(newWall);
		}

		return points;
	}

	public async Task<SnakeTable> LoadAsync(uint tableSize, string path)
	{
		StreamReader sr;

		try
		{
			sr = new StreamReader(path);
		}
		catch
		{
			throw new SnakeDataException("File could not be found!");
		}

		try
		{
			int keyNum = -1;
			string line = string.Empty, key;

			while (!(sr.EndOfStream || keyNum == tableSize))
			{
				line = await AsyncLineReader(sr);
				key = string.Concat(line.TakeWhile(c => c != ':'));
				_ = int.TryParse(key, out keyNum);
			}

			string[] keyAndPoints = line.Split(':');

			if (keyNum != tableSize || keyAndPoints.Length < 2)
				throw new SnakeDataException("Map settings could not be found!");

			SnakeTable table = new(tableSize);

			table.InitializeSnake(table.Size);

			table.AddWall(PointReader(keyAndPoints[1].Split(';')));

			if (table.Walls.Count >= table.Size * table.Size + table.Snake.Count)
				throw new SnakeDataException("Too many walls!");

			return table;
		}
		catch (SnakeDataException ex)
		{
			throw new SnakeDataException(ex.Message);
		}
		finally
		{
			sr.Close();
		}
	}

	public async Task<SnakeTable> LoadAsync(string path)
	{
		if (!string.IsNullOrEmpty(_directory))
			path = Path.Combine(_directory, path);

		StreamReader sr;

		try
		{
			sr = new StreamReader(path);
		}
		catch
		{
			throw new SnakeDataException("File could not be found!");
		}

		try
		{

			uint keyNum = uint.Parse(await AsyncLineReader(sr));

			SnakeTable table = new(keyNum)
			{
				Score = uint.Parse(await AsyncLineReader(sr)),
				Apple = PointReader((await AsyncLineReader(sr)).Split(';'))[0]
			};

			List<Point> pointList = PointReader((await AsyncLineReader(sr)).Split(';'));
			table.Direction = (Dir)pointList[0].X;
			table.LastDirection = (Dir)pointList[0].Y;

			pointList = PointReader((await AsyncLineReader(sr)).Split(';'));
			table.AddWall(pointList);

			pointList = PointReader((await AsyncLineReader(sr)).Split(';'));
			table.AddSnake(pointList);
			table.Head = table.Snake[^1];

			if (table.Walls.Count >= table.Size * table.Size + table.Snake.Count)
				throw new SnakeDataException("Too many walls!");

			return table;
		}
		catch (SnakeDataException ex)
		{
			throw new SnakeDataException(ex.Message);
		}
		finally
		{
			sr.Close();
		}
	}

	public async Task SaveAsync(string path, SnakeTable table)
	{
		if (!string.IsNullOrEmpty(_directory))
			path = Path.Combine(_directory, path);

		StreamWriter sw;

		try
		{
			sw = new StreamWriter(path);
		}
		catch
		{
			throw new SnakeDataException("File could not be found!");
		}

		try
		{
			await sw.WriteLineAsync(Convert.ToString(table.Size));
			await sw.WriteLineAsync(Convert.ToString(table.Score));
			await sw.WriteLineAsync(Convert.ToString($"{table.Apple.X},{table.Apple.Y};"));
			await sw.WriteLineAsync(Convert.ToString($"{(int)table.Direction},{(int)table.LastDirection};"));

			foreach (Point wall in table.Walls)
				await sw.WriteAsync($"{wall.X},{wall.Y}; ");

			await sw.WriteLineAsync();

			foreach (Point snek in table.Snake)
				await sw.WriteAsync($"{snek.X},{snek.Y}; ");
		}
		catch (SnakeDataException ex)
		{
			throw new SnakeDataException(ex.Message);
		}
		finally
		{
			sw.Close();
		}
	}
}