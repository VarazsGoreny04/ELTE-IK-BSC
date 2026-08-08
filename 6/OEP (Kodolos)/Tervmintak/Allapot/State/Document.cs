namespace State;

public class Document
{
	private State state;
	private string text;

	public string Text => text;
	public State State => state;

	public Document()
	{
		state = new Draft(this);
		text = string.Empty;
	}

	public void Edit(string newText)
	{
		state.Edit(ref text, newText);
	}

	public void Publish()
	{
		state.Publish(ref state);
	}

	/*public void ChangeState(State state)
	{
		this.state = state;
	}*/
}