namespace LoanBook
{
	partial class PaymentForm
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
			this.loanSelector = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.paymentAmount = new System.Windows.Forms.TextBox();
			this.saveButton = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.accountName = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.paymentDate = new System.Windows.Forms.DateTimePicker();
			this.interestOnlyCheckbox = new System.Windows.Forms.CheckBox();
			this.remarks = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.halfPaymentCheckbox = new System.Windows.Forms.CheckBox();
			this.principalPayment = new System.Windows.Forms.TextBox();
			this.interestPayment = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// loanSelector
			// 
			this.loanSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.loanSelector.FormattingEnabled = true;
			this.loanSelector.Location = new System.Drawing.Point(60, 34);
			this.loanSelector.Name = "loanSelector";
			this.loanSelector.Size = new System.Drawing.Size(287, 21);
			this.loanSelector.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(23, 37);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(31, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Loan";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 74);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(43, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Amount";
			// 
			// paymentAmount
			// 
			this.paymentAmount.Location = new System.Drawing.Point(60, 71);
			this.paymentAmount.Name = "paymentAmount";
			this.paymentAmount.Size = new System.Drawing.Size(72, 20);
			this.paymentAmount.TabIndex = 3;
			this.paymentAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// saveButton
			// 
			this.saveButton.Location = new System.Drawing.Point(153, 242);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(75, 23);
			this.saveButton.TabIndex = 7;
			this.saveButton.Text = "Save";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(8, 9);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(47, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Account";
			// 
			// accountName
			// 
			this.accountName.AutoSize = true;
			this.accountName.Location = new System.Drawing.Point(65, 9);
			this.accountName.Name = "accountName";
			this.accountName.Size = new System.Drawing.Size(78, 13);
			this.accountName.TabIndex = 9;
			this.accountName.Text = "Account Name";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(23, 151);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(30, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "Date";
			// 
			// paymentDate
			// 
			this.paymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.paymentDate.Location = new System.Drawing.Point(60, 148);
			this.paymentDate.Name = "paymentDate";
			this.paymentDate.Size = new System.Drawing.Size(115, 20);
			this.paymentDate.TabIndex = 12;
			// 
			// interestOnlyCheckbox
			// 
			this.interestOnlyCheckbox.AutoSize = true;
			this.interestOnlyCheckbox.Location = new System.Drawing.Point(153, 73);
			this.interestOnlyCheckbox.Name = "interestOnlyCheckbox";
			this.interestOnlyCheckbox.Size = new System.Drawing.Size(85, 17);
			this.interestOnlyCheckbox.TabIndex = 13;
			this.interestOnlyCheckbox.Text = "Interest Only";
			this.interestOnlyCheckbox.UseVisualStyleBackColor = true;
			// 
			// remarks
			// 
			this.remarks.Location = new System.Drawing.Point(60, 177);
			this.remarks.Multiline = true;
			this.remarks.Name = "remarks";
			this.remarks.Size = new System.Drawing.Size(168, 56);
			this.remarks.TabIndex = 14;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 180);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(49, 13);
			this.label5.TabIndex = 15;
			this.label5.Text = "Remarks";
			// 
			// halfPaymentCheckbox
			// 
			this.halfPaymentCheckbox.AutoSize = true;
			this.halfPaymentCheckbox.Location = new System.Drawing.Point(248, 73);
			this.halfPaymentCheckbox.Name = "halfPaymentCheckbox";
			this.halfPaymentCheckbox.Size = new System.Drawing.Size(89, 17);
			this.halfPaymentCheckbox.TabIndex = 16;
			this.halfPaymentCheckbox.Text = "Half Payment";
			this.halfPaymentCheckbox.UseVisualStyleBackColor = true;
			// 
			// principalPayment
			// 
			this.principalPayment.Location = new System.Drawing.Point(116, 96);
			this.principalPayment.Name = "principalPayment";
			this.principalPayment.ReadOnly = true;
			this.principalPayment.Size = new System.Drawing.Size(72, 20);
			this.principalPayment.TabIndex = 17;
			this.principalPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// interestPayment
			// 
			this.interestPayment.Location = new System.Drawing.Point(116, 122);
			this.interestPayment.Name = "interestPayment";
			this.interestPayment.ReadOnly = true;
			this.interestPayment.Size = new System.Drawing.Size(72, 20);
			this.interestPayment.TabIndex = 18;
			this.interestPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(66, 99);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(47, 13);
			this.label6.TabIndex = 19;
			this.label6.Text = "Principal";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(71, 125);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(42, 13);
			this.label7.TabIndex = 20;
			this.label7.Text = "Interest";
			// 
			// PaymentForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(371, 272);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.interestPayment);
			this.Controls.Add(this.principalPayment);
			this.Controls.Add(this.halfPaymentCheckbox);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.remarks);
			this.Controls.Add(this.interestOnlyCheckbox);
			this.Controls.Add(this.paymentDate);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.accountName);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.paymentAmount);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.loanSelector);
			this.Name = "PaymentForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "6";
			this.Load += new System.EventHandler(this.PaymentForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox loanSelector;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox paymentAmount;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label accountName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker paymentDate;
		private System.Windows.Forms.CheckBox interestOnlyCheckbox;
		private System.Windows.Forms.TextBox remarks;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox halfPaymentCheckbox;
		private System.Windows.Forms.TextBox principalPayment;
		private System.Windows.Forms.TextBox interestPayment;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
	}
}