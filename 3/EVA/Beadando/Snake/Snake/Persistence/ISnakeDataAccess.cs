namespace ELTE.Snake.Persistence;
public interface ISnakeDataAccess
{
	Task<SnakeTable> LoadAsync(uint tableSize, string path);
	Task<SnakeTable> LoadAsync(string path);
	Task SaveAsync(string path, SnakeTable table);
}