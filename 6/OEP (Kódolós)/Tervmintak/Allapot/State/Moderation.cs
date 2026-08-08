namespace State;

public class Moderation : State
{
	public Moderation(Document document) : base(document) { }

	public override void Edit(ref string text, string newText)
	{
		text = newText;
	}

	public override void Publish(ref State state)
	{
		state = new Published(document);
	}
}