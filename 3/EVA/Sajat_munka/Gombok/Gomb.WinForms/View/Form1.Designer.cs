namespace HOK.Gomb.WinForms.View
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
			button1 = new Button();
			button2 = new Button();
			label1 = new Label();
			label2 = new Label();
			buttonSave = new Button();
			buttonLoad = new Button();
			saveFileDialog = new SaveFileDialog();
			openFileDialog = new OpenFileDialog();
			SuspendLayout();
			// 
			// button1
			// 
			button1.Location = new Point(237, 41);
			button1.Name = "button1";
			button1.Size = new Size(94, 29);
			button1.TabIndex = 0;
			button1.Text = "1";
			button1.UseVisualStyleBackColor = true;
			button1.Click += Button1_Click;
			// 
			// button2
			// 
			button2.Location = new Point(237, 134);
			button2.Name = "button2";
			button2.Size = new Size(94, 29);
			button2.TabIndex = 1;
			button2.Text = "2";
			button2.UseVisualStyleBackColor = true;
			button2.Click += Button2_Click;
			// 
			// label1
			// 
			label1.BackColor = SystemColors.ActiveCaptionText;
			label1.Location = new Point(83, 29);
			label1.Name = "label1";
			label1.Size = new Size(50, 50);
			label1.TabIndex = 2;
			// 
			// label2
			// 
			label2.BackColor = SystemColors.ActiveCaptionText;
			label2.Location = new Point(83, 125);
			label2.Name = "label2";
			label2.Size = new Size(50, 50);
			label2.TabIndex = 3;
			// 
			// buttonSave
			// 
			buttonSave.Location = new Point(97, 212);
			buttonSave.Name = "buttonSave";
			buttonSave.Size = new Size(94, 29);
			buttonSave.TabIndex = 4;
			buttonSave.Text = "Save";
			buttonSave.UseVisualStyleBackColor = true;
			buttonSave.Click += ButtonSave_Click;
			// 
			// buttonLoad
			// 
			buttonLoad.Location = new Point(197, 212);
			buttonLoad.Name = "buttonLoad";
			buttonLoad.Size = new Size(94, 29);
			buttonLoad.TabIndex = 5;
			buttonLoad.Text = "Load";
			buttonLoad.UseVisualStyleBackColor = true;
			buttonLoad.Click += ButtonLoad_Click;
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "Gombok (*.stl)|*.stl";
			this.openFileDialog.Title = "Gombok betöltése";
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.Filter = "Gombok (*.stl)|*.stl";
			this.saveFileDialog.Title = "Gombok mentése";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(395, 253);
			Controls.Add(buttonLoad);
			Controls.Add(buttonSave);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(button2);
			Controls.Add(button1);
			Name = "Form1";
			Text = "Form1";
			ResumeLayout(false);
		}

		#endregion

		private Button button1;
		private Button button2;
		private Label label1;
		private Label label2;
		private Button buttonSave;
		private Button buttonLoad;
		private SaveFileDialog saveFileDialog;
		private OpenFileDialog openFileDialog;
	}
}