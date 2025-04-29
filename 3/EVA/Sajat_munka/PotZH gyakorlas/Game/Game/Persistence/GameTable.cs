namespace EVA.Game.Persistence
{
	public class GameTable
	{
		#region Fields

		private readonly int _regionSize;
		private readonly int[,] _fieldValues;
		private readonly bool[,] _fieldLocks;

		#endregion

		#region Properties

		public bool IsFilled 
		{
			get
			{
				foreach (int value in _fieldValues)
					if (value == 0)
						return false;
				return true;
			}
		}

		public int RegionSize { get { return _regionSize; } }
		public int Size { get { return _fieldValues.GetLength(0); } }
		public int this[int x, int y] { get { return GetValue(x, y); } }

		#endregion

		#region Constructors

		public GameTable() : this(9, 3) { }

		public GameTable(int tableSize, int regionSize)
		{
			if (tableSize < 0)
				throw new ArgumentOutOfRangeException(nameof(tableSize), "The table size is less than 0.");
			if (regionSize < 0)
				throw new ArgumentOutOfRangeException(nameof(regionSize), "The region size is less than 0.");
			if (regionSize > tableSize)
				throw new ArgumentOutOfRangeException(nameof(regionSize), "The region size is grater than the table size.");
			if (tableSize % regionSize != 0)
				throw new ArgumentException("The table size is not a multiple of the region size.", nameof(regionSize));

			_regionSize = regionSize;
			_fieldValues = new int[tableSize, tableSize];
			_fieldLocks = new bool[tableSize, tableSize];
		}

		#endregion

		#region Public methods

		public bool IsEmpty(int x, int y)
		{
			if (x < 0 || x >= _fieldValues.GetLength(0))
				throw new ArgumentOutOfRangeException(nameof(x), "The X coordinate is out of range.");
			if (y < 0 || y >= _fieldValues.GetLength(1))
				throw new ArgumentOutOfRangeException(nameof(y), "The Y coordinate is out of range.");

			return _fieldValues[x, y] == 0;
		}

		public bool IsLocked(int x, int y)
		{
			if (x < 0 || x >= _fieldValues.GetLength(0))
				throw new ArgumentOutOfRangeException(nameof(x), "The X coordinate is out of range.");
			if (y < 0 || y >= _fieldValues.GetLength(1))
				throw new ArgumentOutOfRangeException(nameof(y), "The Y coordinate is out of range.");

			return _fieldLocks[x, y];
		}

		public int GetValue(int x, int y)
		{
			if (x < 0 || x >= _fieldValues.GetLength(0))
				throw new ArgumentOutOfRangeException(nameof(x), "The X coordinate is out of range.");
			if (y < 0 || y >= _fieldValues.GetLength(1))
				throw new ArgumentOutOfRangeException(nameof(y), "The Y coordinate is out of range.");

			return _fieldValues[x, y];
		}

		public void SetValue(int x, int y, int value, bool lockField) 
		{
			if (x < 0 || x >= _fieldValues.GetLength(0))
				throw new ArgumentOutOfRangeException(nameof(x), "The X coordinate is out of range.");
			if (y < 0 || y >= _fieldValues.GetLength(1))
				throw new ArgumentOutOfRangeException(nameof(y), "The Y coordinate is out of range.");
			if (value < 0 || value > _fieldValues.GetLength(0) + 1)
				throw new ArgumentOutOfRangeException(nameof(value), "The value is out of range.");
			if (_fieldLocks[x, y])
				return;
			if (!CheckStep(x, y))
				return;

			_fieldValues[x, y] = value;
			_fieldLocks[x, y] = lockField;
		}

		public void StepValue(int x, int y)
		{
			if (x < 0 || x >= _fieldValues.GetLength(0))
				throw new ArgumentOutOfRangeException(nameof(x), "The X coordinate is out of range.");
			if (y < 0 || y >= _fieldValues.GetLength(1))
				throw new ArgumentOutOfRangeException(nameof(y), "The Y coordinate is out of range.");

			if (_fieldLocks[x, y])
				return;

			do
			{
				_fieldValues[x, y] = (_fieldValues[x, y] + 1) % (_fieldValues.GetLength(0) + 1);
			}
			while (!CheckStep(x, y));
		}

		public void SetLock(int x, int y)
		{
			if (x < 0 || x >= _fieldValues.GetLength(0))
				throw new ArgumentOutOfRangeException(nameof(x), "The X coordinate is out of range.");
			if (y < 0 || y >= _fieldValues.GetLength(1))
				throw new ArgumentOutOfRangeException(nameof(y), "The Y coordinate is out of range.");

			_fieldLocks[x, y] = true;
		}

		#endregion

		#region Private methods

		/// <summary>
		/// Lépésellenőrzés.
		/// </summary>
		/// <param name="x">Vízszintes koordináta.</param>
		/// <param name="y">Függőleges koordináta.</param>
		/// <returns>Igaz, ha a lépés engedélyezett, különben hamis.</returns>
		private bool CheckStep(int x, int y)
		{
			if (_fieldValues[x, y] == 0)
				return true;
			else
			{
				// sor ellenőrzése:
				for (int i = 0; i < _fieldValues.GetLength(0); i++)
					if (_fieldValues[i, y] == _fieldValues[x, y] && x != i)
						return false;

				// oszlop ellenőrzése:
				for (int j = 0; j < _fieldValues.GetLength(1); j++)
					if (_fieldValues[x, j] == _fieldValues[x, y] && y != j)
						return false;

				// ház ellenőrzése:
				for (int i = _regionSize * (x / _regionSize); i < _regionSize * ((x / _regionSize) + 1); i++)
					for (int j = _regionSize * (y / _regionSize); j < _regionSize * ((y / _regionSize) + 1); j++)
					{
						if (_fieldValues[i, j] == _fieldValues[x, y] && x != i && y != j)
							return false;
					}

				return true;
			}
		}

		#endregion
	}
}
