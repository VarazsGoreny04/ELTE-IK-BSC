namespace ELTE.Game.Model
{
	public class GameEventArgs(uint score/*, bool isWon, bool emptyField*/) : EventArgs
	{
		private readonly uint _score = score;

		public uint Score { get { return _score; } }
	}
}