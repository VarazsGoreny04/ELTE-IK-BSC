namespace N_égyzet
{
	internal class Program
	{
		static int Négy(int a)
		{
			return a * a;
		}
		static void Növel(ref int a)
		{
			a += 1;
		}
		static void Csere(ref int a, ref int b)
		{
			int c = a;
			a = b;
			b = c;
		}
		static void Main(string[] args)
		{
			List<int> lista = new();
			List<int> negyzetLista = new();
			Console.Write("Adja meg az elemek számát: ");
			int.TryParse(Console.ReadLine(), out int N);
			int egység;
			for (int i = 0; i < N; i++)
			{
				int.TryParse(Console.ReadLine(), out egység);
				lista.Add(egység);
			}
			for (int i = 0; i < lista.Count; i++)
			{
				negyzetLista.Add(Négy(lista[i]));
			}
			for (int i = 0; i < N; i++)
			{
				Console.WriteLine(negyzetLista[i]);
			}
			int számocska = 1, másikSzámocska = 4;
			Növel(ref számocska);
			Console.WriteLine(számocska);
			Csere(ref számocska, ref másikSzámocska);
			Console.WriteLine($"{számocska}{másikSzámocska}");
		}
	}
}