namespace Purchase
{
	class Store
	{
		public Department foods;
		public Department technical;
		public readonly List<CustomerStat> customerStats;

		public Store(string fname, string tname)
		{
			foods = new Department(fname);
			technical = new Department(tname);
			customerStats = new List<CustomerStat>();
		}

		public void AddBuy(CustomerStat cs)
		{
			customerStats.Add(cs);
		}

		public void Write()
		{
			foreach (CustomerStat item in customerStats)
				Console.WriteLine('\n' + item.ToString());
		}
	}
}