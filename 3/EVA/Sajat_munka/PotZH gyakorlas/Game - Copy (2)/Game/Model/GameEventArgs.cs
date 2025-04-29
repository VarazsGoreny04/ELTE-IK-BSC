namespace EVA.Game.Model;
public class GameEventArgs : EventArgs
{
	private readonly int _gameTime;
	private readonly int _steps;
	private readonly bool _isWon;

	public int GameTime { get { return _gameTime; } }

	public int GameStepCount { get { return _steps; } }

	public bool IsWon { get { return _isWon; } }

	public GameEventArgs(bool isWon, int gameStepCount, int gameTime) 
	{ 
		_isWon = isWon;
		_steps = gameStepCount;
		_gameTime = gameTime;
	}
}
