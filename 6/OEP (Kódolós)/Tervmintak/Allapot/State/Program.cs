namespace State;

internal class Program
{
    static void Main()
    {
        Document novel = new();
        novel.Edit("Once upon a time...");

		Console.WriteLine($"The text in the novel says \"{novel.Text}\" and it's in {novel.State.GetType().Name} state.\n");

        novel.Publish();
		novel.Edit("Once upon a time in the west");

		Console.WriteLine($"The text in the novel says \"{novel.Text}\" and it's in {novel.State.GetType().Name} state.\n");

		novel.Publish();

		try
		{
			novel.Edit("You can't do this!");
		}
		catch (Exception)
		{
			Console.WriteLine("Editing is not possible from now on!\n");
		}

		Console.WriteLine($"The text in the novel says \"{novel.Text}\" and it's in {novel.State.GetType().Name} state.");
	}
}