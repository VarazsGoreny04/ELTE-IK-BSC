using ELTE.Snake.Persistence;

namespace ELTE.Snake.MAUI.Persistence;
public class SnakeStore : IStore
{
	/// <summary>
	/// Fájlok lekérdezése.
	/// </summary>
	/// <returns>A fájlok listja.</returns>
	public async Task<IEnumerable<string>> GetFilesAsync()
	{
		return await Task.Run(() => Directory.GetFiles(FileSystem.AppDataDirectory)
			.Select(Path.GetFileName)
			.Where(name => name?.EndsWith(".txt") ?? false)
			.OfType<string>());
	}

	/// <summary>
	/// Módosítás idejének lekérdezése.
	/// </summary>
	/// <param name="name">A fájl neve.</param>
	/// <returns>Az utols módosítás ideje.</returns>
	public async Task<DateTime> GetModifiedTimeAsync(string name)
	{
		var info = new FileInfo(Path.Combine(FileSystem.AppDataDirectory, name));

		return await Task.Run(() => info.LastWriteTime);
	}
}