using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGT_MRA
{
    public partial class s : Form
    {
        BindingList<String> mSeriesTypeBindingList = new BindingList<String>();

        public static string OUT_DATE_FORMAT = "dd/MM/yyyy";
        public s()
        {
            InitializeComponent();

            mSeriesTypeBindingList.Add("NAV_TR");
            mSeriesTypeBindingList.Add("PRICE_TR");
            mSeriesTypeBindingList.Add("PRICE");
        }

        private void SgtMraForm_OnLoad(object sender, EventArgs e)
        {
            fromDateTimePicker.Value = DateTime.Today.AddYears(-1);
            toDateTimePicker.Value = DateTime.Today;

            fromDateTimePicker.Format = DateTimePickerFormat.Custom;
            toDateTimePicker.Format = DateTimePickerFormat.Custom;
            fromDateTimePicker.CustomFormat = OUT_DATE_FORMAT;
            toDateTimePicker.CustomFormat = OUT_DATE_FORMAT;
           
            seriesTypeComboBox.DataSource = mSeriesTypeBindingList;
        }

        private void xParamsDgv_OnCellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText =  xParamsDgv.Columns[e.ColumnIndex].HeaderText;

            if (headerText.Equals("Series Type"))
            {
                string seriesType = e.FormattedValue.ToString();
                if (!string.IsNullOrEmpty(seriesType) && !mSeriesTypeBindingList.Contains(seriesType))
                {
                    MessageBox.Show("Invalid series type: " + seriesType);
                    e.Cancel = true;
                } 
            
                return;
            }
        }
    }
}
