namespace Game.WinForms.View
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			panelGame = new Panel();
			panelMenu = new Panel();
			labelTitle = new Label();
			buttonResume = new Button();
			buttonSave = new Button();
			buttonNewGame = new Button();
			buttonLoad = new Button();
			buttonPause = new Button();
			labelScoreScore = new Label();
			labelScoreLabel = new Label();
			timer = new System.Windows.Forms.Timer(components);
			panelMenu.SuspendLayout();
			SuspendLayout();
			// 
			// panelGame
			// 
			panelGame.Location = new Point(10, 10);
			panelGame.Name = "panelGame";
			panelGame.Size = new Size(250, 250);
			panelGame.TabIndex = 0;
			// 
			// panelMenu
			// 
			panelMenu.Controls.Add(labelTitle);
			panelMenu.Controls.Add(buttonResume);
			panelMenu.Controls.Add(buttonSave);
			panelMenu.Controls.Add(buttonNewGame);
			panelMenu.Controls.Add(buttonLoad);
			panelMenu.Location = new Point(268, 10);
			panelMenu.Name = "panelMenu";
			panelMenu.Size = new Size(200, 300);
			panelMenu.TabIndex = 1;
			// 
			// labelGameEnd
			// 
			labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
			labelTitle.Location = new Point(10, 10);
			labelTitle.Name = "labelGameEnd";
			labelTitle.Size = new Size(180, 41);
			labelTitle.TabIndex = 2;
			labelTitle.Text = "Game";
			labelTitle.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// buttonResume
			// 
			buttonResume.Enabled = false;
			buttonResume.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
			buttonResume.Location = new Point(50, 70);
			buttonResume.Name = "buttonResume";
			buttonResume.Size = new Size(100, 40);
			buttonResume.TabIndex = 3;
			buttonResume.Text = "Resume";
			buttonResume.UseVisualStyleBackColor = true;
			buttonResume.Click += ButtonResume_Click;
			// 
			// button10
			// 
			buttonNewGame.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
			buttonNewGame.Location = new Point(50, 130);
			buttonNewGame.Name = "button10";
			buttonNewGame.Size = new Size(100, 40);
			buttonNewGame.TabIndex = 4;
			buttonNewGame.Text = "New";
			buttonNewGame.UseVisualStyleBackColor = true;
			buttonNewGame.Click += ButtonNewGame_Click;
			// 
			// button15
			// 
			buttonSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
			buttonSave.Location = new Point(50, 190);
			buttonSave.Name = "button15";
			buttonSave.Size = new Size(100, 40);
			buttonSave.TabIndex = 5;
			buttonSave.Text = "Save";
			buttonSave.UseVisualStyleBackColor = true;
			buttonSave.Click += ButtonSave_Click;
			// 
			// button20
			// 
			buttonLoad.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
			buttonLoad.Location = new Point(50, 250);
			buttonLoad.Name = "button20";
			buttonLoad.Size = new Size(100, 40);
			buttonLoad.TabIndex = 6;
			buttonLoad.Text = "Load";
			buttonLoad.UseVisualStyleBackColor = true;
			buttonLoad.Click += ButtonLoad_Click;
			// 
			// buttonPause
			// 
			buttonPause.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			buttonPause.Enabled = false;
			buttonPause.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
			buttonPause.Location = new Point(10, 398);
			buttonPause.Name = "buttonPause";
			buttonPause.Size = new Size(100, 40);
			buttonPause.TabIndex = 7;
			buttonPause.Text = "Pause";
			buttonPause.UseVisualStyleBackColor = true;
			buttonPause.Click += ButtonPause_Click;
			// 
			// labelScoreScore
			// 
			labelScoreScore.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			labelScoreScore.AutoSize = true;
			labelScoreScore.BackColor = SystemColors.Control;
			labelScoreScore.BorderStyle = BorderStyle.Fixed3D;
			labelScoreScore.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
			labelScoreScore.Location = new Point(725, 404);
			labelScoreScore.Name = "labelScoreScore";
			labelScoreScore.Size = new Size(26, 30);
			labelScoreScore.TabIndex = 8;
			labelScoreScore.Text = "0";
			// 
			// labelScoreLabel
			// 
			labelScoreLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			labelScoreLabel.AutoSize = true;
			labelScoreLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
			labelScoreLabel.Location = new Point(650, 404);
			labelScoreLabel.Name = "labelScoreLabel";
			labelScoreLabel.Size = new Size(69, 28);
			labelScoreLabel.TabIndex = 9;
			labelScoreLabel.Text = "Score:";
			// 
			// GameForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ButtonShadow;
			ClientSize = new Size(800, 450);
			Controls.Add(labelScoreLabel);
			Controls.Add(labelScoreScore);
			Controls.Add(buttonPause);
			Controls.Add(panelMenu);
			Controls.Add(panelGame);
			Icon = (Icon)resources.GetObject("$this.Icon");
			KeyPreview = true;
			Name = "GameForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Game";
			KeyDown += InputConverter;
			panelMenu.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Panel panelGame;
		private Panel panelMenu;
		private Button buttonPause;
		private Button buttonResume;
		private Button buttonNewGame;
		private Button buttonSave;
		private Button buttonLoad;
		private Label labelTitle;
		private Label labelScoreScore;
		private Label labelScoreLabel;
		private System.Windows.Forms.Timer timer;
	}
}
