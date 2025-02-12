namespace Fisherman
{
	public struct Catch
	{
		public string time;
		public string spieces;
		public double weight;
		public double length;
	}
	public class Fisher
	{
		public string name { get; private set; }
		List<Catch> catches;
		public Fisher(string name)
		{ 
			this.name = name;
			catches = new List<Catch>();
		}
		public void Add(Catch c)
		{
			catches.Add(c);
		}
		public bool BigTimeAfterCarp
		{
			get
			{
				bool carp = false;
				int catfish = 0;
				foreach (Catch c in catches)
				{
					if (!carp && c.spieces == "ponty" && c.weight >= 1.0)
						carp = true;
					if (carp && c.spieces == "harcsa" && c.length >= 1d)
						catfish++;
				}
				return catfish >= 4;
			}
			private set { }
		}
	}
}
