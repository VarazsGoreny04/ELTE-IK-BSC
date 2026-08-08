namespace Rational;

internal class Program
{
	static void Main(string[] args)
	{
		/*Rational a = new(3, 2);
		Rational b = new(6, 7);
		Rational c = new(6, 7);

		Set setA = new([a, b, c]);*/

		//Set setC = Set.Difference(setA, setB);
		
		Set setB = new Set(Reader.ReadIn(args[0]));
		Console.WriteLine(setB);
	}
}