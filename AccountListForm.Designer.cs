namespace LoanBook
{
	partial class AccountListForm
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
			this.accountListGrid = new System.Windows.Forms.DataGridView();
			this.editButton = new System.Windows.Forms.Button();
			this.transactionButton = new System.Windows.Forms.Button();
			this.refreshButton = new System.Windows.Forms.Button();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.accountListGrid)).BeginInit();
			this.flowLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// accountListGrid
			// 
			this.accountListGrid.AllowUserToAddRows = false;
			this.accountListGrid.AllowUserToDeleteRows = false;
			this.accountListGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.accountListGrid.Location = new System.Drawing.Point(3, 3);
			this.accountListGrid.Name = "accountListGrid";
			this.accountListGrid.RowHeadersVisible = false;
			this.accountListGrid.Size = new System.Drawing.Size(285, 238);
			this.accountListGrid.TabIndex = 0;
			// 
			// editButton
			// 
			this.editButton.Location = new System.Drawing.Point(119, 3);
			this.editButton.Name = "editButton";
			this.editButton.Size = new System.Drawing.Size(77, 23);
			this.editButton.TabIndex = 1;
			this.editButton.Text = "Edit Account";
			this.editButton.UseVisualStyleBackColor = true;
			this.editButton.Click += new System.EventHandler(this.editButton_Click);
			// 
			// transactionButton
			// 
			this.transactionButton.Location = new System.Drawing.Point(202, 3);
			this.transactionButton.Name = "transactionButton";
			this.transactionButton.Size = new System.Drawing.Size(76, 23);
			this.transactionButton.TabIndex = 2;
			this.transactionButton.Text = "Transactions";
			this.transactionButton.UseVisualStyleBackColor = true;
			this.transactionButton.Click += new System.EventHandler(this.transactionButton_Click);
			// 
			// refreshButton
			// 
			this.refreshButton.Location = new System.Drawing.Point(3, 3);
			this.refreshButton.Name = "refreshButton";
			this.refreshButton.Size = new System.Drawing.Size(57, 23);
			this.refreshButton.TabIndex = 3;
			this.refreshButton.Text = "Refresh";
			this.refreshButton.UseVisualStyleBackColor = true;
			this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.accountListGrid);
			this.flowLayoutPanel1.Controls.Add(this.panel1);
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 1);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(288, 281);
			this.flowLayoutPanel1.TabIndex = 4;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.refreshButton);
			this.panel1.Controls.Add(this.editButton);
			this.panel1.Controls.Add(this.transactionButton);
			this.panel1.Location = new System.Drawing.Point(3, 247);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(285, 29);
			this.panel1.TabIndex = 1;
			// 
			// AccountListForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(294, 283);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Name = "AccountListForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "List Of Accounts";
			this.Load += new System.EventHandler(this.AccountListForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.accountListGrid)).EndInit();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView accountListGrid;
		private System.Windows.Forms.Button editButton;
		private System.Windows.Forms.Button transactionButton;
		private System.Windows.Forms.Button refreshButton;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
	}
}