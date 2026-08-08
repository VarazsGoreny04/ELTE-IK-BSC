namespace State;

public class Published : State
{
	public Published(Document document) : base(document) { }

	public override void Edit(ref string text, string newText)
	{
		throw new Exception();
	}

	public override void Publish(ref State state)
	{
		throw new Exception();
	}
}