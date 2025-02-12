using System;
using System.Collections.Generic;
namespace Mindig_jó_helyezést_elért_vitorlások
{
	internal class Program
	{
		static int[] data = new int[4];
		static List<int[]> S = new();
		static List<int> winnerS = new();
		static void Main(string[] args)
		{
			Input();
			Output();
		}
		static void Input()
		{
			string line;
			int i = 0;
			bool Error;
			bool[] listError = new bool[4];
			Console.Error.WriteLine("Adja meg a futamok,a helyezettek,\naz összetett versenybe beleszámító helyezések és a versenyzők számát!");
			do
			{
				line = Console.ReadLine();
				string[] pieces = line.Split();
				if (pieces.Length != 4)
				{
					Error = true;
					Console.Error.WriteLine("Nem megfelelő a bemeneti karakterlánc hosszúsága!");
				}
				else
				{
					for (int j = 0; j < 4; j++)
					{
						listError[j] = !int.TryParse(pieces[j], out data[j]);
					}
					Error = listError[0] || listError[1] || listError[2] || listError[3];
					if (Error)
						Console.Error.WriteLine("Nem megfelelő adattípus!");
					else
					{
						Error = true;
						if (1 > data[0] || data[0] > 100)
							Console.Error.WriteLine("A futamok száma csak 1-től 100-ig tartó szám lehet");
						else if (3 > data[1] || data[1] > 10)
							Console.Error.WriteLine("A helyezettek száma csak 3-tól 10-ig tartó szám lehet");
						else if (data[0] != 1 && (2 > data[2] || data[2] > data[0]) || data[0] == 1 && 2 > data[2]) 
							Console.Error.WriteLine("A összetett versenybe beleszámító helyezések száma csak 2-től a futamok számáig tartó szám lehet");
						else if (1 > data[3] || data[3] > 1000)
							Console.Error.WriteLine("A versenyzők száma csak 1-től 1000-ig tartó szám lehet");
						else
							Error = false;
					}
				}
			} while (Error);
			do
			{
				string[] pieces = Console.ReadLine().Split();
				if (false/*pieces.Length != data[1]*/)
					Console.Error.WriteLine("Nem megfelelő a bemeneti karakterlánc hosszúsága!");
				else
				{
					int[] oneLineOfS = new int[data[0]];
					int resultError = 0;
					for (int j = 0; j < data[1]; j++)
					{
						if (pieces[j] != null && !int.TryParse(pieces[j], out oneLineOfS[j]) || oneLineOfS[j] > data[3] || oneLineOfS[j] < 1)
							resultError++;
					}
					if (resultError == 0)
					{
						S.Add(oneLineOfS);
						i++;
					}
					else
						Console.Error.WriteLine("Nem megfelelő adattípus szerepelt valahol a bemenetben!");
				}
			} while (i < data[0]);
		}
		static void Output()
		{
			for (int i = 1; i <= data[3]; i++)
			{
				int match = 0;
				for (int j = 0; j < data[0]; j++)
				{
					for (int k = 0; k < data[1]; k++)
					{
						if (i == S[j][k])
							match++;
					}
				}
				if (match == data[0])
					winnerS.Add(i);
			}
			Console.Write($"{winnerS.Count} ");
			foreach (int racer in winnerS)
					Console.Write($"{racer} ");
		}
	}
}