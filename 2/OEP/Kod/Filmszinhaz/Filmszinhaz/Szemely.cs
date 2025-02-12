namespace Filmszinhaz
{
	public class Szemely
	{

		public readonly string nev;

		private int penz;

		public Szemely(string nev, int penz)
		{
			this.nev = nev;
			this.penz = penz;
		}

		public void Foglal(Szinhaz szinhaz, string cim, Ido ido, Terem terem, Foglalas foglalas)
		{
			szinhaz.Lefoglal(cim, ido, terem, foglalas);
		}

		public void Lemond(Szinhaz szinhaz, string cim, Ido ido, Terem terem, Foglalas foglalas)
		{
			szinhaz.Lemondas(cim, ido, terem, foglalas);
		}

		public void FoglalastFizet(Szinhaz szinhaz, string cim, Ido ido, Terem terem, Foglalas foglalas)
		{
			penz -= szinhaz.JegyEladas(cim, ido, terem, foglalas, penz);
		}

		public void HelybenFizet(Szinhaz szinhaz, string cim, Ido ido, Terem terem, Foglalas foglalas)
		{
			szinhaz.Lefoglal(cim, ido, terem, foglalas);
			penz -= szinhaz.JegyEladas(cim, ido, terem, foglalas, penz);
		}
	}
}