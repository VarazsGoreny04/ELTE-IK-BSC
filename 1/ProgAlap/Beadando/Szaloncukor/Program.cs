using System;
using System.Collections.Generic;
namespace Szaloncukor
{
	internal class Program
	{
		static int numOfFactCandy, factNum, candyVar;
		static void Main(string[] args)
		{
			Initial();
			int[,] data = new int[numOfFactCandy, 3];
			Input(data);
			CheapCandy(data);
			SpeedyFact(data);
			Expensive(data);
			CandyNum(data);
			OnlyOne(data);
		}
		static void Initial()
		{
			string[] line = Console.ReadLine().Split();
			int.TryParse(line[0], out numOfFactCandy);
			int.TryParse(line[1], out factNum);
			int.TryParse(line[2], out candyVar);
		}
		static void Input(int[,] array)
		{
			for (int i = 0; i < numOfFactCandy; ++i)
			{
				string[] line = Console.ReadLine().Split();
				int.TryParse(line[0], out array[i, 0]);
				int.TryParse(line[1], out array[i, 1]);
				int.TryParse(line[2], out array[i, 2]);
			}
		}
		static void CheapCandy(int[,] array)
		{
			int cheap = array[0,2], cheapInd = 0;
			for (int i = 1; i < numOfFactCandy; ++i)
			{
				if (array[i, 2] < cheap)
				{
					cheap = array[i, 2];
					cheapInd = i;
				}
			}
			Console.WriteLine($"{array[cheapInd,0]} {array[cheapInd,1]}");
		}
		static void SpeedyFact(int[,] array)
		{
			int lottaCandy = 0, factInd = 0;
			for (int i = 0; i < factNum; ++i)
			{
				int counter = 0;
				for (int j = 0; j < numOfFactCandy; ++j)
				{
					if (array[j,0] == i + 1)
						++counter;
				}
				if (counter > lottaCandy)
				{
					lottaCandy = counter;
					factInd = i + 1;
				}
			}
			Console.WriteLine(factInd);
		}
		static void Expensive(int[,] array)
		{
			List<int> facts = new List<int>();
			for (int i = 0; i < numOfFactCandy; ++i)
			{
				if (!facts.Contains(array[i,0]))
					facts.Add(array[i,0]);
			}
			facts.Sort();
			Console.Write(facts.Count);
			for (int i = 0; i < facts.Count; ++i)
			{
				int max = 0;
				for (int j = 0; j < numOfFactCandy; ++j)
				{
					if (facts[i] == array[j, 0] && array[j, 2] > max)
						max = array[j, 2];
				}
				Console.Write($" {facts[i]} {max}");
			}
			Console.WriteLine();
		}
		static void CandyNum(int[,] array)
		{
			List<int> candy = new List<int>();
			for (int i = 0; i < numOfFactCandy; ++i)
			{
				if (!candy.Contains(array[i, 1]))
					candy.Add(array[i, 1]);
			}
			Console.WriteLine(candy.Count);
		}
		static void OnlyOne(int[,] array)
		{
			List<int> ones = new List<int>();
			for (int i = 1; i <= candyVar; ++i)
			{
				int counter = 0;
				for (int j = 0; j < numOfFactCandy; ++j)
				{
					if (array[j,1] == i)
						++counter;
				}
				if (counter == 1)
					ones.Add(i);
			}
			Console.Write(ones.Count);
			for (int i = 0; i < ones.Count; ++i)
				Console.Write($" {ones[i]}");
		}
	}
}