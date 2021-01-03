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
using static SGT_Tool.SingleAsxAuctionSimulator;

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
            IEPValue_label.Text = "0";
            IEQValue_Label.Text = "0";
            PotDollar_Label.Text = "0";
            
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
            bidDataGridView.AutoResizeColumns();

            BindingSource asksBS = new BindingSource();
            asksBS.DataSource = typeof(DisplayOrder);
     
            foreach (MdOrder ask in mMdRepository.GetOrderbook(symbol).Asks())
            {
                asksBS.Add(new DisplayOrder(ask));
            }
            askDataGridView.DataSource = asksBS;
            askDataGridView.AutoGenerateColumns = true;
            askDataGridView.AutoResizeColumns();
        }
        public class DisplayOrder
        {
            public double Px { get; }
            public int Qty { get; }
            public int PrioritySeq { get; }

            public int MatchingQty { get; set; }
            public double Pnl { get; set; }

            public Boolean IsOwnOrder { get; }

            public DisplayOrder(MdOrder order)
            {
                this.Px = order.Px;
                this.Qty = order.Qty;
                this.PrioritySeq = order.PrioritySeq;
                this.IsOwnOrder = false;
            }

            public DisplayOrder(double px, int qty)
            {
                this.Px = px;
                this.Qty = qty;
                this.PrioritySeq = int.MaxValue;
                this.IsOwnOrder = true;
            }
        }

        private void CalcButton_OnClick(object sender, EventArgs e)
        {
            List<DisplayOrder> bids = bidDataGridView.Rows.Cast<DataGridViewRow>().Select(r1 => r1.DataBoundItem as DisplayOrder).ToList();
            List<DisplayOrder> asks = askDataGridView.Rows.Cast<DataGridViewRow>().Select(r2 => r2.DataBoundItem as DisplayOrder).ToList();

            AuctionMatchResult r = AsxAuctionMatchCalculator.Calc(bids, asks);

            IEPValue_label.Text = r.IEP.ToString();
            IEQValue_Label.Text = r.IEV.ToString();

            BindingSource bs = (BindingSource)bidDataGridView.DataSource;

            int cumMatchQty = 0;
            foreach (DisplayOrder o in bs)
            {
                o.MatchingQty = Math.Max(0, Math.Min(r.IEV - cumMatchQty, o.Qty));
                cumMatchQty += o.MatchingQty;
            }

            bs = (BindingSource)askDataGridView.DataSource;

            cumMatchQty = 0;
            foreach (DisplayOrder o in bs)
            {
                o.MatchingQty = Math.Max(0, Math.Min(r.IEV - cumMatchQty, o.Qty));
                cumMatchQty += o.MatchingQty;
            }


            if (string.IsNullOrEmpty(FvTextBox.Text))
            {
                Redraw();
                return;
            }
            try
            {
                double fv = double.Parse(FvTextBox.Text);
                double bidPot = 0;
                double askPot = 0;

                foreach(DisplayOrder o in bids)
                {
                    if(o.Px >= fv)
                    {
                        double refPx = o.Px;
                        if(r.IEP != 0)
                        {
                            refPx = r.IEP;
                        }
                        bidPot += o.Qty * (refPx - fv);
                    }
                }

                foreach (DisplayOrder o in asks)
                {
                    if (o.Px <= fv)
                    {
                        double refPx = o.Px;
                        if (r.IEP != 0)
                        {
                            refPx = r.IEP;
                        }
                        askPot += o.Qty * (fv - refPx);
                    }
                }

                PotDollar_Label.Text = Math.Max(bidPot, askPot).ToString();

                bs = (BindingSource)bidDataGridView.DataSource;
                double ownPnl =0;
                foreach (DisplayOrder o in bs)
                {
                    o.Pnl = o.MatchingQty * (fv - r.IEP);
                    
                    if (o.IsOwnOrder)
                    {
                        ownPnl += o.Pnl;
                    }
                }

                bs = (BindingSource)askDataGridView.DataSource;
                foreach (DisplayOrder o in bs)
                {
                    o.Pnl = o.MatchingQty * (r.IEP - fv);

                    if (o.IsOwnOrder)
                    {
                        ownPnl += o.Pnl;
                    }
                }

                OwnPnlLabel.Text = ownPnl.ToString();

            }
            catch(Exception ex) { };

            Redraw();
        }

        public void Redraw()
        {
            bidDataGridView.Invalidate();
            askDataGridView.Invalidate();
        }

        private void addBuyButton_OnClick(object sender, EventArgs e)
        {
            int qty = int.Parse(AddQtyTextBox.Text);
            double px = double.Parse(AddPxTextbox.Text);

            BindingSource bs = (BindingSource) bidDataGridView.DataSource;

            int index = 0;

            foreach (DisplayOrder o in bs)
            {
                if (o.Px < px)
                {
                    break;
                }
                index++;
            }
            bs.Insert(index, new DisplayOrder(px, qty));
        }

        private void addSellButton_OnClick(object sender, EventArgs e)
        {
            int qty = int.Parse(AddQtyTextBox.Text);
            double px = double.Parse(AddPxTextbox.Text);

            BindingSource bs = (BindingSource)askDataGridView.DataSource;

            int index = 0;

            foreach (DisplayOrder o in bs)
            {
                if (o.Px > px)
                {
                    break;
                }
                index++;
            }
            bs.Insert(index, new DisplayOrder(px, qty));
        }

        private void dgv_OnCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.Value == null)
            {
                return;
            }
   
            DataGridView dgv = (DataGridView) sender;

            string colName = dgv.Columns[e.ColumnIndex].Name;
            if(colName== "MatchingQty")
            {
                int qty = (int) dgv.Rows[e.RowIndex].Cells["Qty"].Value;
                if((int)e.Value == 0)
                {
                    return;
                }
                if ((int) e.Value == qty)
                {
                    e.CellStyle.BackColor = Color.Salmon;
                }else if ((int) e.Value < qty)
                {
                    e.CellStyle.BackColor = Color.LightSalmon;
                }
            }
        }
    }
}
