using SGT_Tool.AsxAuctionSimulator.MDOrderBook;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ninject;
using SGT_Tool.AsxAuctionSimulator;

namespace SGT_Tool
{
    public partial class SingleAsxAuctionSimulator : Form
    {
        public MdRepository mMdRepository;

        public SingleAsxAuctionSimulator()
        {
            InitializeComponent();
        }

        private void SingleAsxAuctionSimulator_OnLoad(object sender, EventArgs e)
        {
            var applicationSettings = ConfigurationManager.GetSection("AuctionSimulatorSettings") as NameValueCollection;

            mdFileName.Text = applicationSettings["MdFile"];

            resetButton_OnClick(null,null);
        }

        private void resetButton_OnClick(object sender, EventArgs e)
        {
            IMdLoader mdLoader = new CsvMdLoader(mdFileName.Text);
            mMdRepository = new MdRepository(mdLoader);

            symbols_ComboBox.DataSource = mMdRepository.GetSymbols();

            symbolsComboBox_OnSelectionChanged(null, null);
        }

        private void symbolsComboBox_OnSelectionChanged(object sender, EventArgs e)
        {
            string symbol = (string) symbols_ComboBox.SelectedValue;
            if(string.IsNullOrEmpty(symbol))
            {
                return;
            }

            BindingSource bidsBS = new BindingSource();
            bidsBS.DataSource = typeof(DisplayOrder);

            foreach (MdOrder bid in mMdRepository.GetOrderbook(symbol).Bids())
            {
                bidsBS.Add(new DisplayOrder(bid));
            }
            bidDataGridView.DataSource = bidsBS;
            bidDataGridView.AutoGenerateColumns = true;

            BindingSource asksBS = new BindingSource();
            asksBS.DataSource = typeof(DisplayOrder);
     
            foreach (MdOrder ask in mMdRepository.GetOrderbook(symbol).Asks())
            {
                asksBS.Add(new DisplayOrder(ask));
            }
            askDataGridView.DataSource = asksBS;
            askDataGridView.AutoGenerateColumns = true;
        }
        public class DisplayOrder
        {
            public double Px {get;}
            public int Qty { get; }
            public int PrioritySeq { get; }

            public DisplayOrder(MdOrder order)
            {
                this.Px = order.Px;
                this.Qty = order.Qty;
                this.PrioritySeq = order.PrioritySeq;
            }
        }

        private void CalcButton_OnClick(object sender, EventArgs e)
        {
            AuctionMatchResult r = AsxAuctionMatchCalculator.Calc(
                bidDataGridView.Rows.Cast<DataGridViewRow>().Select(r1 => r1.DataBoundItem as DisplayOrder).ToList(),
                askDataGridView.Rows.Cast<DataGridViewRow>().Select(r2 => r2.DataBoundItem as DisplayOrder).ToList());

            IEPValue_label.Text = r.IEP.ToString();
            IEQValue_Label.Text = r.IEV.ToString();
        }
    }
}
