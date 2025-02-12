namespace Filmszinhaz
{
	public class Ules
	{
		public int sor;
		public int szam;

		public Ules(char sor, int szam)
		{
			this.sor = sor - '@';
			this.szam = szam;
		}

		public static bool operator ==(Ules a, Ules b)
		{
			return (a.sor == b.sor) && (a.szam == b.szam);
		}
		public static bool operator !=(Ules a, Ules b)
		{
			return (a.sor != b.sor) || (a.szam != b.szam);
		}

		public override bool Equals(object? obj)
		{
			return ReferenceEquals(this, obj);
		}

		public override int GetHashCode()
		{
			throw new NotImplementedException();
		}
	}
}