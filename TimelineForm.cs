using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LoanBook
{
	public partial class TimelineForm : Form
	{
		public delegate void TimelineSelectedEventHandler(DateTime startDate, DateTime endDate);
		public event TimelineSelectedEventHandler TimelineSelected;

		public TimelineForm()
		{
			InitializeComponent();
			endDate.MaxDate = DateTime.Now;
		}

		public DateTime StartDate
		{
			get 
			{
				if (specifyStartDateRadio.Checked)
				{
					return this.startDate.Value;
				}
				return DateTime.MinValue;
			}
		}

		public DateTime EndDate
		{
			get
			{
				if (specifyEndDateRadio.Checked)
				{
					return this.endDate.Value;
				}
				return DateTime.Today;
			}
		}

		private void specifyStartDateRadio_CheckedChanged(object sender, EventArgs e)
		{
			if ((sender as RadioButton).Checked)
			{
				startDate.Enabled = true;
			}
			else
			{
				startDate.Enabled = false;
			}
		}

		private void specifyEndDateRadio_CheckedChanged(object sender, EventArgs e)
		{
			if ((sender as RadioButton).Checked)
			{
				endDate.Enabled = true;
			}
			else
			{
				endDate.Enabled = false;
			}
		}

		private void goButton_Click(object sender, EventArgs e)
		{
			if (TimelineSelected != null)
			{
				TimelineSelected(StartDate, EndDate);
			}
		}
	}
}
