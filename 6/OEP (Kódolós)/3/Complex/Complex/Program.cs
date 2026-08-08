namespace Complex
{
	internal class Program
	{
		static void Main()
		{
			Complex a = new Complex(3, 2);
			Complex b = new Complex(2, 1);

            Console.WriteLine($"Add: {(Complex.Add(a, b)).ToString()}");
            Console.WriteLine($"Sub: {Complex.Sub(a, b)}");
            Console.WriteLine($"Mul: {Complex.Mul(a, b)}");
            Console.WriteLine($"Div: {Complex.Div(a, b)}");
        }
	}
}