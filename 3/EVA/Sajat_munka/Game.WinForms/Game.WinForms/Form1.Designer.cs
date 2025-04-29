namespace Game
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
			panelGame = new Panel();
			panelMenu = new Panel();
			labelTitle = new Label();
			buttonResume = new Button();
			buttonLoadGame = new Button();
			buttonNewGame = new Button();
			buttonSaveGame = new Button();
			buttonPause = new Button();
			labelScoreScore = new Label();
			labelScoreLabel = new Label();
			panelBlock = new Panel();
			panelMenu.SuspendLayout();
			SuspendLayout();
			// 
			// panelGame
			// 
			panelGame.Location = new Point(10, 10);
			panelGame.Name = "panelGame";
			panelGame.Size = new Size(206, 250);
			panelGame.TabIndex = 0;
			// 
			// panelMenu
			// 
			panelMenu.Controls.Add(labelTitle);
			panelMenu.Controls.Add(buttonResume);
			panelMenu.Controls.Add(buttonLoadGame);
			panelMenu.Controls.Add(buttonNewGame);
			panelMenu.Controls.Add(buttonSaveGame);
			panelMenu.Location = new Point(232, 10);
			panelMenu.Name = "panelMenu";
			panelMenu.Size = new Size(200, 300);
			panelMenu.TabIndex = 1;
			// 
			// labelTitle
			// 
			labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
			labelTitle.Location = new Point(10, 10);
			labelTitle.Name = "labelTitle";
			labelTitle.Size = new Size(180, 41);
			labelTitle.TabIndex = 2;
			labelTitle.Text = "Game";
			labelTitle.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// buttonResume
			// 
			buttonResume.Enabled = false;
			buttonResume.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			buttonResume.Location = new Point(50, 70);
			buttonResume.Name = "buttonResume";
			buttonResume.Size = new Size(150, 40);
			buttonResume.TabIndex = 3;
			buttonResume.Text = "Resume";
			buttonResume.UseVisualStyleBackColor = true;
			buttonResume.Click += ButtonResume_Click;
			// 
			// buttonLoadGame
			// 
			buttonLoadGame.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			buttonLoadGame.Location = new Point(50, 190);
			buttonLoadGame.Name = "buttonLoadGame";
			buttonLoadGame.Size = new Size(150, 40);
			buttonLoadGame.TabIndex = 5;
			buttonLoadGame.Text = "Load Game";
			buttonLoadGame.UseVisualStyleBackColor = true;
			buttonLoadGame.Click += ButtonLoadGame_Click;
			// 
			// buttonNewGame
			// 
			buttonNewGame.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			buttonNewGame.Location = new Point(50, 130);
			buttonNewGame.Name = "buttonNewGame";
			buttonNewGame.Size = new Size(150, 40);
			buttonNewGame.TabIndex = 4;
			buttonNewGame.Text = "New Game";
			buttonNewGame.UseVisualStyleBackColor = true;
			buttonNewGame.Click += ButtonNewGame_Click;
			// 
			// buttonSaveGame
			// 
			buttonSaveGame.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			buttonSaveGame.Location = new Point(50, 250);
			buttonSaveGame.Enabled = false;
			buttonSaveGame.Name = "buttonSaveGame";
			buttonSaveGame.Size = new Size(150, 40);
			buttonSaveGame.TabIndex = 6;
			buttonSaveGame.Text = "Save Game";
			buttonSaveGame.UseVisualStyleBackColor = true;
			buttonSaveGame.Click += ButtonSaveGame_Click;
			// 
			// buttonPause
			// 
			buttonPause.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			buttonPause.Enabled = false;
			buttonPause.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
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
			labelScoreScore.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
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
			labelScoreLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			labelScoreLabel.Location = new Point(650, 404);
			labelScoreLabel.Name = "labelScoreLabel";
			labelScoreLabel.Size = new Size(69, 28);
			labelScoreLabel.TabIndex = 9;
			labelScoreLabel.Text = "Score:";
			// 
			// panelBlock
			// 
			panelBlock.Location = new Point(420, 10);
			panelBlock.Name = "panelBlock";
			panelBlock.Size = new Size(200, 200);
			panelBlock.TabIndex = 10;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ButtonShadow;
			ClientSize = new Size(800, 450);
			Controls.Add(panelBlock);
			Controls.Add(labelScoreLabel);
			Controls.Add(labelScoreScore);
			Controls.Add(buttonPause);
			Controls.Add(panelMenu);
			Controls.Add(panelGame);
			KeyPreview = true;
			Name = "Form1";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Game";
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
		private Button buttonLoadGame;
		private Button buttonSaveGame;
		private Label labelTitle;
		private Label labelScoreScore;
		private Label labelScoreLabel;
		private Panel panelBlock;
	}
}
