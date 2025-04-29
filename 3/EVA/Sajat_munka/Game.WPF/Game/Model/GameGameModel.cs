using ELTE.Game.Persistence;
using System.Drawing;

namespace ELTE.Game.Model
{
	public class GameGameModel
	{
		private readonly IGameDataAccess _dataAccess;
		private GameTable _table;

		public GameTable Table { get { return _table; } }

		//public event EventHandler<GameFieldEventArgs>? Moving;
		public event EventHandler<GameEventArgs>? EndGame;
		// public event EventHandler<GameEventArgs>? GameCreated;

		public GameGameModel(IGameDataAccess dataAccess)
		{
			_dataAccess = dataAccess;
			_table = null!;
		}

		public void NewGame(uint tableSize)
		{
			_table = new GameTable(tableSize);
		}

		public async Task SaveGame(string path)
		{
			try
			{
				await _dataAccess.SaveAsync(path, _table);
			}
			catch (GameDataException ex)
			{
				throw new GameDataException(ex.Message);
			}
			// OnGameCreated();
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

			// OnGameCreated();
		}

		/*private void OnGameCreated()
		{
			GameCreated?.Invoke(this, new GameEventArgs(_score));
		}*/

		/*private void OnMoving(Point newPoint, Point oldPoint)
		{
			Moving?.Invoke(this, new GameFieldEventArgs(newPoint, oldPoint));
		}*/

		private void OnGameOver()
		{
			EndGame?.Invoke(this, new GameEventArgs(_table.Round));
		}

		public bool Step(Point move)
		{
			if (_table.Round >= _table.Size * _table.Size)
			{
				OnGameOver();
				return false;
			}

			if (_table.Place(move))
			{
				_table.NewRound();
				_table.GenPlayers((int)_table.Round);
				return true;
			}
			return false;
		}
	}
}