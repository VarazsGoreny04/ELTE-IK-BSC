using TextFile;

namespace Rational;

public class Reader
{
	public static List<Rat> ReadIn(string filename)
	{
		List<Rat> result = [];

		TextFileReader tfr = new(filename);
		string line;

		while ((line = tfr.ReadLine()) != null)
		{
			string[] tokens = line.Split('/');

			if (tokens.Length != 2)
				throw new Exception();

			result.Add(new Rat(int.Parse(tokens[0]), int.Parse(tokens[1])));
		}

		return result;
	}
}