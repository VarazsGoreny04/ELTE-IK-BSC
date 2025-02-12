using System;
using System.Collections.Generic;

namespace Leghosszabb_időintervallumban_dobogón_elért_helyezés
{
	internal class Program
	{
		static int numOfLines = 0;
		static List<int> runner = new();
		static void Main(string[] args)
		{
			Input();
			Output();
		}
		static void Input()
		{
			numOfLines = int.Parse(Console.ReadLine());
			for (int i = 0; i < numOfLines; i++)
			{
				string[] line = Console.ReadLine().Split();
				runner.Add(int.Parse(line[0]));
			}
		}
		static void Output()
		{
			int end = 0, max = 0, length = 0;
			for (int i = 0; i < numOfLines; i++)
			{
				if (runner[i] < 4)
					++length;
				else if (length > max)
				{
					end = i;
					max = length;
					length = 0;
				}
				else
					length = 0;
			}
			if (max == 0)
				Console.WriteLine(0);
			else
				Console.WriteLine($"{end - max + 1} {end}");
		}
	}
}