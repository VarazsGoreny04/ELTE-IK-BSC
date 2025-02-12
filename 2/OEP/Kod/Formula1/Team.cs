namespace Formula1
{
	public abstract class Team
	{
		public string name = null!;
		public int balance = 0;

        public Team(string name, int balance)
        {
			this.name = name;
			this.balance = balance;
        }

        protected List<People> members;
	}

	public class McLaren : Team
	{
        public McLaren() : base("McLaren", 15) { }

		public int Strength()
		{
			int sum = 0;
			members.ForEach(x => sum += x.Strength);
		}
	}

	public class Ferrari : Team
	{
		public Ferrari() : base("Ferrari", 21) { }
	}
}
