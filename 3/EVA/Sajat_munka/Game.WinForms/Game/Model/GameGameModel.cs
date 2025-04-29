using ELTE.Game.Persistence;
using System.Diagnostics;
using System.Drawing;

namespace ELTE.Game.Model
{
	public class GameGameModel(IGameDataAccess dataAccess)
	{
		private readonly IGameDataAccess _dataAccess = dataAccess;
		private GameTable _table = new();

		public GameTable Table { get { return _table; } }

		public event EventHandler<GameEventArgs>? EndGame;

		public void NewGame()
		{
			_table = new GameTable();

		}
		private void DestroyBlocks()
		{
			bool[,] filled = new bool[2, _table.Size];

			for (int i = 0; i < 4; ++i)
			{
				int rowCounter = 0, colCounter = 0;
				for (int j = 0; j < 4; ++j)
				{
					if (_table.Table[i, j])
						++colCounter;
					if (_table.Table[j, i])
						++rowCounter;
				}

				if (colCounter == 4)
					filled[0, i] = true;
				if (rowCounter == 4)
					filled[1, i] = true;

			}
			for (int i = 0; i < 4; ++i)
			{
				if (filled[0, i])
				{
					for (int j = 0; j < 4; ++j)
					{
						_table.Table[i, j] = false;
					}
				}
				if (filled[1, i])
				{
					for (int j = 0; j < 4; ++j)
					{
						_table.Table[j, i] = false;
					}
				}
			}
		}

		private bool IsGameOver()
		{
			for (int i = 0; i < 4; ++i)
			{
				for (int j = 0; j < 4; ++j)
				{
					#region Egy blokk egy helyre letevésének a vizsgálata

					if (!_table.Table[j, i])
					{
						try
						{
							bool canPlace = true;
							for (int k = 0; k < 2; ++k)
							{
								for (int l = 0; l < 2; ++l)
								{
									if (_table.Blocks[_table.Block][l, k] && _table.Table[j + k, i + l])
										canPlace = false;
								}
							}

							if (canPlace)
								return false;
						}
						catch { }
					}

					#endregion
				}
			}
			return true;
		}

		public bool PlaceBlock(Point p)
		{
			try
			{
				for (int i = 0; i < 2; ++i)
				{
					for (int j = 0; j < 2; ++j)
					{
						if (_table.Blocks[_table.Block][i, j] && _table.Table[p.X + j, p.Y + i])
						{
							return false;
						}
					}
				}

				for (int i = 0; i < 2; ++i)
				{
					for (int j = 0; j < 2; ++j)
					{
						if (_table.Blocks[_table.Block][i, j])
							_table.Table[p.X + j, p.Y + i] = _table.Blocks[_table.Block][i, j];
					}
				}

				DestroyBlocks();

				for (int i = 0; i < 4; ++i)
				{
					for (int j = 0; j < 4; ++j)
					{
						Debug.Write($"{Convert.ToInt16(_table.Table[j, i])} ");
					}
					Debug.WriteLine("");
				}
				Debug.WriteLine("");

				_table.NewBlock();
				_table.NewScore();
				
				if (IsGameOver())
					OnGameOver();

				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		public async Task LoadGame(string path)
		{
			try
			{
				_table = await _dataAccess.LoadAsync(path);
			}
			catch (GameDataException ex)
			{
				throw new GameDataException(ex.Message);
			}
		}
		
		public async Task SaveGame(string path)
		{
			try
			{
				await _dataAccess.SaveAsync(path, Table);
			}
			catch (GameDataException ex)
			{
				throw new GameDataException(ex.Message);
			}
		}

		private void OnGameOver()
		{
			EndGame?.Invoke(this, new GameEventArgs(_table.Score));
		}
	}
}