namespace Snake_Maui;
public class SnakeUIntEventArgs : EventArgs
{
	private readonly uint _num;

	public uint Num { get { return _num; } }

	public SnakeUIntEventArgs(uint num)
	{
		_num = num;
	}
}