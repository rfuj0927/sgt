
namespace SGT_Tool
{
    partial class SingleAsxAuctionSimulator
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.symbols_ComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.mdFileName = new System.Windows.Forms.TextBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.bidDataGridView = new System.Windows.Forms.DataGridView();
            this.askDataGridView = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.FvTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.addBuyButton = new System.Windows.Forms.Button();
            this.addSellButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.AddPxTextbox = new System.Windows.Forms.TextBox();
            this.AddQtyTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.IEPValue_label = new System.Windows.Forms.Label();
            this.IEQValue_Label = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.OwnPnlLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.calcButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.PotDollarDB_Label = new System.Windows.Forms.Label();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.PotDollarMM_Label = new System.Windows.Forms.Label();
            this.PotDollarContinuous_Label = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bidDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.askDataGridView)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.39063F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.60938F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 178F));
            this.tableLayoutPanel1.Controls.Add(this.symbols_ComboBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel7, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 326F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(834, 468);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // symbols_ComboBox
            // 
            this.symbols_ComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.symbols_ComboBox.FormattingEnabled = true;
            this.symbols_ComboBox.Location = new System.Drawing.Point(497, 3);
            this.symbols_ComboBox.Name = "symbols_ComboBox";
            this.symbols_ComboBox.Size = new System.Drawing.Size(155, 21);
            this.symbols_ComboBox.TabIndex = 3;
            this.symbols_ComboBox.SelectedIndexChanged += new System.EventHandler(this.symbolsComboBox_OnSelectionChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.01064F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.98936F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.mdFileName, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.resetButton, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(488, 46);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "MD Path:";
            // 
            // mdFileName
            // 
            this.mdFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mdFileName.Location = new System.Drawing.Point(81, 3);
            this.mdFileName.Name = "mdFileName";
            this.mdFileName.Size = new System.Drawing.Size(290, 20);
            this.mdFileName.TabIndex = 1;
            // 
            // resetButton
            // 
            this.resetButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resetButton.Location = new System.Drawing.Point(377, 3);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(108, 40);
            this.resetButton.TabIndex = 2;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_OnClick);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel3, 3);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.bidDataGridView, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.askDataGridView, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 145);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(828, 320);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // bidDataGridView
            // 
            this.bidDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bidDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bidDataGridView.Location = new System.Drawing.Point(3, 3);
            this.bidDataGridView.Name = "bidDataGridView";
            this.bidDataGridView.Size = new System.Drawing.Size(408, 314);
            this.bidDataGridView.TabIndex = 0;
            this.bidDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_OnCellFormatting);
            // 
            // askDataGridView
            // 
            this.askDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.askDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.askDataGridView.Location = new System.Drawing.Point(417, 3);
            this.askDataGridView.Name = "askDataGridView";
            this.askDataGridView.Size = new System.Drawing.Size(408, 314);
            this.askDataGridView.TabIndex = 1;
            this.askDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_OnCellFormatting);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.72832F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.27168F));
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.FvTextBox, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(658, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(173, 46);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 46);
            this.label2.TabIndex = 0;
            this.label2.Text = "FV:";
            // 
            // FvTextBox
            // 
            this.FvTextBox.Location = new System.Drawing.Point(69, 3);
            this.FvTextBox.Name = "FvTextBox";
            this.FvTextBox.Size = new System.Drawing.Size(100, 20);
            this.FvTextBox.TabIndex = 1;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.addBuyButton, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.addSellButton, 1, 2);
            this.tableLayoutPanel6.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.AddPxTextbox, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.AddQtyTextBox, 1, 1);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(658, 55);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 3;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(173, 84);
            this.tableLayoutPanel6.TabIndex = 7;
            // 
            // addBuyButton
            // 
            this.addBuyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addBuyButton.Location = new System.Drawing.Point(3, 43);
            this.addBuyButton.Name = "addBuyButton";
            this.addBuyButton.Size = new System.Drawing.Size(80, 38);
            this.addBuyButton.TabIndex = 0;
            this.addBuyButton.Text = "Add Buy";
            this.addBuyButton.UseVisualStyleBackColor = true;
            this.addBuyButton.Click += new System.EventHandler(this.addBuyButton_OnClick);
            // 
            // addSellButton
            // 
            this.addSellButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addSellButton.Location = new System.Drawing.Point(89, 43);
            this.addSellButton.Name = "addSellButton";
            this.addSellButton.Size = new System.Drawing.Size(81, 38);
            this.addSellButton.TabIndex = 1;
            this.addSellButton.Text = "Add Sell";
            this.addSellButton.UseVisualStyleBackColor = true;
            this.addSellButton.Click += new System.EventHandler(this.addSellButton_OnClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Px:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Qty:";
            // 
            // AddPxTextbox
            // 
            this.AddPxTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddPxTextbox.Location = new System.Drawing.Point(89, 3);
            this.AddPxTextbox.Name = "AddPxTextbox";
            this.AddPxTextbox.Size = new System.Drawing.Size(81, 20);
            this.AddPxTextbox.TabIndex = 4;
            // 
            // AddQtyTextBox
            // 
            this.AddQtyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddQtyTextBox.Location = new System.Drawing.Point(89, 23);
            this.AddQtyTextBox.Name = "AddQtyTextBox";
            this.AddQtyTextBox.Size = new System.Drawing.Size(81, 20);
            this.AddQtyTextBox.TabIndex = 5;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.ColumnCount = 4;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.18056F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.81944F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel5.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.IEPValue_label, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.IEQValue_Label, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.label8, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.OwnPnlLabel, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel8, 0, 2);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 55);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(488, 84);
            this.tableLayoutPanel5.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "IEP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "IEQ";
            // 
            // IEPValue_label
            // 
            this.IEPValue_label.AutoSize = true;
            this.IEPValue_label.Location = new System.Drawing.Point(59, 0);
            this.IEPValue_label.Name = "IEPValue_label";
            this.IEPValue_label.Size = new System.Drawing.Size(13, 13);
            this.IEPValue_label.TabIndex = 3;
            this.IEPValue_label.Text = "0";
            // 
            // IEQValue_Label
            // 
            this.IEQValue_Label.AutoSize = true;
            this.IEQValue_Label.Location = new System.Drawing.Point(59, 24);
            this.IEQValue_Label.Name = "IEQValue_Label";
            this.IEQValue_Label.Size = new System.Drawing.Size(13, 13);
            this.IEQValue_Label.TabIndex = 4;
            this.IEQValue_Label.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(269, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Own PNL";
            // 
            // OwnPnlLabel
            // 
            this.OwnPnlLabel.AutoSize = true;
            this.OwnPnlLabel.Location = new System.Drawing.Point(380, 0);
            this.OwnPnlLabel.Name = "OwnPnlLabel";
            this.OwnPnlLabel.Size = new System.Drawing.Size(13, 13);
            this.OwnPnlLabel.TabIndex = 7;
            this.OwnPnlLabel.Text = "0";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.calcButton, 0, 0);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(497, 55);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(155, 84);
            this.tableLayoutPanel7.TabIndex = 8;
            // 
            // calcButton
            // 
            this.calcButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calcButton.Location = new System.Drawing.Point(3, 3);
            this.calcButton.Name = "calcButton";
            this.calcButton.Size = new System.Drawing.Size(149, 36);
            this.calcButton.TabIndex = 9;
            this.calcButton.Text = "Calc";
            this.calcButton.UseVisualStyleBackColor = true;
            this.calcButton.Click += new System.EventHandler(this.CalcButton_OnClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Pot$ (DB)";
            // 
            // PotDollarDB_Label
            // 
            this.PotDollarDB_Label.AutoSize = true;
            this.PotDollarDB_Label.Location = new System.Drawing.Point(3, 15);
            this.PotDollarDB_Label.Name = "PotDollarDB_Label";
            this.PotDollarDB_Label.Size = new System.Drawing.Size(13, 13);
            this.PotDollarDB_Label.TabIndex = 6;
            this.PotDollarDB_Label.Text = "0";
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 4;
            this.tableLayoutPanel5.SetColumnSpan(this.tableLayoutPanel8, 4);
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.Controls.Add(this.PotDollarDB_Label, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.label9, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.label10, 2, 0);
            this.tableLayoutPanel8.Controls.Add(this.PotDollarMM_Label, 1, 1);
            this.tableLayoutPanel8.Controls.Add(this.PotDollarContinuous_Label, 2, 1);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 51);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(482, 30);
            this.tableLayoutPanel8.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(83, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Pot$ (Min/Max)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(203, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Pot$ (Continuous)";
            // 
            // PotDollarMM_Label
            // 
            this.PotDollarMM_Label.AutoSize = true;
            this.PotDollarMM_Label.Location = new System.Drawing.Point(83, 15);
            this.PotDollarMM_Label.Name = "PotDollarMM_Label";
            this.PotDollarMM_Label.Size = new System.Drawing.Size(13, 13);
            this.PotDollarMM_Label.TabIndex = 9;
            this.PotDollarMM_Label.Text = "0";
            // 
            // PotDollarContinuous_Label
            // 
            this.PotDollarContinuous_Label.AutoSize = true;
            this.PotDollarContinuous_Label.Location = new System.Drawing.Point(203, 15);
            this.PotDollarContinuous_Label.Name = "PotDollarContinuous_Label";
            this.PotDollarContinuous_Label.Size = new System.Drawing.Size(13, 13);
            this.PotDollarContinuous_Label.TabIndex = 10;
            this.PotDollarContinuous_Label.Text = "0";
            // 
            // SingleAsxAuctionSimulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 468);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SingleAsxAuctionSimulator";
            this.Text = "SingleAsxAuctionSimulator";
            this.Load += new System.EventHandler(this.SingleAsxAuctionSimulator_OnLoad);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bidDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.askDataGridView)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox mdFileName;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ComboBox symbols_ComboBox;
        private System.Windows.Forms.DataGridView bidDataGridView;
        private System.Windows.Forms.DataGridView askDataGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FvTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label IEPValue_label;
        private System.Windows.Forms.Label IEQValue_Label;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button addBuyButton;
        private System.Windows.Forms.Button addSellButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox AddPxTextbox;
        private System.Windows.Forms.TextBox AddQtyTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label OwnPnlLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Button calcButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Label PotDollarDB_Label;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label PotDollarMM_Label;
        private System.Windows.Forms.Label PotDollarContinuous_Label;
    }
}