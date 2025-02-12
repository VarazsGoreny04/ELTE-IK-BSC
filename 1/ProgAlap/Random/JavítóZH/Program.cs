namespace JavítóZH
{
	internal class Program
	{
		static void Main()
		{
			int n = 0, k = 0;
			Data(ref n, ref k);
			int[] red = new int[n];
			int[] green = new int[n];
			Input(red, green, n);
			First(red, green, n);
			Second(red, green, n, k);
			Third(red, green, n);
		}
		static void Data(ref int n, ref int k)
		{
			Console.Error.WriteLine("Adja meg a mérési pontok számát és a K értékét:");
			bool error = false;
			do
			{
				if (error)
					Console.Error.WriteLine("Hibás bemeneti adat!");
				string[] parts = Console.ReadLine().Split();
				error = parts.Length != 2 || !int.TryParse(parts[0], out n) || n < 1 || n > 100 || !int.TryParse(parts[1], out k) || k < 1 || k > 10;
			} while (error);
		}
		static void Input(int[] r, int[] g, int n)
		{
			Console.Error.WriteLine("Adja meg a piros autók adatait:");
			for (int i = 0; i < n; i++)
			{
				bool error;
				do
				{
					error = !int.TryParse(Console.ReadLine(), out r[i]) || r[i] < 1;
					if (error)
						Console.Error.WriteLine("Hibás bemeneti adat!");
				} while (error);
			}
			Console.Error.WriteLine("Adja meg a zöld autók adatait!");
			for (int i = 0; i < n; i++)
			{
				bool error;
				do
				{
					error = !int.TryParse(Console.ReadLine(), out g[i]) || g[i] < 1;
					if (error)
						Console.Error.WriteLine();
				} while (error);
			}
		}
		static void First(int[] r, int[] g, int n)
		{
			int minpoint = 1;
			int mindb = r[0] + g[0];
			for (int i = 1; i < n; i++)
			{
				if (r[i] + g[i] < mindb)
				{
					mindb = r[i] + g[i];
					minpoint = i + 1;
				}
			}
			Console.WriteLine($"{minpoint} : {mindb}");
		}
		static void Second(int[] r, int[] g, int n, int k)
		{
			int i  = 0;
			while (i < n && g[i] <= r[i] * k)
			{
				i += 1;
			}
			bool volt = i <= n;
			if (volt)
			{
				int sokzold = i;
				Console.WriteLine($"{volt} : {sokzold}");
			}
		}
		static void Third(int[] r, int[] g, int n)
		{
			int[] pirostobb = new int[n];
			int pirostobbdb = -1;
			for (int i = 0; i < n; i++)
			{
				if (r[i] > g[i])
				{
					pirostobbdb += 1;
					pirostobb[pirostobbdb] = i + 1; 
				}
			}
			Console.Write(pirostobbdb);
			for (int i = 0; i <= pirostobbdb; i++)
			{
				Console.Write($" {pirostobb[i]}");
			}
		}
	}
}