using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace LoanBook
{
	class GridFormatter
	{
		private DataGridView grid;

		private enum Type
		{
			Name,
			Money,
			Number,
			Date,
			Text
		}

		public GridFormatter(DataGridView grid = null)
		{
			this.grid = grid;
		}

		public void DefaultFormat(DataGridView grid = null)
		{
			if (null == grid && null != this.grid)
			{
				grid = this.grid;
			}

			grid.BorderStyle = BorderStyle.None;
			grid.RowHeadersVisible = false;
			grid.MultiSelect = false;
			grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			makeReadOnly(grid);

			InvisibleColumn("id");
			InvisibleColumn("account_id");
			InvisibleColumn("loan_id");

			formatColumn("name", "Account Name", Type.Name);
			formatColumn("taken_date", "Loan Date", Type.Date);
			formatColumn("date_paid", "Payment Date", Type.Date);
			formatColumn("principal", "Principal", Type.Money);
			formatColumn("total_principal", "Total Principal", Type.Money);
			formatColumn("term", "Term", Type.Number);
			formatColumn("interest", "Interest", Type.Number, 55);
			formatColumn("interest_payment", "Interest Payment", Type.Money, 75);
			formatColumn("principal_payment", "Principal Payment", Type.Money, 75);
			formatColumn("total_principal_payment", "Total Principal Payment", Type.Money);
			formatColumn("total_interest_payment", "Total Interest Payment", Type.Money);
			formatColumn("monthly_due", "Monthly Due", Type.Money);
			formatColumn("start_date", "Start Date", Type.Date);
			formatColumn("total_payable", "Total Payable", Type.Money);
			formatColumn("payment_count", "Payments", Type.Number);
			formatColumn("loan_count", "Loans", Type.Number);
			formatColumn("amount", "Amount", Type.Money);
			formatColumn("total_payments", "Total Payments", Type.Money);
			formatColumn("processing_fee", "Processing Fee", Type.Money);
			formatColumn("reloan_fee", "Reloan Fee", Type.Money);
			formatColumn("total_processing_fee", "Total Processing Fee", Type.Money);
			formatColumn("total_reloan_fee", "Total Reloan Fee", Type.Money);
			formatColumn("balance", "Balance", Type.Money);
			formatColumn("profit", "Profit", Type.Money);
			formatColumn("remarks", "Remarks", Type.Text);
			formatColumn("next_payment", "Next Payment", Type.Money);

			alignColumnHeadersToCenter();
		}

		public void TotalGridFormat(DataGridView grid = null)
		{
			if (null == grid && null != this.grid)
			{
				grid = this.grid;
			}

			DefaultFormat(grid);
			grid.ColumnHeadersVisible = false;
			grid.BackgroundColor = SystemColors.AppWorkspace;
			grid.DefaultCellStyle.BackColor = SystemColors.Control;
			grid.ClearSelection();
			grid.SelectionChanged += new EventHandler(totalGrid_SelectionChanged);
		}

		public void MoneyColumn(DataGridViewColumn column, int width = 80)
		{
			column.Width = width;
			column.DefaultCellStyle.Format = "#,##0";
			column.CellTemplate.Style.Format = "#,##0";
			column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
		}

		public void NumberColumn(DataGridViewColumn column, int width = 55)
		{
			column.Width = width;
			column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		}

		public void DateColumn(DataGridViewColumn column, int width = 70)
		{
			column.Width = width;
			column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			column.DefaultCellStyle.Format = "MM/dd/yyyy";
		}

		public void NameColumn(DataGridViewColumn column, int width = 150)
		{
			column.Width = width;
			column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		}

		public void TextColumn(DataGridViewColumn column, int width = 150)
		{
			column.Width = 150;
			column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		}

		public void InvisibleColumn(string columnName)
		{
			if (grid.Columns.Contains(columnName))
			{
				grid.Columns[columnName].Visible = false;
			}
		}

		private void makeReadOnly(DataGridView grid)
		{
			grid.AllowDrop = false;
			grid.AllowUserToAddRows = false;
			grid.AllowUserToDeleteRows = false;
			grid.AllowUserToOrderColumns = false;
			grid.AllowUserToResizeColumns = false;
			grid.AllowUserToResizeRows = false;
			grid.ReadOnly = true;
		}

		private void alignColumnHeadersToCenter()
		{
			foreach (DataGridViewColumn column in grid.Columns)
			{
				column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			}
		}

		private void formatColumn(string columnName, string headerText, Type type, int width = -1)
		{
			if (!grid.Columns.Contains(columnName))
			{
				return;
			}

			grid.Columns[columnName].HeaderText = headerText;

			if (width != -1)
			{
				if (type == Type.Money)
				{
					MoneyColumn(grid.Columns[columnName], width);
				}
				else if (type == Type.Number)
				{
					NumberColumn(grid.Columns[columnName], width);
				}
				else if (type == Type.Date)
				{
					DateColumn(grid.Columns[columnName], width);
				}
				else if (type == Type.Name)
				{
					NameColumn(grid.Columns[columnName], width);
				}
				else if (type == Type.Text)
				{
					TextColumn(grid.Columns[columnName], width);
				}
			}
			else
			{
				if (type == Type.Money)
				{
					MoneyColumn(grid.Columns[columnName]);
				}
				else if (type == Type.Number)
				{
					NumberColumn(grid.Columns[columnName]);
				}
				else if (type == Type.Date)
				{
					DateColumn(grid.Columns[columnName]);
				}
				else if (type == Type.Name)
				{
					NameColumn(grid.Columns[columnName]);
				}
				else if (type == Type.Text)
				{
					TextColumn(grid.Columns[columnName]);
				}
			}
		}
		
		private void totalGrid_SelectionChanged(object sender, EventArgs e)
		{
			(sender as DataGridView).ClearSelection();
		}

	}
}
