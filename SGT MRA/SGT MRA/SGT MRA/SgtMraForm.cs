using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * TODO 
 * - handle other data sources if available
 * - autoset API key
 * - validate security type is correct for query type
 * - bug that close prices for YAPc1 does not have 1 decimal place from Reuters.
 * - should use TotalReturn for PriceTr but Fundamentals database is not supported by .NET API (only realtime or historical at this stage).
 * - WMCO for FX
 * - Missing data for CLc1
 */
namespace SGT_MRA
{
    public enum SeriesType { NavTr, PriceTr, Price }
    public enum ReturnType { Simple, Log }

    public partial class SgtMraMainForm : Form
    {
        private static string EIKON_DATA_API_KEY = "74700e057f8846369b99cdec93338ab78a0a3314";

        private BindingList<String> mSeriesTypeBindingList = new BindingList<String>();
        private BindingList<String> mPriceReturnTypeBindingList = new BindingList<String>();

        public static string OUT_DATE_FORMAT = "dd/MM/yyyy";
        public SgtMraMainForm()
        {
            InitializeComponent();

            foreach(SeriesType s in Enum.GetValues(typeof(SeriesType)))
            {
                mSeriesTypeBindingList.Add(s.ToString());
            }

            foreach (ReturnType s in Enum.GetValues(typeof(ReturnType)))
            {
                mPriceReturnTypeBindingList.Add(s.ToString());
            }
        }

        private void SgtMraForm_OnLoad(object sender, EventArgs e)
        {
            fromDateTimePicker.Value = DateTime.Today.AddYears(-1);
            toDateTimePicker.Value = DateTime.Today;

            fromDateTimePicker.Format = DateTimePickerFormat.Custom;
            toDateTimePicker.Format = DateTimePickerFormat.Custom;
            fromDateTimePicker.CustomFormat = OUT_DATE_FORMAT;
            toDateTimePicker.CustomFormat = OUT_DATE_FORMAT;
           
            ySeriesTypeComboBox.DataSource = mSeriesTypeBindingList;
            returnTypeComboBox.DataSource = mPriceReturnTypeBindingList;
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

        public void ProgressChanged(string text)
        {
            statusLabel.Text = text;

            resultsDgv.Invalidate();
        }

        private void regressButton_OnClick(object sender, EventArgs e)
        {
            MraParams p = new MraParams();
            p.fromDt = fromDateTimePicker.Value;
            p.toDt = toDateTimePicker.Value;
            p.yVariable = new VariablePair(ySymbolTextBox.Text, (SeriesType)Enum.Parse(typeof(SeriesType), ySeriesTypeComboBox.Text));
            p.returnType = (ReturnType)Enum.Parse(typeof(ReturnType), returnTypeComboBox.Text);

            foreach (DataGridViewRow row in xParamsDgv.Rows)
            {
                if (string.IsNullOrEmpty((string)row.Cells[0].Value))
                {
                    continue;
                }

                p.xVariables.Add(new VariablePair((string)row.Cells[0].Value, (SeriesType)Enum.Parse(typeof(SeriesType), (string)row.Cells[1].Value)));
            }

            AnalysisEngine analysisEngine = new AnalysisEngine(p, new EikonDataApiDataQuerier(EIKON_DATA_API_KEY));
            resultsDgv.DataSource = analysisEngine.GetResults();
            analysisEngine.ProgressChanged += ProgressChanged;
            analysisEngine.Run();
        }

        private void resutlsDgv_OnCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string columnName = resultsDgv.Columns[e.ColumnIndex].Name;

            if(columnName.Equals(GetMemberName((RegressionResult c) => c.RSquared))
                || columnName.Equals(GetMemberName((RegressionResult c) => c.StandardError))
                || columnName.Equals(GetMemberName((RegressionResult c) => c.Mean)))
            {
                e.CellStyle.Format = "N6";
            }
        }

        public static string GetMemberName<T, TValue>(Expression<Func<T, TValue>> memberAccess)
        {
            return ((MemberExpression)memberAccess.Body).Member.Name;
        }
    }
}
