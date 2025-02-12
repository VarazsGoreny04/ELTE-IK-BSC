namespace COVID
{
	abstract public class Vakcina
	{
		public DateTime lejar;

		public virtual string Nev()
		{
			return "vakcina";
		}

		public virtual int Ism()
		{
			return 0;
		}
	}

	public class Astrazeneca : Vakcina
	{
		public override string Nev()
		{
			return "astrazeneca";
		}

		public override int Ism()
		{
			return 81;
		}
	}

	public class Modena : Vakcina
	{
		public override string Nev()
		{
			return "modena";
		}

		public override int Ism()
		{
			return 21;
		}
	}

	public class Pfizer : Vakcina
	{
		public override string Nev()
		{
			return "pfizer";
		}

		public override int Ism()
		{
			return 28;
		}
	}
}