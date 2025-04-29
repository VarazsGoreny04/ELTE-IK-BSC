namespace HOK.Gomb.Persistence;
public interface IGombDataAccess
{
	Task<GombTable> LoadAsync(string path);

	Task SaveAsync(string path, GombTable table);
}