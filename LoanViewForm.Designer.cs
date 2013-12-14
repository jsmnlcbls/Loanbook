namespace LoanBook
{
	partial class LoanViewForm
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
			this.loanGrid = new LoanBook.GridView();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.loanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reloanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.paymentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.addPaymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.loanGrid)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// loanGrid
			// 
			this.loanGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.loanGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.loanGrid.Location = new System.Drawing.Point(0, 24);
			this.loanGrid.Name = "loanGrid";
			this.loanGrid.ReadOnly = true;
			this.loanGrid.RowHeadersVisible = false;
			this.loanGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.loanGrid.Size = new System.Drawing.Size(827, 238);
			this.loanGrid.TabIndex = 0;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loanToolStripMenuItem,
            this.paymentToolStripMenuItem1});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(827, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// loanToolStripMenuItem
			// 
			this.loanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.reloanToolStripMenuItem});
			this.loanToolStripMenuItem.Name = "loanToolStripMenuItem";
			this.loanToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
			this.loanToolStripMenuItem.Text = "Loan";
			// 
			// addToolStripMenuItem
			// 
			this.addToolStripMenuItem.Name = "addToolStripMenuItem";
			this.addToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
			this.addToolStripMenuItem.Text = "Add";
			this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
			this.editToolStripMenuItem.Text = "Edit";
			this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
			// 
			// reloanToolStripMenuItem
			// 
			this.reloanToolStripMenuItem.Name = "reloanToolStripMenuItem";
			this.reloanToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
			this.reloanToolStripMenuItem.Text = "Reloan";
			this.reloanToolStripMenuItem.Click += new System.EventHandler(this.reloanToolStripMenuItem_Click);
			// 
			// paymentToolStripMenuItem1
			// 
			this.paymentToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPaymentToolStripMenuItem,
            this.historyToolStripMenuItem});
			this.paymentToolStripMenuItem1.Name = "paymentToolStripMenuItem1";
			this.paymentToolStripMenuItem1.Size = new System.Drawing.Size(66, 20);
			this.paymentToolStripMenuItem1.Text = "Payment";
			// 
			// addPaymentToolStripMenuItem
			// 
			this.addPaymentToolStripMenuItem.Name = "addPaymentToolStripMenuItem";
			this.addPaymentToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
			this.addPaymentToolStripMenuItem.Text = "Add";
			this.addPaymentToolStripMenuItem.Click += new System.EventHandler(this.addPaymentToolStripMenuItem_Click);
			// 
			// historyToolStripMenuItem
			// 
			this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
			this.historyToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
			this.historyToolStripMenuItem.Text = "History";
			this.historyToolStripMenuItem.Click += new System.EventHandler(this.historyToolStripMenuItem_Click);
			// 
			// LoanViewForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(827, 262);
			this.Controls.Add(this.loanGrid);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "LoanViewForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Account Loans";
			this.Load += new System.EventHandler(this.LoanViewForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.loanGrid)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView loanGrid;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem loanToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem reloanToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem paymentToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem addPaymentToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem historyToolStripMenuItem;
	}
}