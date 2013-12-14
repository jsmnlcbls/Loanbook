namespace LoanBook
{
	partial class TransactionsForm
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
			this.transactionsGrid = new System.Windows.Forms.DataGridView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.balance = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.totalLoans = new System.Windows.Forms.Label();
			this.totalPayments = new System.Windows.Forms.Label();
			this.loansMade = new System.Windows.Forms.Label();
			this.paymentsMade = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.transactionsGrid)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// transactionsGrid
			// 
			this.transactionsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.transactionsGrid.Location = new System.Drawing.Point(0, 0);
			this.transactionsGrid.Name = "transactionsGrid";
			this.transactionsGrid.Size = new System.Drawing.Size(288, 214);
			this.transactionsGrid.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.balance);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.totalLoans);
			this.panel1.Controls.Add(this.totalPayments);
			this.panel1.Controls.Add(this.loansMade);
			this.panel1.Controls.Add(this.paymentsMade);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(0, 217);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(288, 62);
			this.panel1.TabIndex = 1;
			// 
			// balance
			// 
			this.balance.AutoSize = true;
			this.balance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.balance.Location = new System.Drawing.Point(226, 49);
			this.balance.Name = "balance";
			this.balance.Size = new System.Drawing.Size(13, 13);
			this.balance.TabIndex = 9;
			this.balance.Text = "0";
			this.balance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(152, 49);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(46, 13);
			this.label6.TabIndex = 8;
			this.label6.Text = "Balance";
			// 
			// totalLoans
			// 
			this.totalLoans.AutoSize = true;
			this.totalLoans.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.totalLoans.Location = new System.Drawing.Point(226, 2);
			this.totalLoans.Name = "totalLoans";
			this.totalLoans.Size = new System.Drawing.Size(13, 13);
			this.totalLoans.TabIndex = 7;
			this.totalLoans.Text = "0";
			this.totalLoans.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// totalPayments
			// 
			this.totalPayments.AutoSize = true;
			this.totalPayments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.totalPayments.Location = new System.Drawing.Point(226, 22);
			this.totalPayments.Name = "totalPayments";
			this.totalPayments.Size = new System.Drawing.Size(13, 13);
			this.totalPayments.TabIndex = 6;
			this.totalPayments.Text = "0";
			this.totalPayments.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// loansMade
			// 
			this.loansMade.AutoSize = true;
			this.loansMade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.loansMade.Location = new System.Drawing.Point(60, 2);
			this.loansMade.Name = "loansMade";
			this.loansMade.Size = new System.Drawing.Size(13, 13);
			this.loansMade.TabIndex = 5;
			this.loansMade.Text = "0";
			// 
			// paymentsMade
			// 
			this.paymentsMade.AutoSize = true;
			this.paymentsMade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.paymentsMade.Location = new System.Drawing.Point(60, 22);
			this.paymentsMade.Name = "paymentsMade";
			this.paymentsMade.Size = new System.Drawing.Size(13, 13);
			this.paymentsMade.TabIndex = 4;
			this.paymentsMade.Text = "0";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 2);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(36, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Loans";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(167, 2);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(31, 13);
			this.label4.TabIndex = 2;
			this.label4.Text = "Total";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Payments";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(167, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(31, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Total";
			// 
			// TransactionsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(288, 280);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.transactionsGrid);
			this.Name = "TransactionsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Account Transactions";
			this.Load += new System.EventHandler(this.TransactionsForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.transactionsGrid)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView transactionsGrid;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label paymentsMade;
		private System.Windows.Forms.Label loansMade;
		private System.Windows.Forms.Label totalLoans;
		private System.Windows.Forms.Label totalPayments;
		private System.Windows.Forms.Label balance;
		private System.Windows.Forms.Label label6;
	}
}