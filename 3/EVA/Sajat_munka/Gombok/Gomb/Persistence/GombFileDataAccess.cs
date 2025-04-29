namespace HOK.Gomb.Persistence;
public class GombFileDataAccess : IGombDataAccess
{
	private readonly string? _directory = string.Empty;

	public GombFileDataAccess(string? saveDirectory = null)
	{
		_directory = saveDirectory;
	}

	public async Task<GombTable> LoadAsync(string path)
	{
		try
		{
			if (!string.IsNullOrEmpty(_directory))
				path = Path.Combine(_directory, path);

			using StreamReader reader = new(path);
			string line = await reader.ReadLineAsync() ?? string.Empty;
			string[] numbers = line.Split(' ');

			if (numbers.Length != 2) throw new GombDataException();

			bool light1 = bool.Parse(numbers[0]);
			bool light2 = bool.Parse(numbers[1]);

			return new GombTable(light1, light2);
		}
		catch
		{
			throw new GombDataException();
		}
	}

	public async Task SaveAsync(string path, GombTable table)
	{
		try
		{
			if (!string.IsNullOrEmpty(_directory))
				path = Path.Combine(_directory, path);

			using StreamWriter writer = new(path);
			await writer.WriteLineAsync($"{table.Light1} {table.Light2}");
		}
		catch
		{
			throw new GombDataException();
		}
	}
}