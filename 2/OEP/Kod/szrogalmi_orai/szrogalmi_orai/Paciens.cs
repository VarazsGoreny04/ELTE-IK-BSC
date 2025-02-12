using szorgalmi_orai;

namespace COVID
{
	public class Paciens
	{
		public string taj;
		public List<Oltas> oltasok = new List<Oltas>();

		public int Hanyoltas()
		{
			return oltasok.Count;
		}
	}
}