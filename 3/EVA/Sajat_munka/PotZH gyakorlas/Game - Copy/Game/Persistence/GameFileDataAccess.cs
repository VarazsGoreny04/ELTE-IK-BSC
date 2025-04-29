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
				int tableSize = int.Parse(line);
				GameTable table = new(tableSize);

				string[] data;
				for (int i = 0; i < tableSize; i++)
				{
					line = await reader.ReadLineAsync() ?? string.Empty;
					data = line.Split(' ');

					for (int j = 0; j < tableSize; j++)
					{
						table[i, j] = bool.Parse(data[j]);
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

				await writer.WriteLineAsync(table.Size.ToString());

				for (int i = 0; i < table.Size; i++)
				{
					for (int j = 0; j < table.Size; j++)
					{
						await writer.WriteAsync(table[i, j] + " ");
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
