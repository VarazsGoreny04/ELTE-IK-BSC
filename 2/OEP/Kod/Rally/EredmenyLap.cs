namespace Rally
{
	public class EredmenyLap
	{
		private Kategoria[] kat;
		public Csapat csapat;
		public Futam futam;
		public List<Eredmeny> eredmenyek;

		public EredmenyLap(Csapat c, Futam f, List<Eredmeny> eredmenyek, Kategoria[] kat)
		{
			csapat = c;
			futam = f;
			this.eredmenyek = eredmenyek;
			this.kat = kat;
		}
	}
}