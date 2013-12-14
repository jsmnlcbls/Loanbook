namespace LoanBook
{
	partial class ReloanSaveForm
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
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.loanSelector = new System.Windows.Forms.ComboBox();
			this.panel7 = new System.Windows.Forms.Panel();
			this.takenDateInput = new System.Windows.Forms.DateTimePicker();
			this.label11 = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.startDateInput = new System.Windows.Forms.DateTimePicker();
			this.label8 = new System.Windows.Forms.Label();
			this.panel9 = new System.Windows.Forms.Panel();
			this.remarks = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.panel11 = new System.Windows.Forms.Panel();
			this.releaseAmount = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.endDate = new System.Windows.Forms.Label();
			this.monthlyDue = new System.Windows.Forms.Label();
			this.panel10 = new System.Windows.Forms.Panel();
			this.saveButton = new System.Windows.Forms.Button();
			this.flowLayoutPanel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel9.SuspendLayout();
			this.panel11.SuspendLayout();
			this.panel10.SuspendLayout();
			this.SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.panel2);
			this.flowLayoutPanel1.Controls.Add(this.panel7);
			this.flowLayoutPanel1.Controls.Add(this.panel8);
			this.flowLayoutPanel1.Controls.Add(this.panel9);
			this.flowLayoutPanel1.Controls.Add(this.panel11);
			this.flowLayoutPanel1.Controls.Add(this.panel10);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(284, 262);
			this.flowLayoutPanel1.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.loanSelector);
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(284, 27);
			this.panel2.TabIndex = 27;
			// 
			// loanSelector
			// 
			this.loanSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.loanSelector.FormattingEnabled = true;
			this.loanSelector.Location = new System.Drawing.Point(3, 3);
			this.loanSelector.Name = "loanSelector";
			this.loanSelector.Size = new System.Drawing.Size(278, 21);
			this.loanSelector.TabIndex = 0;
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.takenDateInput);
			this.panel7.Controls.Add(this.label11);
			this.panel7.Location = new System.Drawing.Point(0, 30);
			this.panel7.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(277, 29);
			this.panel7.TabIndex = 35;
			// 
			// takenDateInput
			// 
			this.takenDateInput.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.takenDateInput.Location = new System.Drawing.Point(97, 4);
			this.takenDateInput.Name = "takenDateInput";
			this.takenDateInput.Size = new System.Drawing.Size(110, 20);
			this.takenDateInput.TabIndex = 7;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(35, 7);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(57, 13);
			this.label11.TabIndex = 28;
			this.label11.Text = "Loan Date";
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.startDateInput);
			this.panel8.Controls.Add(this.label8);
			this.panel8.Location = new System.Drawing.Point(0, 62);
			this.panel8.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(277, 29);
			this.panel8.TabIndex = 36;
			// 
			// startDateInput
			// 
			this.startDateInput.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.startDateInput.Location = new System.Drawing.Point(97, 5);
			this.startDateInput.Name = "startDateInput";
			this.startDateInput.Size = new System.Drawing.Size(110, 20);
			this.startDateInput.TabIndex = 8;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(19, 8);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(73, 13);
			this.label8.TabIndex = 19;
			this.label8.Text = "Payment Start";
			// 
			// panel9
			// 
			this.panel9.Controls.Add(this.remarks);
			this.panel9.Controls.Add(this.label10);
			this.panel9.Location = new System.Drawing.Point(0, 94);
			this.panel9.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(277, 59);
			this.panel9.TabIndex = 37;
			// 
			// remarks
			// 
			this.remarks.Location = new System.Drawing.Point(96, 3);
			this.remarks.Multiline = true;
			this.remarks.Name = "remarks";
			this.remarks.Size = new System.Drawing.Size(170, 53);
			this.remarks.TabIndex = 9;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(43, 6);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(49, 13);
			this.label10.TabIndex = 24;
			this.label10.Text = "Remarks";
			// 
			// panel11
			// 
			this.panel11.Controls.Add(this.releaseAmount);
			this.panel11.Controls.Add(this.label15);
			this.panel11.Controls.Add(this.label9);
			this.panel11.Controls.Add(this.label7);
			this.panel11.Controls.Add(this.endDate);
			this.panel11.Controls.Add(this.monthlyDue);
			this.panel11.Location = new System.Drawing.Point(0, 156);
			this.panel11.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
			this.panel11.Name = "panel11";
			this.panel11.Size = new System.Drawing.Size(277, 66);
			this.panel11.TabIndex = 38;
			// 
			// releaseAmount
			// 
			this.releaseAmount.AutoSize = true;
			this.releaseAmount.Location = new System.Drawing.Point(96, 28);
			this.releaseAmount.MinimumSize = new System.Drawing.Size(50, 0);
			this.releaseAmount.Name = "releaseAmount";
			this.releaseAmount.Size = new System.Drawing.Size(50, 13);
			this.releaseAmount.TabIndex = 5;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(3, 28);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(85, 13);
			this.label15.TabIndex = 4;
			this.label15.Text = "Release Amount";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(35, 50);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(52, 13);
			this.label9.TabIndex = 3;
			this.label9.Text = "End Date";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(22, 7);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(67, 13);
			this.label7.TabIndex = 2;
			this.label7.Text = "Monthly Due";
			// 
			// endDate
			// 
			this.endDate.AutoSize = true;
			this.endDate.Location = new System.Drawing.Point(97, 50);
			this.endDate.MinimumSize = new System.Drawing.Size(50, 0);
			this.endDate.Name = "endDate";
			this.endDate.Size = new System.Drawing.Size(50, 13);
			this.endDate.TabIndex = 1;
			// 
			// monthlyDue
			// 
			this.monthlyDue.AutoSize = true;
			this.monthlyDue.Location = new System.Drawing.Point(97, 7);
			this.monthlyDue.MinimumSize = new System.Drawing.Size(50, 0);
			this.monthlyDue.Name = "monthlyDue";
			this.monthlyDue.Size = new System.Drawing.Size(50, 13);
			this.monthlyDue.TabIndex = 0;
			// 
			// panel10
			// 
			this.panel10.Controls.Add(this.saveButton);
			this.panel10.Location = new System.Drawing.Point(0, 225);
			this.panel10.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
			this.panel10.Name = "panel10";
			this.panel10.Size = new System.Drawing.Size(277, 29);
			this.panel10.TabIndex = 38;
			// 
			// saveButton
			// 
			this.saveButton.Location = new System.Drawing.Point(110, 3);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(58, 23);
			this.saveButton.TabIndex = 10;
			this.saveButton.Text = "Save";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// ReloanSaveForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Name = "ReloanSaveForm";
			this.Text = "Reloan";
			this.Load += new System.EventHandler(this.ReloanSaveForm_Load);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			this.panel11.ResumeLayout(false);
			this.panel11.PerformLayout();
			this.panel10.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ComboBox loanSelector;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.DateTimePicker takenDateInput;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.DateTimePicker startDateInput;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.TextBox remarks;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Panel panel11;
		private System.Windows.Forms.Label releaseAmount;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label endDate;
		private System.Windows.Forms.Label monthlyDue;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.Button saveButton;
	}
}