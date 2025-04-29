using System.Diagnostics;

namespace EVA.Game.Persistence
{
	public enum Corners
	{
		RT,
		RB,
		LB,
		LT
	}

	public class GameTable
	{
		#region Fields

		private readonly int _size;
		private readonly int[,] _table;

		#endregion

		#region Properties
		public int Size { get { return _size; } }
		public int this[int x, int y] { get { return _table[x, y]; } }

		#endregion

		#region Constructors

		public GameTable() : this(3) { }

		public GameTable(int size)
		{
			if (size < 0)
				throw new ArgumentOutOfRangeException(nameof(size), "The table size is less than 0.");

			_size = size;
			_table = new int[_size, 4];

			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < _size; j++)
				{
					_table[j, i] = i;
				}
			}
		}

		#endregion

		#region Public methods

		public void Rotate(Corners c) 
		{
			int half = (int)Math.Round((double)_size / 2) - 1;

			for (int i = 0; i <= half; i++)
			{
				(_table[half - i, ((int)c + 1) % 4], _table[half + i, (int)c]) = (_table[half + i, (int)c], _table[half - i, ((int)c + 1) % 4]);
			}
		}

		#endregion

		private void WriteTable()
		{
			Debug.WriteLine("");
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < _size; j++)
				{
					Debug.Write($"{_table[j, i]} ");
				}
				Debug.WriteLine("");
			}
		}
	}
}
