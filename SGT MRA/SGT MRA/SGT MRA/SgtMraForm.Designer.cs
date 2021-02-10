
namespace SGT_MRA
{
    partial class SgtMraMainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SgtMraMainForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.toDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.xParamsDgv = new System.Windows.Forms.DataGridView();
            this.Ric = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeriesType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.ySeriesTypeComboBox = new System.Windows.Forms.ComboBox();
            this.ySymbolTextBox = new System.Windows.Forms.TextBox();
            this.regressButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.resultsDgv = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.returnTypeComboBox = new System.Windows.Forms.ComboBox();
            this.customTickerHistoryOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.loadCustomTickerHistoryButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xParamsDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultsDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.11504F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.88496F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.resultsDgv, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.59515F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1279, 435);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.fromDateTimePicker, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.toDateTimePicker, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.xParamsDgv, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.ySeriesTypeComboBox, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.ySymbolTextBox, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.regressButton, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.statusLabel, 1, 9);
            this.tableLayoutPanel2.Controls.Add(this.label7, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.returnTypeComboBox, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.loadCustomTickerHistoryButton, 1, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 10;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(366, 429);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "To:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Y:";
            // 
            // fromDateTimePicker
            // 
            this.fromDateTimePicker.CustomFormat = "";
            this.fromDateTimePicker.Location = new System.Drawing.Point(57, 3);
            this.fromDateTimePicker.Name = "fromDateTimePicker";
            this.fromDateTimePicker.Size = new System.Drawing.Size(122, 20);
            this.fromDateTimePicker.TabIndex = 5;
            this.fromDateTimePicker.Value = new System.DateTime(2021, 1, 7, 12, 17, 14, 0);
            // 
            // toDateTimePicker
            // 
            this.toDateTimePicker.CustomFormat = "";
            this.toDateTimePicker.Location = new System.Drawing.Point(239, 3);
            this.toDateTimePicker.Name = "toDateTimePicker";
            this.toDateTimePicker.Size = new System.Drawing.Size(124, 20);
            this.toDateTimePicker.TabIndex = 6;
            this.toDateTimePicker.Value = new System.DateTime(2021, 1, 7, 12, 17, 14, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "X:";
            // 
            // xParamsDgv
            // 
            this.xParamsDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.xParamsDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ric,
            this.SeriesType});
            this.tableLayoutPanel2.SetColumnSpan(this.xParamsDgv, 3);
            this.xParamsDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xParamsDgv.Location = new System.Drawing.Point(57, 171);
            this.xParamsDgv.Name = "xParamsDgv";
            this.xParamsDgv.RowHeadersVisible = false;
            this.tableLayoutPanel2.SetRowSpan(this.xParamsDgv, 5);
            this.xParamsDgv.Size = new System.Drawing.Size(306, 204);
            this.xParamsDgv.TabIndex = 2;
            this.xParamsDgv.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.xParamsDgv_OnCellValidating);
            // 
            // Ric
            // 
            this.Ric.HeaderText = "Ric";
            this.Ric.Name = "Ric";
            // 
            // SeriesType
            // 
            this.SeriesType.HeaderText = "Series Type";
            this.SeriesType.Name = "SeriesType";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(185, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 26);
            this.label4.TabIndex = 4;
            this.label4.Text = "SeriesType:";
            // 
            // ySeriesTypeComboBox
            // 
            this.ySeriesTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ySeriesTypeComboBox.FormattingEnabled = true;
            this.ySeriesTypeComboBox.Location = new System.Drawing.Point(239, 45);
            this.ySeriesTypeComboBox.Name = "ySeriesTypeComboBox";
            this.ySeriesTypeComboBox.Size = new System.Drawing.Size(95, 21);
            this.ySeriesTypeComboBox.TabIndex = 9;
            // 
            // ySymbolTextBox
            // 
            this.ySymbolTextBox.Location = new System.Drawing.Point(57, 45);
            this.ySymbolTextBox.Name = "ySymbolTextBox";
            this.ySymbolTextBox.Size = new System.Drawing.Size(122, 20);
            this.ySymbolTextBox.TabIndex = 1;
            // 
            // regressButton
            // 
            this.regressButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.regressButton.Location = new System.Drawing.Point(57, 87);
            this.regressButton.Name = "regressButton";
            this.regressButton.Size = new System.Drawing.Size(122, 36);
            this.regressButton.TabIndex = 12;
            this.regressButton.Text = "Regress";
            this.regressButton.UseVisualStyleBackColor = true;
            this.regressButton.Click += new System.EventHandler(this.regressButton_OnClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 378);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Status:";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.statusLabel, 3);
            this.statusLabel.Location = new System.Drawing.Point(57, 378);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(50, 13);
            this.statusLabel.TabIndex = 14;
            this.statusLabel.Text = "Initialized";
            // 
            // resultsDgv
            // 
            this.resultsDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.resultsDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.resultsDgv.DefaultCellStyle = dataGridViewCellStyle1;
            this.resultsDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsDgv.Location = new System.Drawing.Point(375, 3);
            this.resultsDgv.Name = "resultsDgv";
            this.resultsDgv.RowHeadersVisible = false;
            this.resultsDgv.Size = new System.Drawing.Size(901, 429);
            this.resultsDgv.TabIndex = 1;
            this.resultsDgv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.resutlsDgv_OnCellFormatting);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(185, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 26);
            this.label7.TabIndex = 15;
            this.label7.Text = "Return Type:";
            // 
            // returnTypeComboBox
            // 
            this.returnTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.returnTypeComboBox.FormattingEnabled = true;
            this.returnTypeComboBox.Location = new System.Drawing.Point(239, 87);
            this.returnTypeComboBox.Name = "returnTypeComboBox";
            this.returnTypeComboBox.Size = new System.Drawing.Size(95, 21);
            this.returnTypeComboBox.TabIndex = 16;
            // 
            // customTickerHistoryOpenFileDialog
            // 
            this.customTickerHistoryOpenFileDialog.FileName = "ExampleData.csv";
            this.customTickerHistoryOpenFileDialog.RestoreDirectory = true;
            this.customTickerHistoryOpenFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.customTickerHistoryOpenFileDialog_OnFileOk);
            // 
            // loadCustomTickerHistoryButton
            // 
            this.loadCustomTickerHistoryButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadCustomTickerHistoryButton.Location = new System.Drawing.Point(57, 129);
            this.loadCustomTickerHistoryButton.Name = "loadCustomTickerHistoryButton";
            this.loadCustomTickerHistoryButton.Size = new System.Drawing.Size(122, 36);
            this.loadCustomTickerHistoryButton.TabIndex = 17;
            this.loadCustomTickerHistoryButton.Text = "Load Custom Ticker History";
            this.toolTip1.SetToolTip(this.loadCustomTickerHistoryButton, "Required CSV of format:\r\nTicker,Date,Price,Div\r\nBrownian,10/02/2021,100,0");
            this.loadCustomTickerHistoryButton.UseVisualStyleBackColor = true;
            this.loadCustomTickerHistoryButton.Click += new System.EventHandler(this.loadCustomTickerHistoryButton_OnClick);
            // 
            // SgtMraMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 435);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SgtMraMainForm";
            this.Text = "SGT MRA";
            this.Load += new System.EventHandler(this.SgtMraForm_OnLoad);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xParamsDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultsDgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker fromDateTimePicker;
        private System.Windows.Forms.DateTimePicker toDateTimePicker;
        private System.Windows.Forms.DataGridView resultsDgv;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView xParamsDgv;
        private System.Windows.Forms.ComboBox ySeriesTypeComboBox;
        private System.Windows.Forms.TextBox ySymbolTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ric;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeriesType;
        private System.Windows.Forms.Button regressButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox returnTypeComboBox;
        private System.Windows.Forms.Button loadCustomTickerHistoryButton;
        private System.Windows.Forms.OpenFileDialog customTickerHistoryOpenFileDialog;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

