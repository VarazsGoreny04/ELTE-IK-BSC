namespace SzámRend
{
	internal class Program
	{
		static void Main()
		{
            File cica = new File(69);
			File macsek = new File(420);

			Folder cicaskepek = new Folder();
			Folder cicak = new Folder();

			cicak.Add(cica);
			cicak.Add(macsek);

			cicaskepek.Add(cica);
			cicaskepek.Add(macsek);
			cicaskepek.Add(cicak);

			FileSystem fileSystem = new FileSystem();

			fileSystem.Add(cicaskepek);

			Console.WriteLine(fileSystem.GetSize());
		}
	}
}