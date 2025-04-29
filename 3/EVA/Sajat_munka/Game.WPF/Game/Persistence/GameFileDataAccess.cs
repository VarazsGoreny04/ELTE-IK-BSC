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
				GameTable table = new(5);
				string line = string.Empty;

				line = await sr.ReadLineAsync() ?? string.Empty;
				table.SetRound(uint.Parse(line));

				for (int i = 0; i < 4; ++i)
				{
					line = await sr.ReadLineAsync() ?? string.Empty;
					string[] data = line.Split(' ');

					for (int j = 0; j < 4; ++j)
					{
						//table.SetField(new Point(j, i), Point.Parse(data[j]));
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
				await sw.WriteLineAsync(Convert.ToString(table.Round));

				for (int i = 0; i < 4; ++i)
				{
					for (int j = 0; j < 4; ++j)
					{
						await sw.WriteAsync(Convert.ToString(table[j, i]) + " ");
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