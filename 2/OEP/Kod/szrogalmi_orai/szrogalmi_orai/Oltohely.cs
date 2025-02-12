using System.Security.Cryptography.X509Certificates;
using szorgalmi_orai;

namespace COVID
{
	public class Oltohely
	{
		public string hely;
		public List<Paciens> regisztraltak = new List<Paciens>();
		public List<Vakcina> vakcinak = new List<Vakcina>();
		public void Beszerez(Vakcina v)
		{
			vakcinak.Add(v);
		}

		public void Regisztral(Paciens p)
		{
			if (regisztraltak.Contains(p))
				throw new Exception();
			else
				regisztraltak.Add(p);
		}

		public void Beolt(Paciens p, string n)
		{
			Vakcina vakcina = null!;
			foreach (Vakcina e in vakcinak)
			{
				if (e.Nev() == n)
				{
					vakcina = e;
					break;
				}
			}
			Paciens paciens = null!;
			foreach (Paciens e in regisztraltak)
			{
				if (e.taj == p.taj)
				{
					paciens = e;
					break;
				}
			}
			if (vakcina != null && paciens != null)
			{
				vakcinak.Remove(vakcina);
				Oltas o = new Oltas() { datum = DateTime.Now, vakcina = vakcina };
				paciens.oltasok.Add(o);
			}
        }

		public int Hanyankettot()
		{
			return regisztraltak.Count(e => e.Hanyoltas() >= 2);
		}
	}
}