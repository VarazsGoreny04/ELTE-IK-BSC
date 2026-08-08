namespace Tort;

internal class Program
{
	static void Main()
	{
		/*int one = 1;
		Console.WriteLine((one++ + one) / 2);
		Console.WriteLine(one);*/

		/*int[] cica = new int[1];

		Console.WriteLine(cica[1]);*/

		/*Rac r1 = new(2, 2);
		Rac r2 = new(42, 3);

		Console.WriteLine(r1 / r2);
		Console.WriteLine(1 / 3);*/

		/*Object o = new();

		o.Equals(o);
		o.ToString();*/

		Rac a = new(3, 2);
		Rac b = new(6, 7);
		Rac c = new(6, 7);

		Set setA = new([a, b, c]);
		Set setB = new([b]);

		Set setC = Set.Difference(setA, setB);

		Console.WriteLine(setC);
	}
}