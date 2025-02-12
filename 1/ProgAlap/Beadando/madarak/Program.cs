using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace madarak
{
	internal class Program
	{
		public static int N, M, mindDb;
		public static int[,] madarak = new int[500,500];
		static bool mindenhol(int a)
		{
			int j = 0;
			while (j < M && madarak[a, j] > 0)
				j++;
			return j == M;
		}
		static void Main(string[] args)
		{
			Console.WriteLine("Hány település van?");
			int.TryParse(Console.ReadLine(), out N);
			Console.WriteLine("Hány madárfaj van?");
			int.TryParse(Console.ReadLine(), out M);
			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < M; j++)
					int.TryParse(Console.ReadLine(), out madarak[i, j]);
			}
			for (int i = 0; i < N; i++)
			{
				if (mindenhol(i))
					mindDb++;
			}
			Console.WriteLine(mindDb);
		}
	}
}