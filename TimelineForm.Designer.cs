namespace LoanBook
{
	partial class TimelineForm
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
			this.startDate = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.goButton = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.specifyStartDateRadio = new System.Windows.Forms.RadioButton();
			this.startAtBeginningRadio = new System.Windows.Forms.RadioButton();
			this.panel2 = new System.Windows.Forms.Panel();
			this.specifyEndDateRadio = new System.Windows.Forms.RadioButton();
			this.todayEndDateRadio = new System.Windows.Forms.RadioButton();
			this.endDate = new System.Windows.Forms.DateTimePicker();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// startDate
			// 
			this.startDate.Enabled = false;
			this.startDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.startDate.Location = new System.Drawing.Point(24, 52);
			this.startDate.Name = "startDate";
			this.startDate.Size = new System.Drawing.Size(110, 20);
			this.startDate.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Start Date";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 112);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "End Date";
			// 
			// goButton
			// 
			this.goButton.Location = new System.Drawing.Point(81, 200);
			this.goButton.Name = "goButton";
			this.goButton.Size = new System.Drawing.Size(75, 23);
			this.goButton.TabIndex = 4;
			this.goButton.Text = "Go";
			this.goButton.UseVisualStyleBackColor = true;
			this.goButton.Click += new System.EventHandler(this.goButton_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.specifyStartDateRadio);
			this.panel1.Controls.Add(this.startAtBeginningRadio);
			this.panel1.Controls.Add(this.startDate);
			this.panel1.Location = new System.Drawing.Point(76, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(162, 78);
			this.panel1.TabIndex = 5;
			// 
			// specifyStartDateRadio
			// 
			this.specifyStartDateRadio.AutoSize = true;
			this.specifyStartDateRadio.Location = new System.Drawing.Point(5, 29);
			this.specifyStartDateRadio.Name = "specifyStartDateRadio";
			this.specifyStartDateRadio.Size = new System.Drawing.Size(86, 17);
			this.specifyStartDateRadio.TabIndex = 1;
			this.specifyStartDateRadio.TabStop = true;
			this.specifyStartDateRadio.Text = "Specify Date";
			this.specifyStartDateRadio.UseVisualStyleBackColor = true;
			this.specifyStartDateRadio.CheckedChanged += new System.EventHandler(this.specifyStartDateRadio_CheckedChanged);
			// 
			// startAtBeginningRadio
			// 
			this.startAtBeginningRadio.AutoSize = true;
			this.startAtBeginningRadio.Checked = true;
			this.startAtBeginningRadio.Location = new System.Drawing.Point(5, 6);
			this.startAtBeginningRadio.Name = "startAtBeginningRadio";
			this.startAtBeginningRadio.Size = new System.Drawing.Size(108, 17);
			this.startAtBeginningRadio.TabIndex = 0;
			this.startAtBeginningRadio.TabStop = true;
			this.startAtBeginningRadio.Text = "Start at beginning";
			this.startAtBeginningRadio.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.specifyEndDateRadio);
			this.panel2.Controls.Add(this.todayEndDateRadio);
			this.panel2.Controls.Add(this.endDate);
			this.panel2.Location = new System.Drawing.Point(76, 102);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(162, 78);
			this.panel2.TabIndex = 6;
			// 
			// specifyEndDateRadio
			// 
			this.specifyEndDateRadio.AutoSize = true;
			this.specifyEndDateRadio.Location = new System.Drawing.Point(5, 29);
			this.specifyEndDateRadio.Name = "specifyEndDateRadio";
			this.specifyEndDateRadio.Size = new System.Drawing.Size(86, 17);
			this.specifyEndDateRadio.TabIndex = 1;
			this.specifyEndDateRadio.TabStop = true;
			this.specifyEndDateRadio.Text = "Specify Date";
			this.specifyEndDateRadio.UseVisualStyleBackColor = true;
			this.specifyEndDateRadio.CheckedChanged += new System.EventHandler(this.specifyEndDateRadio_CheckedChanged);
			// 
			// todayEndDateRadio
			// 
			this.todayEndDateRadio.AutoSize = true;
			this.todayEndDateRadio.Checked = true;
			this.todayEndDateRadio.Location = new System.Drawing.Point(5, 6);
			this.todayEndDateRadio.Name = "todayEndDateRadio";
			this.todayEndDateRadio.Size = new System.Drawing.Size(55, 17);
			this.todayEndDateRadio.TabIndex = 0;
			this.todayEndDateRadio.TabStop = true;
			this.todayEndDateRadio.Text = "Today";
			this.todayEndDateRadio.UseVisualStyleBackColor = true;
			// 
			// endDate
			// 
			this.endDate.Enabled = false;
			this.endDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.endDate.Location = new System.Drawing.Point(24, 52);
			this.endDate.Name = "endDate";
			this.endDate.Size = new System.Drawing.Size(110, 20);
			this.endDate.TabIndex = 0;
			// 
			// TimelineForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(251, 244);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.goButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "TimelineForm";
			this.Text = "Timeline";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DateTimePicker startDate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button goButton;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.RadioButton specifyStartDateRadio;
		private System.Windows.Forms.RadioButton startAtBeginningRadio;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.RadioButton specifyEndDateRadio;
		private System.Windows.Forms.RadioButton todayEndDateRadio;
		private System.Windows.Forms.DateTimePicker endDate;
	}
}