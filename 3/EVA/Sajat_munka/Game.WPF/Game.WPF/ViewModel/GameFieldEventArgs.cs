namespace Game.WPF.ViewModel
{
	public class GameFieldEventArgs : EventArgs
	{
		private int _tableSize;

		public int TableSize { get { return _tableSize; } }

		public GameFieldEventArgs(int tableSize)
		{
			_tableSize = tableSize;
		}
	}
}