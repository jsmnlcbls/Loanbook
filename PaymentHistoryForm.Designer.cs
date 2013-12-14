namespace LoanBook
{
	partial class PaymentHistoryForm
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
			this.historyGrid = new System.Windows.Forms.DataGridView();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.paymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.historyGrid)).BeginInit();
			this.menuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// historyGrid
			// 
			this.historyGrid.AllowUserToAddRows = false;
			this.historyGrid.AllowUserToDeleteRows = false;
			this.historyGrid.AllowUserToResizeColumns = false;
			this.historyGrid.AllowUserToResizeRows = false;
			this.historyGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.historyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.historyGrid.Location = new System.Drawing.Point(0, 24);
			this.historyGrid.Name = "historyGrid";
			this.historyGrid.ReadOnly = true;
			this.historyGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.historyGrid.Size = new System.Drawing.Size(639, 288);
			this.historyGrid.TabIndex = 1;
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paymentToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(639, 24);
			this.menuStrip.TabIndex = 2;
			this.menuStrip.Text = "menuStrip1";
			// 
			// paymentToolStripMenuItem
			// 
			this.paymentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
			this.paymentToolStripMenuItem.Name = "paymentToolStripMenuItem";
			this.paymentToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
			this.paymentToolStripMenuItem.Text = "Payment";
			// 
			// addToolStripMenuItem
			// 
			this.addToolStripMenuItem.Name = "addToolStripMenuItem";
			this.addToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.addToolStripMenuItem.Text = "Add";
			this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.editToolStripMenuItem.Text = "Edit";
			this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
			// 
			// PaymentHistoryForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(639, 312);
			this.Controls.Add(this.historyGrid);
			this.Controls.Add(this.menuStrip);
			this.Name = "PaymentHistoryForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Loan Payment History";
			this.Load += new System.EventHandler(this.PaymentHistory_Load);
			((System.ComponentModel.ISupportInitialize)(this.historyGrid)).EndInit();
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView historyGrid;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem paymentToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;

	}
}