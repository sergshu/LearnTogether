using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankiRuJsonParsing
{
    public partial class Form1 : Form
    {
        private IEnumerable<CandleData> _data;

        public Form1()
        {
            InitializeComponent();
        }

        public Form1(IEnumerable<CandleData> enumerable) : this()
        {
            _data = enumerable;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = _data;
            dataGridView1.DataSource = bindingSource1;
        }
    }
}
