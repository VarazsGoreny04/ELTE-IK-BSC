namespace Project_Real;

public class Program
{
	public static void Main()
	{
		/*CultureInfo.CurrentCulture = new CultureInfo("en-us");

		string num = "+134.15";
		Real f = num;

		Console.WriteLine(Real.MAXWHOLEINT);
		Console.WriteLine(Real.MAXFRACTIONINT);
		Console.WriteLine(Real.FRACTIONLENGTH);
		Console.WriteLine(string.Join(',', Real.HUNDRED));

		Console.WriteLine(float.Parse(num));
		Console.WriteLine(f.ToBinaryString());
		Console.WriteLine(f.ToString());

		bool[] a = [true, false, true, false, false, false, false, true];
		bool[] b = [false, true, true, true, false, false, true, false];
		bool[] c = [false, false, true, false, false, true, false, false];

		Console.WriteLine(Real.ToUInt(c));
		Console.WriteLine(Real.ToUInt(b));
		Console.WriteLine("-" + Real.ToUInt(Real.BitAbs(Real.BitSubstract(c, b, false).Item2)));*/

		/*Real r1 = "-5.3";
		Real r2 = "+3.6";
		Console.WriteLine(r2 - r1);
		Console.WriteLine();

		Real f1 = "+0.1";
		Real f2 = "+0.2";
		Real f3 = "+0.3";
		double f4 = 0.1;
		double f5 = 0.2;
		double f6 = 0.3;
		Console.WriteLine($" ({f4})  +  ({f5})  =  ({f6})  ->  ({f4})  +  ({f5})  ==  ({f4 + f5}) => {f4 + f5 == f6}");
		Console.WriteLine($"({f1}) + ({f2}) = ({f3}) -> ({f1}) + ({f2}) == ({f1 + f2})                => {f1 + f2 == f3}");


		bool[] b = [false, true, false, true, false, false, false, false];
		bool[] c = [true, true, false, false, false, false, false, false];*/

		//,Console.WriteLine(string.Join(',', Real.BitMultiply(b, c)));
		Console.ReadKey();
		Console.WriteLine();

		//Natural nat = "16999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999";
		//double cica = 16999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999d;
		Natural nat2 = "128";

		/*Console.WriteLine(cica == cica + 128);
		Console.WriteLine(nat);
		Console.WriteLine(nat == Natural.Add(nat, nat2));*/

		Console.WriteLine(Natural.Trim(nat2 - (nat2 + new Natural("1"))));
		Console.WriteLine(Natural.Trim(new Natural("0001000")));

		Integer i1 = "-100";
		Integer i2 = "2";

		Console.WriteLine(i1 + i2);
	}
}