using System;
using System.Collections.Generic;

namespace _5._hazi_feladat
{
	internal class Program
	{
		static bool lengthError = false, dataError = false, Error = false;
		static int point;
		static string[] piece = new string[] { };
		static int[] start = new int[2];
		struct Competitor
		{
			public string name;
			public int result;
		}
		static List<Competitor> competitors = new();
		static List<int> award = new();
		static int[] howMany = new int[] { 0, 0, 0, 0 };
		static void Main(string[] args)
		{
			Input();
			Output();
		}
		static void Input()
		{
			Console.Error.WriteLine("Add meg a versenyzők számát és a maximálisan elérhető pontszámot!");
			do
			{
				piece = Console.ReadLine().Split();
				if (piece.Length == 2)
				{
					for (int i = 0; i < 2; i++)
					{
						lengthError = !int.TryParse(piece[i], out start[i]);
					}
					dataError = start[0] > 100 || start[0] < 1 || start[1] > 100 || start[1] < 1;
					Error = dataError || lengthError;
					if (Error)
						Console.Error.WriteLine("Nem megfelelő adattípus! ({1<=numberOfCompetitors<=100} {1<=maxPont<=100})");
				}
				else
				{
					Error = true;
					Console.Error.WriteLine("Nem megfelelő a bevitt adatok hosszúsága! (2)");
				}
			} while (Error);
			do
			{
				for (int i = 0; i < start[0]; i++)
				{
					piece = Console.ReadLine().Split(';');
					if (piece.Length == 2)
					{
						Error = !int.TryParse(piece[1], out point) || point > 100 || point < 0;
						if (Error)
							Console.Error.WriteLine("Nem megfelelő adattípus! ({name} {0<=result<=100})");
						else
						{
							Competitor i1 = new Competitor { name = piece[0], result = point};
							competitors.Add(i1);
						}
					}
					else
						Console.Error.WriteLine("Nem megfelelő a bevitt adatok hosszúsága! (2)");
				}
			} while (Error);
		}
		static void Output()
		{
			for (int i = 0; i < competitors.Count; i++)
			{
				if (competitors[i].result >= 0.9 * start[1])
				{
					award.Add(1);
					++howMany[0];
				}
				else if (competitors[i].result >= 0.8 * start[1])
				{
					award.Add(2);
					++howMany[1];
				}
				else if (competitors[i].result >= 0.7 * start[1])
				{
					award.Add(3);
					++howMany[2];
				}
				else
				{
					award.Add(4);
					++howMany[3];
				}
			}
			for (int i = 1; i <= 4; i++)
			{
				Console.Write($"{howMany[i - 1]};");
				for (int j = 0; j < competitors.Count; j++)
				{
					if (award[j] == i)
						Console.Write($"{competitors[j].name};");
				}
				Console.WriteLine();
			}
		}
	}
}