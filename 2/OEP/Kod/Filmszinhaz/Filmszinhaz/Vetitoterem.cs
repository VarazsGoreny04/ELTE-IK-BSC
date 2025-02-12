namespace Filmszinhaz
{
	public enum Terem
	{
		KOZEPES,
		NAGY,
		VIP
	}

	public class NemTaroltFilmException : Exception { }
	public class UtkozoEloadasException : Exception { }
	public class NemLetezoUlesException : Exception { }

	abstract public class Vetitoterem
	{
		public readonly int sorokSzama;
		public readonly int ulesSorban;
		public readonly int alapAr;
		public readonly List<Eloadas> eloadasok;

		public Vetitoterem(int alapAr, int sorokSzama, int ulesSorban)
		{
			this.sorokSzama = sorokSzama;
			this.ulesSorban = ulesSorban;
			this.alapAr = alapAr;
			eloadasok = new List<Eloadas>();
		}

		public virtual bool Kozepes() { return false; }
		public virtual bool Nagy() { return false; }
		public virtual bool VIP() { return false; }

		public virtual int Szazalek(Foglalas t) { return 0; }

		public void UjEloadas(Eloadas e)
		{
			if (eloadasok.Any(x => x.ido.kezdet <= e.ido.veg && x.ido.veg >= e.ido.kezdet))
				throw new UtkozoEloadasException();
			else
			{
				e.maxHely = sorokSzama * ulesSorban;
				eloadasok.Add(e);
			}
		}

		public void ValosUles(Ules ules)
		{
			if (ules.sor < 1 || ules.sor > sorokSzama || ules.szam < 1 || ules.szam > ulesSorban)
				throw new NemLetezoUlesException();
		}

		public Eloadas? KeresettEloadas(string cim, Ido ido, Terem terem)
		{
			bool joTerem = terem switch
			{
				Terem.KOZEPES => Kozepes(),
				Terem.NAGY => Nagy(),
				Terem.VIP => VIP(),
				_ => throw new NotImplementedException()
			};
			if (joTerem)
				return eloadasok.FirstOrDefault(x => x.filmcim == cim && x.ido == ido);
			else
				return null;
		}
	}

	public class KozepesTerem : Vetitoterem
	{
		public KozepesTerem(int alapAr, int sorokSzama, int ulesSorban) : base(alapAr, sorokSzama, ulesSorban) { }

		public override bool Kozepes() { return true; }

		public override int Szazalek(Foglalas t) { return t.KozepAr(); }
	}

	public class NagyTerem : Vetitoterem
	{
		public NagyTerem(int alapAr, int sorokSzama, int ulesSorban) : base(alapAr, sorokSzama, ulesSorban) { }

		public override bool Nagy() { return true; }
		public override int Szazalek(Foglalas t) { return t.NagyAr(); }
	}

	public class VIPTerem : Vetitoterem
	{
		public VIPTerem(int alapAr, int sorokSzama, int ulesSorban) : base(alapAr, sorokSzama, ulesSorban) { }

		public override bool VIP() { return true; }
	}
}