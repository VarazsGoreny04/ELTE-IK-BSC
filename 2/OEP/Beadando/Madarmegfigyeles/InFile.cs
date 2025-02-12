using TextFile;

namespace Madarmegfigyeles
{
	public class InFile
	{
		private readonly TextFileReader reader; 
		public InFile(string path)
		{
			reader = new TextFileReader(path);
		}
		public bool Read(out Observation birds)
		{
			bool l = reader.ReadLine(out string line);
			birds = null!;
			if (l)
			{
				string[] tokens = line.Split(',');
				birds = new Observation(tokens[0]);
				for (int i = 1; i < tokens.Length; i += 4)
					birds.Add(new Bird { date = tokens[i], place = tokens[i + 1], name = tokens[i + 2], howMany = int.Parse(tokens[i + 3]) });
			}
			return l;
		}
	}
}
