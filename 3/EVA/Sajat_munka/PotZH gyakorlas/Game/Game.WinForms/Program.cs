using EVA.Game.WinForms.View;

namespace EVA.Game.WinForms;
internal static class Program
{
	[STAThread]
	static void Main()
	{
		ApplicationConfiguration.Initialize();
		Application.Run(new GameForm());
	}
}