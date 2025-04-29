namespace ELTE.Game.Persistence
{
	public class GameTable
	{
		private readonly uint _size;
		private readonly bool[,] _table;
		private int _block;
		private uint _score;
		private readonly Random _random;

		public readonly bool[][,] Blocks =
		[
			new bool[,]
			{
				{ true, false },
				{ true, false }
			},
			new bool[,]
			{
				{ true, true },
				{ false, false }
			},
			new bool[,]
			{
				{ true, false },
				{ true, true }
			},
			new bool[,]
			{
				{ true, true },
				{ false, true }
			}
		];
		public uint Size { get => _size; set { } }
		public bool[,] Table { get => _table; }
		public int Block { get => _block; set { } }
		public uint Score { get => _score; set { } }

		public GameTable()
		{
			_random = new Random();

			_size = 4;
			_table = new bool[_size, _size];
			_score = 0;
			NewBlock();
		}

		public void NewBlock()
		{
			_block = _random.Next(0, 4);
		}

		public void NewScore()
		{
			++_score;
		}

		public void NewScore(uint score)
		{
			_score = score;
		}
	}
}