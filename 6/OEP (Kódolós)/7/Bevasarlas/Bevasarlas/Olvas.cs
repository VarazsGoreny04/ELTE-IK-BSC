using TextFile;

namespace Bevasarlas;

public class Olvas
{
	public static List<string> TermekNevek(string filename)
	{
		List<string> result = [];

		TextFileReader tfr = new(filename);
		string line;

		while ((line = tfr.ReadLine()) != null)
			result.Add(line);

		return result;
	}

	public static List<Termek> Termekek(string filename)
	{
		List<Termek> result = [];

		TextFileReader tfr = new(filename);
		string line;

		while ((line = tfr.ReadLine()) != null)
		{
			string[] tokens = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
			
			if (tokens.Length != 2)
				throw new Exception();

			result.Add(new Termek(tokens[0].Trim(), int.Parse(tokens[1].Trim())));
		}

		return result;
	}
}