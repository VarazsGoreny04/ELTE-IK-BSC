namespace Fagy
{
	internal class Program
	{
		static int Size()
		{
			Console.Error.WriteLine("Add meg hány elemet kívánsz megadni!");
			bool Error1 = false;
			int N;
			do
			{
				Error1 = !int.TryParse(Console.ReadLine(), out N);
				if (Error1)
					Console.Error.WriteLine("Hibás bemenet! Próbáld újra!");
			} while (Error1);
			return N;
		}
		static int[] Input(int N)
		{
			Console.Error.WriteLine("Add meg a mért hőmérsékleteket!");
			bool Error = false;
			int i = 0;
			int[] Hom = new int[N];
			do
			{
				Error = !int.TryParse(Console.ReadLine(), out Hom[i]);
				if (Error)
					Console.Error.WriteLine("Hibás bemenet! Próbáld újra!");
				else
					i++;
			} while (Error || i < N && !Error);
			return Hom;
		}
		static void Main(string[] args)
		{
			int i = 0, N = Size();
			int[] Hom = Input(N);
			List<int> Fagy = new();
			while (i <= N && Hom[i] < 0)
			{
				i++;
			}
			bool van = i <= N;
			if (van)
			{
				int ind = i;
				for (int j = 0; j < ind; j++)
					Fagy.Add(Hom[j]);
			}
			else
			{
				for (int j = 0; j < N; j++)
					Fagy.Add(Hom[j]);
			}
			for (int j = 0; j < Fagy.Count; j++)
			{
				Console.WriteLine(Fagy[j]);
			}
		}
	}
}