namespace Rally
{
	public enum Kategoria
	{
		SPORT,
		TEHER,
		MOTOR
	}

	public class Verseny
	{
		public DateTime datum;
		public string helyszin;
		List<Futam> futamok;
		List<Csapat> csapatok;

		public Verseny(DateTime datum, string helyszin)
		{
			this.datum = datum;
			this.helyszin = helyszin;
			futamok = new List<Futam>();
			csapatok = new List<Csapat>();
		}

		public void Regisztral(Csapat t)
		{

		}
	}
}