using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleSheets
{
    public partial class Form1 : Form
    {
        private GoogleHelper helper;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.helper = new GoogleHelper(Properties.Settings.Default.GoogleToken,
                Properties.Settings.Default.SheetFileName);

            bool success = this.helper.Start().Result;
            btnGet.Enabled = btnSet.Enabled = success;
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            this.helper.Set(cellName: txtCellNameSet.Text, value: txtCellValue.Text);
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            var result = this.helper.Get(cellName: txtCellNameGet.Text);
            txtCellGetValue.Text = result;
        }
    }
}
