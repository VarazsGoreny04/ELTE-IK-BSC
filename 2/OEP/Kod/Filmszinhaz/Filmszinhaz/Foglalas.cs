namespace Filmszinhaz
{
	public enum Tipus
	{
		GYEREK,
		DIAK,
		FELNOTT,
		NYUGDIJAS,
		TORZSTAG
	}
	public abstract class Foglalas
	{
		public readonly string nev;
		public readonly Ules ules;
		public Allapot allapot;
		public Tipus tipus;

		public Foglalas(string nev, Ules ules)
		{
			this.nev = nev;
			this.ules = ules;
			allapot = Allapot.SZABAD;
		}

		public static bool operator ==(Foglalas a, Foglalas b)
		{
			return a.nev == b.nev && a.ules == b.ules && a.tipus == b.tipus;
		}
		public static bool operator !=(Foglalas a, Foglalas b)
		{
			return a.nev != b.nev || a.ules != b.ules || a.tipus != b.tipus;
		}

		public override bool Equals(object? obj)
		{
			return ReferenceEquals(this, obj);
		}

		public override int GetHashCode()
		{
			throw new NotImplementedException();
		}

		public abstract int KozepAr();
		public abstract int NagyAr();
	}

	public class Gyerek : Foglalas
	{
		public Gyerek(string nev, Ules ules) : base(nev, ules)
		{
			tipus = Tipus.GYEREK;
		}

		public override int KozepAr() { return 40; }
		public override int NagyAr() { return 40; }
	}

	public class Diak : Foglalas
	{
		public Diak(string nev, Ules ules) : base(nev, ules)
		{
			tipus = Tipus.DIAK;
		}

		public override int KozepAr() { return 30; }
		public override int NagyAr() { return 20; }
	}

	public class Felnott : Foglalas
	{
		public Felnott(string nev, Ules ules) : base(nev, ules)
		{
			tipus = Tipus.FELNOTT;
		}

		public override int KozepAr() { return 10; }
		public override int NagyAr() { return 0; }
	}

	public class Nyugdijas : Foglalas
	{
		public Nyugdijas(string nev, Ules ules) : base(nev, ules)
		{
			tipus = Tipus.NYUGDIJAS;
		}

		public override int KozepAr() { return 30; }
		public override int NagyAr() { return 20; }
	}

	public class Torzstag : Foglalas
	{
		public Torzstag(string nev, Ules ules) : base(nev, ules)
		{
			tipus = Tipus.TORZSTAG;
		}

		public override int KozepAr() { return 30; }
		public override int NagyAr() { return 30; }
	}
}