namespace Rational;

internal class Program
{
	static void Main()
	{
		Rational a = new(3, 2);
		Rational b = new(6, 7);
		Rational c = new(6, 7);

		Set setA = new([a, b, c]);
		Set setB = new([b]);

		Set setC = Set.Difference(setA, setB);

		Console.WriteLine(setC);
	}
}