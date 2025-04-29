using System.Drawing;

namespace EVA.Game.Persistence
{
	public class GameTable
	{
		#region Fields

		private readonly int _size;
		private bool[,] _table;
		private bool[,] _prevTable;

		#endregion

		#region Properties

		public int Size { get => _size; }
		public bool this[int x, int y] { get => _table[x, y]; set => _table[x, y] = value; }

		#endregion

		#region Constructors

		public GameTable() : this(12) { }

		public GameTable(int tableSize)
		{
			if (tableSize < 0)
				throw new ArgumentOutOfRangeException(nameof(tableSize), "The table size is less than 0.");

			_size = tableSize;
			_table = new bool[tableSize, tableSize];
			_prevTable = new bool[tableSize, tableSize];
		}

		#endregion

		#region Public methods

		public bool InTable(Point point)
		{
			return point.X >= 0 && point.X < _size && point.Y >= 0 && point.Y < _size;
		}

		public void FlipCell(Point point)
		{
			_table[point.X, point.Y] = !_table[point.X, point.Y];
		}

		public void FlipCells()
		{
			(_prevTable, _table) = (_table, _prevTable);

			for (int i = 0; i < _size; ++i)
			{
				for (int j = 0; j < _size; ++j)
				{
					_table[j, i] = DeadOrAlive(_prevTable, j, i);
				}
			}
		}

		public bool DeadOrAlive(bool[,] t, int x, int y)
		{
			int c = 0;

			for (int i = -1; i < 2; i++)
			{
				if (InTable(new Point(x + i, y + 1)) && t[x + i, y + 1])
					++c;
			}

			for (int i = -1; i < 2; i += 2)
			{
				if (InTable(new Point(x + i, y)) && t[x + i, y])
					++c;
			}

			for (int i = -1; i < 2; i++)
			{
				if (InTable(new Point(x + i, y - 1)) && t[x + i, y - 1])
					++c;
			}

			if (_table[x, y] && (c == 2 || c == 3))
			{
				return true;
			}
			else if (c == 3)
			{
				return true;
			}
			return false;
		}

		#endregion

		#region Private methods



		#endregion
	}
}
