namespace Gombavadaszat
{
	partial class ButtonHunter
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
			pushButton = new Button();
			statusStrip = new StatusStrip();
			statusLabel = new ToolStripStatusLabel();
			this.timer = new System.Windows.Forms.Timer(components);
			statusStrip.SuspendLayout();
			SuspendLayout();
			// 
			// pushButton
			// 
			pushButton.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
			pushButton.Location = new Point(367, 304);
			pushButton.Margin = new Padding(0);
			pushButton.Name = "pushButton";
			pushButton.Size = new Size(170, 70);
			pushButton.TabIndex = 0;
			pushButton.Text = "Push me!";
			pushButton.UseVisualStyleBackColor = true;
			pushButton.Click += ButtonClicked;
			// 
			// statusStrip
			// 
			statusStrip.ImageScalingSize = new Size(20, 20);
			statusStrip.Items.AddRange(new ToolStripItem[] { statusLabel });
			statusStrip.Location = new Point(0, 677);
			statusStrip.Name = "statusStrip";
			statusStrip.Size = new Size(1032, 26);
			statusStrip.TabIndex = 1;
			statusStrip.Text = "statusStrip";
			// 
			// statusLabel
			// 
			statusLabel.Name = "statusLabel";
			statusLabel.Size = new Size(235, 20);
			statusLabel.Text = "Click the button to start the game!";
			// 
			// timer
			// 
			timer.Interval = 1000;
			// 
			// ButtonHunter
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1032, 703);
			Controls.Add(statusStrip);
			Controls.Add(pushButton);
			MinimumSize = new Size(400, 300);
			Name = "ButtonHunter";
			Text = "ButtonHunter";
			statusStrip.ResumeLayout(false);
			statusStrip.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button pushButton;
		private StatusStrip statusStrip;
		private ToolStripStatusLabel statusLabel;
		private System.Windows.Forms.Timer timer;
	}
}