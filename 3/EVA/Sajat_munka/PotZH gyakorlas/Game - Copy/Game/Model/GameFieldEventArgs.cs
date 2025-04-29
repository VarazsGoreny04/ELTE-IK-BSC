namespace EVA.Game.Model;
public class GameFieldEventArgs : EventArgs
{
	private readonly int x;
	private readonly int y;

	public int X { get { return x; } }
	public int Y { get { return y; } }
	public System.Drawing.Point XY { get => new(X, Y); }

	public GameFieldEventArgs(int x, int y) 
	{
		this.x = x;
		this.y = y;
	}
}