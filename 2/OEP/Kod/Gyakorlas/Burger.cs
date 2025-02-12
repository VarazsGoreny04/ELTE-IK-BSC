namespace Gyakorlas
{
	public struct Order
	{
		public string name;
		public int howMany;
		public int rating;
	}
	public class Burger
	{
		public string name { get; private set; }
		private List<Order> orders;

		public int ten { get; private set; }
		public int total
		{
			get
			{
				int sum = 0;
				foreach (Order o in orders)
					sum += o.howMany;
				return sum;
			}
			private set { }
		}

		public Burger(string name)
		{
			this.name = name;
			orders = new List<Order>();

			ten = 0;
		}
		public void Add(Order o)
		{
			orders.Add(o);
			if (o.rating == 10)
				++ten;
		}
	}
}
