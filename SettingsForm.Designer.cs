namespace LoanBook
{
	partial class SettingsForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.databaseFileInput = new System.Windows.Forms.TextBox();
			this.databaseFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.browseButton = new System.Windows.Forms.Button();
			this.saveButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Database File";
			// 
			// databaseFileInput
			// 
			this.databaseFileInput.Location = new System.Drawing.Point(90, 17);
			this.databaseFileInput.Name = "databaseFileInput";
			this.databaseFileInput.Size = new System.Drawing.Size(188, 20);
			this.databaseFileInput.TabIndex = 1;
			// 
			// databaseFileDialog
			// 
			this.databaseFileDialog.FileName = "openFileDialog1";
			// 
			// browseButton
			// 
			this.browseButton.Location = new System.Drawing.Point(284, 14);
			this.browseButton.Name = "browseButton";
			this.browseButton.Size = new System.Drawing.Size(61, 23);
			this.browseButton.TabIndex = 2;
			this.browseButton.Text = "Browse";
			this.browseButton.UseVisualStyleBackColor = true;
			this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
			// 
			// saveButton
			// 
			this.saveButton.Location = new System.Drawing.Point(140, 64);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(75, 23);
			this.saveButton.TabIndex = 3;
			this.saveButton.Text = "Save";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(357, 110);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.browseButton);
			this.Controls.Add(this.databaseFileInput);
			this.Controls.Add(this.label1);
			this.Name = "SettingsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "SettingsForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox databaseFileInput;
		private System.Windows.Forms.OpenFileDialog databaseFileDialog;
		private System.Windows.Forms.Button browseButton;
		private System.Windows.Forms.Button saveButton;
	}
}