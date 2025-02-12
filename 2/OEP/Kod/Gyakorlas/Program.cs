namespace Gyakorlas
{
	internal class Program
	{
		static void Main(string[] args)
		{
			InFile file = new InFile("Burgers.txt");
			int sumSum = 0;
			while (file.Read(out Burger burgir))
			{
				Console.WriteLine($"{burgir.name} : {burgir.ten} : {burgir.total}");
				sumSum += burgir.total;
			}
            Console.WriteLine(sumSum);
        }
	}
}