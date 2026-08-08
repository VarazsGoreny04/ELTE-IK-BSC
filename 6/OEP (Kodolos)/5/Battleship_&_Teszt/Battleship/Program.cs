namespace Battleship;

internal class Program
{
    static void Main()
    {
		View view = new();

		view.HideShips = false;
		view.Run();
	}
}