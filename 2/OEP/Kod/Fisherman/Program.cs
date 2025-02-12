namespace Fisherman
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
			InFile file = new InFile("input2.txt");
			while (file.Read(out Fisher fisher))
			{
				if (fisher.BigTimeAfterCarp)
					Console.WriteLine(fisher.name);
				else
					Console.WriteLine("Karcsi harcsa");
			}
		}
	}
}