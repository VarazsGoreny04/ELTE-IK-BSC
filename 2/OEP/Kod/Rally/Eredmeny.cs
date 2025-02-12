namespace Rally
{
	abstract public class Eredmeny
	{
		public Kategoria kat;
		public int hely;

		public Eredmeny(Kategoria kat, int hely)
		{
			this.kat = kat;
			this.hely = hely;
		}
	}
}