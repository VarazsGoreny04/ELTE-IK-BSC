using TextFile;

namespace Fisherman
{
	public class InFile
	{
		private readonly TextFileReader reader; 
		public InFile(string path)
		{
			reader = new TextFileReader(path);
		}
		public bool Read(out Fisher fisher)
		{
			bool l = reader.ReadLine(out string line);
			fisher = null!;
			if (l)
			{
				char[] separators = { ' ', '\t' };
				string[] tokens = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
				fisher = new Fisher(tokens[0]);
				for (int i = 1; i < tokens.Length; i += 4)
				{
					fisher.Add(new Catch { time = tokens[i], spieces = tokens[i + 1], weight = double.Parse(tokens[i + 2]), length = double.Parse(tokens[i + 3]) });
				}
			}
			return l;
		}
	}
}
