namespace Filmszinhaz
{
	internal class Program
	{
		static void Main()
		{
			EgySzinhaz();
		}

		public static void EgySzinhaz()
		{
			Console.Write("Adja meg a bemeneti fájl nevét: ");
			InFile file;
			try
			{
				file = new InFile("./" + Console.ReadLine()!);
			}
			catch (FileNotFoundException)
			{
				Console.WriteLine("A fájl nem látszik, vagy nem létezik!");
				return;
			}
			catch
			{
				Console.WriteLine("Valami hiba történt!");
				return;
			}

			file.SzinhazBeolvasasa(out Szinhaz szinhaz);

			Console.WriteLine($"A legtöbbet nézett film címe: {szinhaz.LegtobbetNezettFilm()}");
		}
	}
}