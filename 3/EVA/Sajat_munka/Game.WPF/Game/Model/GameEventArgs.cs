namespace ELTE.Game.Model
{
	public class GameEventArgs : EventArgs
	{
		private readonly int _who;
		private readonly uint _score;

		public uint Score { get { return _score; } }

		public int Who => _who;

		public GameEventArgs(uint score, int who = 0)
		{
			_score = score;
			_who = who;
		}
	}
}