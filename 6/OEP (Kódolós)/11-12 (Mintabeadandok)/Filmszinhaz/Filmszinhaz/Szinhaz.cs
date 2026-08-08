namespace Filmszinhaz
{
	public class CsoroException : Exception { }
	public class NincsIlyenTeremException : Exception { }

	public class Szinhaz
	{
		public readonly List<Vetitoterem> vetitotermek;
		private readonly List<Film> filmtar;

		public Szinhaz()
		{
			vetitotermek = new List<Vetitoterem>();
			filmtar = new List<Film>();
		}

		public string LegtobbetNezettFilm()
		{
			Film? max = filmtar.MaxBy(x => x.Nezettseg);
			return max == null ? "Nincs film a filmtárban" : (max.Nezettseg == 0 ? "Nincsenek még nézettségi adatok" : max.cim);
		}

		public void TeremNyitas(Vetitoterem vetito)
		{
			vetitotermek.Add(vetito);
			filmtar.AddRange(vetitotermek.SelectMany(v => v.eloadasok.Where(e => !filmtar.Any(f => f.cim == e.filmcim)).Select(e => new Film(e.filmcim))));
		}

		public void Lefoglal(string cim, Ido ido, Terem terem, Foglalas foglalas)
		{
			foreach (Vetitoterem vetito in vetitotermek)
			{
				Eloadas? keresett = vetito.KeresettEloadas(cim, ido, terem);
				if (keresett != null)
				{
					vetito.ValosUles(foglalas.ules);
					keresett.FoglalttaAllitas(foglalas);
					return;
				}
			}
			throw new NincsIlyenTeremException();
		}

		public void Lemondas(string cim, Ido ido, Terem terem, Foglalas foglalas)
		{
			foreach (Vetitoterem vetito in vetitotermek)
			{
				Eloadas? keresett = vetito.KeresettEloadas(cim, ido, terem);
				if (keresett != null)
				{
					keresett.ValosFoglalas(foglalas);
					keresett.SzabaddaAllitas(foglalas);
					return;
				}
			}
			throw new NincsIlyenTeremException();
		}

		public int JegyEladas(string cim, Ido ido, Terem terem, Foglalas foglalas, int penz)
		{
			foreach (Vetitoterem vetito in vetitotermek)
			{
				Eloadas? keresett = vetito.KeresettEloadas(cim, ido, terem);
				if (keresett != null)
				{
					int ar = Ar(vetito, foglalas);
					if (ar > penz)
						throw new CsoroException();
					keresett.EladottaAllitas(foglalas);
					filmtar.Find(x => x.cim == cim)!.PluszNezettseg();
					return ar;
				}
			}
			throw new NincsIlyenTeremException();
		}

		public static int Ar(Vetitoterem vetito, Foglalas foglalas)
		{
			return (int)(vetito.alapAr * ((100f - vetito.Szazalek(foglalas)) / 100f));
		}
	}
}