using System.ComponentModel;

namespace prime
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Initial();
			Input();
			Console.WriteLine("Add meg a mátrix elemeit:");
			for (int i = 0; i < ; i++)
			{

			}
		}
		static int N = 0, M = 0;
		static void Initial()
		{
			bool Error = false;
			Console.WriteLine("Add meg a mátrix magasságát és szélességét:");
			do
			{
				if (Error)
					Console.WriteLine("Hibás bemenet!");
				string[] first = Console.ReadLine().Split();
				bool nullE = int.TryParse(first[0], out N);
				bool oneE = int.TryParse(first[1], out M);
				Error = nullE || oneE;
			} while (Error);
		}
		static void Input()
		{
			int[,] matrix = new int[N, M];
			for (int i = 0; i < N; i++)
			{
				string[] line = Console.ReadLine().Split();
				if (line.Length == M)
				{
					for (int j = 0; j < M; j++)
					{
						matrix[i, j] = int.Parse(line[j]);
					}
				}
			}
		}
		static void Output()
		{

		}
	}
}