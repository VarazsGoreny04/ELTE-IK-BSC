namespace EVA.Game.Persistence
{
	public class GameFileDataAccess : IGameDataAccess
	{
		private readonly string? _directory = string.Empty;

		public GameFileDataAccess(string? saveDirectory = null)
		{
			_directory = saveDirectory;
		}

		public async Task<GameTable> LoadAsync(string path)
		{
			if (!string.IsNullOrEmpty(_directory))
				path = Path.Combine(_directory, path);

			try
			{
				using StreamReader reader = new(path);

				string line = await reader.ReadLineAsync() ?? string.Empty;
				string[] numbers = line.Split(' ');
				int tableSize = int.Parse(numbers[0]);
				int regionSize = int.Parse(numbers[1]);
				GameTable table = new(tableSize, regionSize);

				for (int i = 0; i < tableSize; i++)
				{
					line = await reader.ReadLineAsync() ?? string.Empty;
					numbers = line.Split(' ');

					for (int j = 0; j < tableSize; j++)
					{
						table.SetValue(i, j, int.Parse(numbers[j]), false);
					}
				}

				for (int i = 0; i < tableSize; i++)
				{
					line = await reader.ReadLineAsync() ?? string.Empty;
					string[] locks = line.Split(' ');

					for (int j = 0; j < tableSize; j++)
					{
						if (locks[j] == "1")
						{
							table.SetLock(i, j);
						}
					}
				}

				return table;
			}
			catch
			{
				throw new GameDataException();
			}
		}
		
		public async Task SaveAsync(string path, GameTable table)
		{
			if (!string.IsNullOrEmpty(_directory))
				path = Path.Combine(_directory, path);

			try
			{
				using StreamWriter writer = new(path);

				writer.Write(table.Size);
				await writer.WriteLineAsync(" " + table.RegionSize);
				for (int i = 0; i < table.Size; i++)
				{
					for (int j = 0; j < table.Size; j++)
					{
						await writer.WriteAsync(table[i, j] + " ");
					}
					await writer.WriteLineAsync();
				}

				for (int i = 0; i < table.Size; i++)
				{
					for (int j = 0; j < table.Size; j++)
					{
						await writer.WriteAsync((table.IsLocked(i, j) ? "1" : "0") + " "); // kiírjuk a zárolásokat
					}
					await writer.WriteLineAsync();
				}
			}
			catch
			{
				throw new GameDataException();
			}
		}
	}
}
