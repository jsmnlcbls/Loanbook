namespace LoanBook
{
	partial class NextMonthPaymentForm
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
			this.nextPaymentsGrid = new System.Windows.Forms.DataGridView();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.totalGrid = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.nextPaymentsGrid)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.totalGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// nextPaymentsGrid
			// 
			this.nextPaymentsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.nextPaymentsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.nextPaymentsGrid.Location = new System.Drawing.Point(0, 0);
			this.nextPaymentsGrid.Name = "nextPaymentsGrid";
			this.nextPaymentsGrid.Size = new System.Drawing.Size(280, 315);
			this.nextPaymentsGrid.TabIndex = 0;
			// 
			// splitContainer
			// 
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer.IsSplitterFixed = true;
			this.splitContainer.Location = new System.Drawing.Point(0, 0);
			this.splitContainer.Margin = new System.Windows.Forms.Padding(0);
			this.splitContainer.Name = "splitContainer";
			this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.nextPaymentsGrid);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.totalGrid);
			this.splitContainer.Panel2MinSize = 20;
			this.splitContainer.Size = new System.Drawing.Size(280, 337);
			this.splitContainer.SplitterDistance = 315;
			this.splitContainer.SplitterWidth = 2;
			this.splitContainer.TabIndex = 1;
			// 
			// totalGrid
			// 
			this.totalGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.totalGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.totalGrid.Location = new System.Drawing.Point(0, 0);
			this.totalGrid.Name = "totalGrid";
			this.totalGrid.Size = new System.Drawing.Size(280, 20);
			this.totalGrid.TabIndex = 0;
			// 
			// NextMonthPaymentForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(280, 337);
			this.Controls.Add(this.splitContainer);
			this.Name = "NextMonthPaymentForm";
			this.Text = "Next Month Payments";
			this.Load += new System.EventHandler(this.FutureCashFlowForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.nextPaymentsGrid)).EndInit();
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			this.splitContainer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.totalGrid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView nextPaymentsGrid;
		private System.Windows.Forms.SplitContainer splitContainer;
		private System.Windows.Forms.DataGridView totalGrid;
	}
}