using System;
using System.Collections.Generic;
namespace Múzeum
{
	internal class Program
	{
		static void Main()
		{
			int napok = 0, őrök = 0;
			Data(ref napok, ref őrök);
			int[,] mátrix = new int[őrök, 3];
			Input(mátrix, őrök);
			First(mátrix, őrök);
			List<int> eredmény = new();
			Second(mátrix, őrök, napok, eredmény);
			Third(eredmény);
			Fourth(eredmény);
		}
		static void Data(ref int napok, ref int őrök)
		{
			Console.Error.WriteLine("Adja meg a napok és a hozzájuk tartozó sorszámok számát:");
			bool error = false;
			do
			{
				if (error)
					Console.Error.WriteLine("Hibás értéket adott meg!");
				string[] part = Console.ReadLine().Split();
				error = part.Length != 2 || !int.TryParse(part[0], out napok) || !int.TryParse(part[1], out őrök) || napok < 1 || napok > 1000 || őrök < 1 || őrök > 1000;
			} while (error);
		}
		static void Input(int[,] matrix, int őrök)
		{
			Console.Error.WriteLine("Adja meg az adatokat:");
			for (int i = 0; i < őrök; ++i)
			{
				bool error;
				do
				{
					bool pError = false, lError;
					string[] peaces = Console.ReadLine().Split();
					if (lError = peaces.Length == 2)
					{
						for (int j = 0; j < 2; ++j)
						{
							if (!int.TryParse(peaces[j], out matrix[i, j]))
								pError = true;
						}
					}
					error = pError || !lError;
					if (error)
						Console.Error.WriteLine("Hibás értéket adott meg!");
				} while (error);
			}
		}
		static void First(int[,] matrix, int őrök)
		{
			int max = 0;
			for (int i = 0; i < őrök; i++)
			{
				int now = matrix[i, 1] - matrix[i, 0] + 1;
				if (now > max)
					max = now;
			}
			Console.WriteLine(max);
		}
		static void Second(int[,] matrix, int őrök, int napok, List<int> eredmény)
		{
			int számlaló;
			for (int i = 1; i <= napok; i++)
			{
				számlaló = 0;
				for (int j = 0; j < őrök; j++)
				{
					if (matrix[j,0] <= i && matrix[j,1] >= i)
						++számlaló;
				}
				eredmény.Add(számlaló);
				Console.Write($"{számlaló} ");
			}
		}
		static void Third(List<int> eredmény)
		{
			int maxInd = 0, max = 0;
			for (int i = 0; i < eredmény.Count; i++)
			{
				if (max < eredmény[i])
				{
					max = eredmény[i];
					maxInd = i;
				}
			}
			Console.WriteLine($"\n{maxInd + 1}");
		}
		static void Fourth(List<int> eredmény)
		{
			int max = 0, maxInd = 0, hossz = 0;
			for (int i = 0; i < eredmény.Count; i++)
			{
				if (eredmény[i] < 2)
					++hossz;
				else
				{
					if (max < hossz)
					{
						max = hossz;
						maxInd = i;
					}
					hossz = 0;
				}
			}
			if (max < hossz)
			{
				max = hossz;
				maxInd = eredmény.Count - 1;
			}
			Console.WriteLine($"{maxInd - max + 2} {maxInd + 1}");
		}
	}
}