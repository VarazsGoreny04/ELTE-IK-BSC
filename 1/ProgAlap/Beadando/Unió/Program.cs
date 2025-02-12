namespace Unió
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
			Console.ReadKey();
			Console.Clear();
			foreach (char i in "Hello World!")
			{
				Console.Write(i); ;
				Thread.Sleep(150);
			}
		}
	}
}