using System;
using System.Collections.Generic;
namespace Legtöbb_hegycsúcs
{
	internal class Feladat
	{
		static void Main(string[] args)
		{
			Initial();
			Input();
			Output();
		}
		static int N, K;
		static void Initial()
		{
			string[] peaces = Console.ReadLine().Split();
			N = int.Parse(peaces[0]);
			K = int.Parse(peaces[1]);
			Console.WriteLine(N);
		}
		static int[] data = new int[N];
		static void Input()
		{
			string[] dataString = Console.ReadLine().Split();
			for (int i = 0; i < N; i++)
				data[i] = int.Parse(dataString[i]);
		}
		static int[] spot = new int[] { };
		static void Output()
		{
			int i = 1, j = 0, stop1 = N - 1;
			while (i < stop1)
			{
				if (data[i] > data[i - 1] && data[i] > data[i + 1])
				{
					spot[j++] = i;
					if (i + 2 < stop1)
						++i;
				}
				++i;
			}
			int num = spot.Length;
			if (num == 0)
				Console.WriteLine($"-1 -1");
			else
			{
				int[] counts = new int[num];
				int stop2 = N - K, plus = K + 1;
				for (int k = 0; k < stop2; ++k)
				{
					int count = 0;
					for (int l = 0; l < num; ++l)
					{
						if (spot[l] > k && spot[l] < k + plus)
							++count;
					}
					counts[k] = count;
				}
				int maxData = -1, max = 0;
				for (int k = 0; k < counts.Length; ++k)
				{
					if (counts[k] > maxData)
					{
						maxData = counts[k];
						max = k;
					}
				}
				Console.WriteLine($"{max + 2} {max + plus}");
			}
		}
	}
}