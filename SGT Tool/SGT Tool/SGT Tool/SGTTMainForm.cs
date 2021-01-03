using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGT_Tool
{
    public partial class SgtToolForm : Form
    {
        public SgtToolForm()
        {
            InitializeComponent();
        }

        private void SgtToolForm_OnLoad(object sender, EventArgs e)
        {
            this.Text = $"SGT Tool v{Application.ProductVersion}";
        }
    }
}
