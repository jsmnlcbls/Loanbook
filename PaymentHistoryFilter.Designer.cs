namespace LoanBook
{
	partial class PaymentHistoryFilter
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
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(79, 11);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(266, 21);
			this.comboBox1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(31, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Loan";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(18, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Start Date";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePicker1.Location = new System.Drawing.Point(79, 38);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(116, 20);
			this.dateTimePicker1.TabIndex = 6;
			// 
			// dateTimePicker2
			// 
			this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePicker2.Location = new System.Drawing.Point(79, 64);
			this.dateTimePicker2.Name = "dateTimePicker2";
			this.dateTimePicker2.Size = new System.Drawing.Size(116, 20);
			this.dateTimePicker2.TabIndex = 8;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(18, 67);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(52, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "End Date";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(138, 104);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 9;
			this.button1.Text = "Apply";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// PaymentHistoryFilter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(356, 136);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dateTimePicker2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBox1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PaymentHistoryFilter";
			this.Text = "History Filter";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.DateTimePicker dateTimePicker2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button1;
	}
}