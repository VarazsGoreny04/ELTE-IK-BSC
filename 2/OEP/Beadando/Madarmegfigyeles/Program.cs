namespace Madarmegfigyeles
{
	internal class Program
	{
		static void Main(string[] args)
		{
			InFile file = new InFile("input.txt");
			while (file.Read(out Observation ob))
			{
				if (ob.owlDate == null)
					Console.WriteLine($"Sajnos {ob.spotter} nem látott fülesbaglyot. Sad story. :(\n");
				else
				{ 
					Console.Write($"{ob.spotter} fülesbaglyot először {ob.owlDate} {ob.owlPlace} környékén látott. ");
					if (ob.maxSparrow == 0)
						Console.WriteLine("Viszont budapesti verebet ezután nem látott. :(\n");
					else
						Console.WriteLine($"Ráadásul sikerült ezután budapesti verebet is látnia. Egyszerre {ob.maxSparrow} darabot {ob.maxSparrowPlace} környékén. :)\n");
				}
			}
		}
	}
}