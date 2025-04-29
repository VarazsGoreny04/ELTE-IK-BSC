namespace Gombavadaszat
{
	public partial class ButtonHunter : Form
	{
		private int points;
		private Random generator;
		private DateTime startTime;

		public ButtonHunter()
		{
			InitializeComponent();
			points = 0;
			generator = new Random();
		}

		private void ButtonClicked(object sender, EventArgs e)
		{
			int x = ClientSize.Width - pushButton.Width;
			int y = ClientSize.Height - pushButton.Height - statusLabel.Height;
			pushButton.Location = new Point(generator.Next(x), generator.Next(y));
			statusStrip.Text = $"Points: {points}";

			if (!timer.Enabled)
			{
				startTime = DateTime.Now;
				timer.Start();
			}
			else
				++points;

			UpdateStatusBar(sender, e);
		}

		private void UpdateStatusBar(object sender, EventArgs e)
		{
			double elapsedSeconds = (DateTime.Now - startTime).TotalSeconds;
			statusStrip.Text = $"Points: {points} | Elapsed time: {elapsedSeconds:F0} sec";
		}

		private void GameClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing && timer.Enabled)
			{
				double elapsedSeconds = (DateTime.Now - startTime).TotalSeconds;
				double pushPerSeconds = points / elapsedSeconds;
				MessageBox.Show($"Pushes per seconds: {pushPerSeconds:F2}", "Results",
				MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
	}
}