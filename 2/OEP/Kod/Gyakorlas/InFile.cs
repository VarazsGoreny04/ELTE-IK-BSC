using TextFile;

namespace Gyakorlas
{
	public class InFile
	{
		private readonly TextFileReader reader;
		public InFile(string path)
		{
			reader = new TextFileReader(path);
		}
		public bool Read(out Burger burgir)
		{
			bool l = reader.ReadLine(out string line);
			burgir = null!;
			if (l)
			{
				char[] separators = { ' ', '\t' };
				string[] tokens = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
				burgir = new Burger(tokens[0]);
				for (int i = 1; i < tokens.Length; i += 3)
					burgir.Add(new Order { name = tokens[i], howMany = int.Parse(tokens[i + 1]), rating = int.Parse(tokens[i + 2]) });
			}
			return l;
		}
	}
}
