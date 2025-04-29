namespace ELTE.Game.Persistence
{
	public class GameFileDataAccess : IGameDataAccess
	{
		public async Task<GameTable> LoadAsync(string path)
		{
			StreamReader sr;

			try
			{
				sr = new StreamReader(path);
			}
			catch (Exception)
			{
				throw new GameDataException("File could not be found!");
			}

			try
			{
				GameTable table = new();
				string line = string.Empty;

				line = await sr.ReadLineAsync() ?? string.Empty;
				table.NewScore(uint.Parse(line));

				for (int i = 0; i < 4; ++i)
				{
					line = await sr.ReadLineAsync() ?? string.Empty;
					string[] data = line.Split(' ');

					for (int j = 0; j < 4; ++j)
					{
						table.Table[j, i] = bool.Parse(data[j]);
					}
				}

				return table;
			}
			catch (GameDataException ex)
			{
				throw new GameDataException(ex.Message);
			}
			finally
			{
				sr.Close();
			}
		}

		public async Task SaveAsync(string path, GameTable table)
		{

			StreamWriter sw;

			try
			{
				sw = new StreamWriter(path);
			}
			catch (Exception)
			{
				throw new GameDataException("File could not be found!");
			}

			try
			{
				string line = string.Empty;
				await sw.WriteLineAsync(Convert.ToString(table.Score));

				for (int i = 0; i < 4; ++i)
				{
					for (int j = 0; j < 4; ++j)
					{
						await sw.WriteAsync(Convert.ToString(table.Table[j, i]) + " ");
					}
					sw.WriteLine();
				}
			}
			catch (GameDataException ex)
			{
				throw new GameDataException(ex.Message);
			}
			finally
			{
				sw.Close();
			}
		}
	}
}