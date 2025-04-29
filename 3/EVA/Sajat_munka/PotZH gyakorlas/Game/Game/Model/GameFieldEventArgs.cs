namespace EVA.Game.Model;
public class GameFieldEventArgs : EventArgs
{
	private readonly int _changedFieldX;
	private readonly int _changedFieldY;

	public int X { get { return _changedFieldX; } }
	public int Y { get { return _changedFieldY; } }

	public GameFieldEventArgs(int x, int y) 
	{
		_changedFieldX = x;
		_changedFieldY = y;
	}
}