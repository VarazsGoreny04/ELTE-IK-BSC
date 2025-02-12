using System;
using System.Collections.Generic;
namespace Legtöbb_hegycsúcs
{
	internal class Program
	{
		static List<int> data = new();
		static void Main(string[] args)
		{
			Input();
			Output();
		}
		static void Input()
		{
			Console.ReadLine();
			string[] dataString = Console.ReadLine().Split();
			for (int i = 0; i < dataString.Length; i++)
				data.Add(int.Parse(dataString[i]));
		}
		static void Output()
		{
			int i = 1, stop = data.Count - 1, length = 0, max  = 0, end = -1;
			while (i < stop)
			{
				if (data[i] > data[i - 1] && data[i] > data[i + 1])
				{
					if (length >= max)
					{
						end = i + 1;
						max = length;
					}
					length += 2;
					if (i + 2 < stop)
						++i;
				}
				else
					length = 0;
				++i;
			}
			if (end != -1)
				Console.WriteLine($"{end - max} {end}");
			else
				Console.WriteLine($"-1 -1");
		}
	}
}