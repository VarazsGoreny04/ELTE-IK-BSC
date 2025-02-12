namespace Filmszinhaz
{
	public class Film
	{
		public readonly string cim;
		public int Nezettseg { get; private set; }

		public Film(string cim)
		{
			this.cim = cim;
			Nezettseg = 0;
		}

		public void PluszNezettseg()
		{
			++Nezettseg;
		}
	}
}
