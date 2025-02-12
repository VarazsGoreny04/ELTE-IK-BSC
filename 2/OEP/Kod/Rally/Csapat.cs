namespace Rally
{
	public class Csapat
	{
		private string azon;
		public List<EredmenyLap> lapok;

		public Csapat(string azon)
		{
			this.azon = azon;
			lapok = new List<EredmenyLap>();
		}
	}
}