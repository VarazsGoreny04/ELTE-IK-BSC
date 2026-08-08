
namespace Kert
{
	public class Parcella
	{
		private Novenyfajta? fajta;
		private int ultetesiIdo;

		public void Ultet(Novenyfajta nov)
		{
			if (fajta != null)
				throw new Exception();

			fajta = nov;
			ultetesiIdo = Kertesz.JelenHonap();
		}

		public bool Beerik(int honap)
		{
			return fajta is not null && fajta.IsZoldseg() && honap - ultetesiIdo == fajta.EresiIdo;
		}

		public void Leszed()
		{
			fajta = null;
		}
	}
}