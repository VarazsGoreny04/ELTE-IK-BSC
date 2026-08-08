namespace State;

public abstract class State
{
	protected Document document;

	public State(Document document)
	{
		this.document = document;
	}

	public abstract void Edit(ref string text, string newText);
	public abstract void Publish(ref State state);
}