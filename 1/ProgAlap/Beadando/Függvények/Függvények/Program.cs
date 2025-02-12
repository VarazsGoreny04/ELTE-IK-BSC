namespace Függvények
{
	internal class Program
	{
		static bool par(string s, int i)
		{
			return s[i] == s[s.Length - i - 1]; 
		}
		static void Be_Egesz(out int n)
		{
			Console.WriteLine("Adj meg egy számot!");
			int.TryParse(Console.ReadLine(), out n);
		}
		static void Be_Szoveg(out string s)
		{
			Console.WriteLine("Adj meg egy szöveget!");
			s = Console.ReadLine();
		}
		static void Main(string[] args)
		{
			int a;
			string szam;
			bool PE;
			Console.WriteLine(par("1221", 0));
			Be_Egesz(out a);
			Console.WriteLine(a);
			Be_Szoveg(out szam);
			int i = 0;
			while (i < szam.Length / 2 && par(szam, i))
			{
				i++;
			}
			PE = i >= szam .Length / 2;
			if (PE)
				Console.WriteLine("A szám palindrom");
			else
				Console.WriteLine("A szám nem palindrom");
		}
	}
}