namespace Strategy;

internal class Program
{
    static void Main()
    {
		Player player1 = new();
		Player player2 = new();

        player1.Shoot(player2);
		Console.WriteLine($"Player2 has {player2.TakesHit}hp before Player1 picked up a weapon and \"shot\" him.\n");

        player1.PickUp(new AK_47());
        player1.Shoot(player2);
		Console.WriteLine($"Player2 has {player2.TakesHit}hp after Player1 picked up an AK-47 and shot him for real this time.\n");

		player2.PickUp(new AWP());
        player2.Shoot(player1);
		Console.WriteLine($"Player1 has {player1.TakesHit}hp after Player2 picked up an AWP and shot him back.\n");
    }
}