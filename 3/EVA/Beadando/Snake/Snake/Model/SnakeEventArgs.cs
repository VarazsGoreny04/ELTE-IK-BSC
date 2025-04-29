namespace ELTE.Snake.Model;
public class SnakeEventArgs : EventArgs
{
	private readonly bool _emptyField;
	private readonly bool _isWon;
	private readonly uint _score;

	public bool EmptyField { get { return _emptyField; } }

	public uint Score { get { return _score; } }

	public bool IsWon { get { return _isWon; } }

	public SnakeEventArgs(bool isWon, uint score, bool emptyField)
	{
		_isWon = isWon;
		_score = score;
		_emptyField = emptyField;
	}
}