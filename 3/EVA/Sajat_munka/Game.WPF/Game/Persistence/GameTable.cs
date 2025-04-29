using System.Drawing;

namespace ELTE.Game.Persistence
{
	public class GameTable
	{
		private readonly uint _size;
		private readonly Random _random;
		private readonly int[,] _table;
		private List<int[,]> _players;
		private int[] _points;
		private uint _round;

		public uint Size { get { return _size; } private set { throw new NotImplementedException(); } }
		public int this[int x, int y] { get { return _table[x, y]; } }
		public List<int[,]> Players { get => _players; private set => _players = value; }
		public int[] Points { get => _points; private set => _points = value; }
		public uint Round { get { return _round; } private set { throw new NotImplementedException(); } }


		public GameTable(uint tableSize)
		{
			if (tableSize < 4)
				throw new ArgumentOutOfRangeException(nameof(tableSize), "The table size is less than 0.");

			_size = tableSize;
			_random = new Random();
			_table = new int[_size, _size];
			_players = new()
			{
				new int[3, 3],
				new int[3, 3]
			};
			GenPlayers(0);
			GenPlayers(1);
			_points = new int[2];
			_round = 0;
		}

		public void NewRound()
		{
			++_round;
		}

		public void SetRound(uint score)
		{
			_round = score;
		}

		public void AddScore(int score)
		{
			_points[_round % 2] += score;
		}

		public void GenPlayers(int round)
		{
			List<Point> list = new();
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					list.Add(new Point(j, i));
				}
			}

			int[,] _player = new int[3, 3];

			for (int i = 0; i < 5; i++)
			{
				int temp = _random.Next(0, list.Count);
				_player[list[temp].X, list[temp].Y] = round % 2 + 1;
				list.RemoveAt(temp);
			}

			_players[round % 2] = _player;
		}

		public bool Place(Point point)
		{
			int score = 0;
			if (point.X + 1 < _size && point.Y + 1 < _size && point.X - 1 >= 0 && point.Y - 1 >= 0)
			{
				for (int i = -1; i < 2; i++)
				{
					for (int j = -1; j < 2; j++)
					{
						if (_table[point.X + j, point.Y + i] == (_round + 1) % 2)
							++score;
						_table[point.X + j, point.Y + i] = _players[(int)_round % 2][j + 1, i + 1];
					}
				}
				AddScore(score);
				return true;
			}
			else
				return false;
		}
	}
}