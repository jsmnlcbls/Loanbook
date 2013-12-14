namespace LoanBook
{
	partial class LoanBookForm
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addLoanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewLoanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.paymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.timelineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.customTimelineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pastToPresentTimelineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.allTimelineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.nextMonthPayments = new System.Windows.Forms.ToolStripMenuItem();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.summaryGrid = new LoanBook.GridView();
			this.totalGrid = new System.Windows.Forms.DataGridView();
			this.menuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.summaryGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.totalGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountToolStripMenuItem,
            this.loanToolStripMenuItem,
            this.timelineToolStripMenuItem,
            this.reportsToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(1023, 24);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "menuStrip1";
			// 
			// accountToolStripMenuItem
			// 
			this.accountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
			this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
			this.accountToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
			this.accountToolStripMenuItem.Text = "Account";
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
			this.editToolStripMenuItem.Click += new System.EventHandler(this.editAccountToolStripMenuItem_Click);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
			// 
			// loanToolStripMenuItem
			// 
			this.loanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addLoanToolStripMenuItem,
            this.viewLoanToolStripMenuItem,
            this.paymentToolStripMenuItem});
			this.loanToolStripMenuItem.Name = "loanToolStripMenuItem";
			this.loanToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
			this.loanToolStripMenuItem.Text = "Loan";
			// 
			// addLoanToolStripMenuItem
			// 
			this.addLoanToolStripMenuItem.Name = "addLoanToolStripMenuItem";
			this.addLoanToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.addLoanToolStripMenuItem.Text = "Add";
			this.addLoanToolStripMenuItem.Click += new System.EventHandler(this.addLoanToolStripMenuItem_Click);
			// 
			// viewLoanToolStripMenuItem
			// 
			this.viewLoanToolStripMenuItem.Name = "viewLoanToolStripMenuItem";
			this.viewLoanToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.viewLoanToolStripMenuItem.Text = "Details";
			this.viewLoanToolStripMenuItem.Click += new System.EventHandler(this.viewLoanToolStripMenuItem_Click);
			// 
			// paymentToolStripMenuItem
			// 
			this.paymentToolStripMenuItem.Name = "paymentToolStripMenuItem";
			this.paymentToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.paymentToolStripMenuItem.Text = "Payment";
			this.paymentToolStripMenuItem.Click += new System.EventHandler(this.paymentToolStripMenuItem_Click);
			// 
			// timelineToolStripMenuItem
			// 
			this.timelineToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customTimelineToolStripMenuItem,
            this.pastToPresentTimelineToolStripMenuItem,
            this.allTimelineToolStripMenuItem});
			this.timelineToolStripMenuItem.Name = "timelineToolStripMenuItem";
			this.timelineToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
			this.timelineToolStripMenuItem.Text = "Timeline";
			// 
			// customTimelineToolStripMenuItem
			// 
			this.customTimelineToolStripMenuItem.CheckOnClick = true;
			this.customTimelineToolStripMenuItem.Name = "customTimelineToolStripMenuItem";
			this.customTimelineToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.customTimelineToolStripMenuItem.Text = "Custom";
			this.customTimelineToolStripMenuItem.Click += new System.EventHandler(this.customTimelineToolStripMenuItem_Click);
			// 
			// pastToPresentTimelineToolStripMenuItem
			// 
			this.pastToPresentTimelineToolStripMenuItem.Checked = true;
			this.pastToPresentTimelineToolStripMenuItem.CheckOnClick = true;
			this.pastToPresentTimelineToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.pastToPresentTimelineToolStripMenuItem.Name = "pastToPresentTimelineToolStripMenuItem";
			this.pastToPresentTimelineToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.pastToPresentTimelineToolStripMenuItem.Text = "Past - Present Day";
			this.pastToPresentTimelineToolStripMenuItem.Click += new System.EventHandler(this.pastToPresentTimelineToolStripMenuItem_Click);
			// 
			// allTimelineToolStripMenuItem
			// 
			this.allTimelineToolStripMenuItem.CheckOnClick = true;
			this.allTimelineToolStripMenuItem.Name = "allTimelineToolStripMenuItem";
			this.allTimelineToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.allTimelineToolStripMenuItem.Text = "All";
			this.allTimelineToolStripMenuItem.Click += new System.EventHandler(this.allTimelineToolStripMenuItem_Click);
			// 
			// reportsToolStripMenuItem
			// 
			this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nextMonthPayments});
			this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
			this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
			this.reportsToolStripMenuItem.Text = "Reports";
			// 
			// nextMonthPayments
			// 
			this.nextMonthPayments.Name = "nextMonthPayments";
			this.nextMonthPayments.Size = new System.Drawing.Size(192, 22);
			this.nextMonthPayments.Text = "Next Month Payments";
			this.nextMonthPayments.Click += new System.EventHandler(this.nextMonthPaymentsToolStripMenuItem_Click);
			// 
			// splitContainer
			// 
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer.IsSplitterFixed = true;
			this.splitContainer.Location = new System.Drawing.Point(0, 24);
			this.splitContainer.Name = "splitContainer";
			this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.summaryGrid);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.totalGrid);
			this.splitContainer.Panel2MinSize = 20;
			this.splitContainer.Size = new System.Drawing.Size(1023, 338);
			this.splitContainer.SplitterDistance = 316;
			this.splitContainer.SplitterWidth = 2;
			this.splitContainer.TabIndex = 4;
			// 
			// summaryGrid
			// 
			this.summaryGrid.AllowUserToAddRows = false;
			this.summaryGrid.AllowUserToDeleteRows = false;
			this.summaryGrid.AllowUserToResizeColumns = false;
			this.summaryGrid.AllowUserToResizeRows = false;
			this.summaryGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.summaryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.summaryGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.summaryGrid.Location = new System.Drawing.Point(0, 0);
			this.summaryGrid.MultiSelect = false;
			this.summaryGrid.Name = "summaryGrid";
			this.summaryGrid.ReadOnly = true;
			this.summaryGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			this.summaryGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.summaryGrid.Size = new System.Drawing.Size(1023, 316);
			this.summaryGrid.TabIndex = 2;
			// 
			// totalGrid
			// 
			this.totalGrid.AllowUserToAddRows = false;
			this.totalGrid.AllowUserToDeleteRows = false;
			this.totalGrid.AllowUserToOrderColumns = true;
			this.totalGrid.AllowUserToResizeColumns = false;
			this.totalGrid.AllowUserToResizeRows = false;
			this.totalGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.totalGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.totalGrid.DefaultCellStyle = dataGridViewCellStyle1;
			this.totalGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.totalGrid.GridColor = System.Drawing.SystemColors.AppWorkspace;
			this.totalGrid.Location = new System.Drawing.Point(0, 0);
			this.totalGrid.Margin = new System.Windows.Forms.Padding(0);
			this.totalGrid.MultiSelect = false;
			this.totalGrid.Name = "totalGrid";
			this.totalGrid.ReadOnly = true;
			this.totalGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.totalGrid.RowHeadersVisible = false;
			this.totalGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.totalGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.totalGrid.Size = new System.Drawing.Size(1023, 20);
			this.totalGrid.TabIndex = 1;
			// 
			// LoanBookForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1023, 362);
			this.Controls.Add(this.splitContainer);
			this.Controls.Add(this.menuStrip);
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip;
			this.Name = "LoanBookForm";
			this.Text = "LoanBook";
			this.Load += new System.EventHandler(this.LoanBookForm_Load);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.summaryGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.totalGrid)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loanToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addLoanToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewLoanToolStripMenuItem;
		private System.Windows.Forms.SplitContainer splitContainer;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private GridView summaryGrid;
		private System.Windows.Forms.DataGridView totalGrid;
		private System.Windows.Forms.ToolStripMenuItem timelineToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem customTimelineToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem allTimelineToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem nextMonthPayments;
		private System.Windows.Forms.ToolStripMenuItem pastToPresentTimelineToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem paymentToolStripMenuItem;
	}
}

