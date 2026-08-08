namespace DungeonCrawler;

internal class Program
{
    static void Main()
    {
        DungeonWriter writer = new("map2.txt");

        writer.Run();
    }
}