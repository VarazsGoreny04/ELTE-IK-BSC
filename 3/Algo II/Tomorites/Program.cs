namespace Tomorites
{
	internal class Program
	{
		static void Main()
		{
			do
			{
				Console.Write("File name: ");
				string zipName, fileName = Console.ReadLine() ?? "";
				bool zip;
				do
				{
					Console.Write("Zip or unzip: ");
					zip = (zipName = Console.ReadLine() ?? "") == "zip";
				} while (!zip && zipName != "unzip");

				if (zip)
					Tomorito(fileName);
				else
					Kicsomagolo(fileName);

				Console.Clear();
			} while (true);
		}

		static void Tomorito(string file)
		{
			StreamReader sr = new StreamReader(file);
			File file1 = new File(file);
			StreamWriter sw = new StreamWriter($"{file}")
			int character;
			byte coded;
			while ((character = sr.Read()) != -1)
			{
				coded = (byte)character;
			}
		}

		static void Kicsomagolo(string file)
		{

		}
	}
}