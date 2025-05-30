﻿using HOK.Gomb.Persistence;

namespace HOK.Gomb.MAUI.Persistence;
public class GombStore : IStore
{
	public async Task<IEnumerable<string>> GetFilesAsync()
	{
		return await Task.Run(() => Directory.GetFiles(FileSystem.AppDataDirectory)
			.Select(Path.GetFileName)
			.Where(name => name?.EndsWith(".txt") ?? false)
			.OfType<string>());
	}

	public async Task<DateTime> GetModifiedTimeAsync(string name)
	{
		var info = new FileInfo(Path.Combine(FileSystem.AppDataDirectory, name));

		return await Task.Run(() => info.LastWriteTime);
	}
}