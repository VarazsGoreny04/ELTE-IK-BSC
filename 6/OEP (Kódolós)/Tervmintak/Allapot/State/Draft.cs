namespace State;

public class Draft : State
{
	public Draft(Document document) : base(document) { }

	public override void Edit(ref string text, string newText)
	{
		text = newText;
	}

	public override void Publish(ref State state)
	{
		state = new Moderation(document);
	}
}