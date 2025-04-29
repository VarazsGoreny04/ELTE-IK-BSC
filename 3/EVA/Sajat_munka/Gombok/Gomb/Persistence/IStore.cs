namespace HOK.Gomb.Persistence;
public interface IStore
{
	Task<IEnumerable<string>> GetFilesAsync();

	Task<DateTime> GetModifiedTimeAsync(string name);
}