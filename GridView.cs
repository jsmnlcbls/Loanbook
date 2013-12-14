using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace LoanBook
{
	class GridView : DataGridView
	{
		public GridView()
			: base()
		{
			ReadOnly = true;
			MultiSelect = false;
		}

		public new object DataSource
		{
			get { return base.DataSource; }
			set { changeDataSource(value); }
		}

		private void changeDataSource(object dataSource)
		{
			if (Rows.Count > 0)
			{
				retainExistingScrollSelection(dataSource);
			}
			else
			{
				base.DataSource = dataSource;
			}
			
		}

		private void retainExistingScrollSelection(object dataSource)
		{
			System.Diagnostics.Debug.Print("Retaining Scroll Selection");
			int rowIndex = CurrentRow.Index;
			System.Diagnostics.Debug.Print("Row Index: " + rowIndex);
			int scrollIndex = FirstDisplayedScrollingRowIndex;
			int columnIndex = CurrentCell.ColumnIndex;

			base.DataSource = dataSource;

			if (rowIndex < Rows.Count)
			{
				CurrentCell = Rows[rowIndex].Cells[columnIndex];
				Rows[rowIndex].Selected = true;
				FirstDisplayedScrollingRowIndex = scrollIndex;
			}
		}
	}
}
