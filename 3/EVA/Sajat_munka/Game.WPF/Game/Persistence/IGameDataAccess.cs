namespace ELTE.Game.Persistence
{
	public interface IGameDataAccess
	{
		Task SaveAsync(string path, GameTable table);
		Task<GameTable> LoadAsync(string path);
	}
}