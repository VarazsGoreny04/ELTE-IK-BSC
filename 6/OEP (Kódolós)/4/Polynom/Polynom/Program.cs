namespace Polynom
{
	internal class Program
	{
		static void Main()
		{
			Polynom a = new Polynom(3, 2, 1);
			Polynom b = new Polynom(2, 1, 0);

            Console.WriteLine($"Add: {Polynom.Add(a, b).ToString()}");
            Console.WriteLine($"Add: {a + b}");
            Console.WriteLine($"Sub: {Polynom.Sub(a, b)}");
            Console.WriteLine($"Mul: {Polynom.Mul(a, 2)}");
			Console.WriteLine(a[1]);
            
        }
	}
}