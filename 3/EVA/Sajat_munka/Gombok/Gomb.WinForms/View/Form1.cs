using HOK.Gomb.Model;
using HOK.Gomb.Persistence;

namespace HOK.Gomb.WinForms.View;
public partial class Form1 : Form
{
	private readonly GombGameModel _model;
	private readonly IGombDataAccess _dataAccess;

	public Form1()
	{
		InitializeComponent();
		_dataAccess = new GombFileDataAccess();
		_model = new GombGameModel(_dataAccess);
		_model.Handler += new EventHandler<GombEventArgs>(Switch);
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		_model.Button1();
	}

	private void Button2_Click(object sender, EventArgs e)
	{
		_model.Button12();
	}

	private async void ButtonSave_Click(object sender, EventArgs e)
	{
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			try
			{
				await _model.SaveGameAsync(saveFileDialog.FileName);
			}
			catch (GombDataException)
			{
				_ = MessageBox.Show("Save failed!\nWrong path, or the library is not writable.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}

	private async void ButtonLoad_Click(object sender, EventArgs e)
	{

		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			try
			{
				await _model.LoadGameAsync(openFileDialog.FileName);
			}
			catch (GombDataException)
			{
				_ = MessageBox.Show("Load failed!\nWrong path, or the library is not readable.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}

	private void Switch(object? sender, GombEventArgs e)
	{
		if (e.One)
			label1.BackColor = Color.Red;
		else
			label1.BackColor = Color.Black;


		if (e.Two)
			label2.BackColor = Color.Red;
		else
			label2.BackColor = Color.Black;
	}
}