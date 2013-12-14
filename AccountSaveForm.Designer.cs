namespace LoanBook
{
	partial class AccountSaveForm
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
			this.nameInput = new System.Windows.Forms.TextBox();
			this.remarksInput = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.saveButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(17, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name";
			// 
			// nameInput
			// 
			this.nameInput.Location = new System.Drawing.Point(57, 6);
			this.nameInput.MaxLength = 64;
			this.nameInput.Name = "nameInput";
			this.nameInput.Size = new System.Drawing.Size(169, 20);
			this.nameInput.TabIndex = 1;
			// 
			// remarksInput
			// 
			this.remarksInput.Location = new System.Drawing.Point(57, 32);
			this.remarksInput.Multiline = true;
			this.remarksInput.Name = "remarksInput";
			this.remarksInput.Size = new System.Drawing.Size(169, 74);
			this.remarksInput.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 35);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Remarks";
			// 
			// saveButton
			// 
			this.saveButton.Location = new System.Drawing.Point(89, 112);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(75, 23);
			this.saveButton.TabIndex = 6;
			this.saveButton.Text = "Save";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// AccountSaveForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(232, 141);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.remarksInput);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.nameInput);
			this.Controls.Add(this.label1);
			this.Name = "AccountSaveForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox nameInput;
		private System.Windows.Forms.TextBox remarksInput;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button saveButton;
	}
}