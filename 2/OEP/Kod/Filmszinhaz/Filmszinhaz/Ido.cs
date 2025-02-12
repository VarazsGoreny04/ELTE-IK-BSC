namespace Filmszinhaz
{
	public class Ido
	{
		public TimeSpan kezdet;
		public TimeSpan veg;

		public Ido(TimeSpan kezdet, TimeSpan veg)
		{
			this.kezdet = kezdet;
			this.veg = veg;
		}

		public static bool operator ==(Ido a, Ido b)
		{
			return (a.kezdet == b.kezdet) && (a.veg == b.veg);
		}
		public static bool operator !=(Ido a, Ido b)
		{
			return (a.kezdet != b.kezdet) || (a.veg != b.veg);
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