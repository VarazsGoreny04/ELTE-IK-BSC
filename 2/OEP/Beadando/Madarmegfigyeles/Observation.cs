namespace Madarmegfigyeles
{
	public struct Bird
	{
		public string date;
		public string place;
		public string name;
		public int howMany;
	}
	public class Observation
	{
		public string spotter { get; private set; }
		private List<Bird> birdList;

		public string owlDate { get; private set; }
		public string owlPlace { get; private set; }
		public int maxSparrow { get; private set; }
		public string maxSparrowPlace { get; private set; }

		public Observation(string spotter)
		{
			this.spotter = spotter;
			birdList = new List<Bird>();

			owlDate = null!;
			owlPlace = null!;
			maxSparrow = 0;
			maxSparrowPlace = null!;
		}
		public void Add(Bird b)
		{
			birdList.Add(b);

			if (owlDate == null && b.name == "fülesbagoly")
			{
				owlDate = b.date;
				owlPlace = b.place;
			}
			else if (owlDate != null && b.name == "budapesti veréb" && b.howMany > maxSparrow)
			{
				maxSparrow = b.howMany;
				maxSparrowPlace = b.place;
			}
		}
	}
}