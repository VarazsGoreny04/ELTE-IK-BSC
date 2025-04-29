namespace HOK.Gomb.MAUI.ViewModel;
public class StoredGameEventArgs : EventArgs
{
	public string Name { get; set; } = string.Empty;

	public uint Size { get; set; }

	public DateTime Modified { get; set; }
}