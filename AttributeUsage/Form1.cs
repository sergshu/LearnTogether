using AttributeUsage.BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttributeUsage
{
    public partial class Form1 : Form
    {
        private Settings _data;

        public Form1()
        {
            InitializeComponent();
        }

        private void bindData()
        {
            this.bs.DataSource = this._data;

            this.textBox1.DataBindings.Add("Text", this.bs, "VAT");
            this.textBox2.DataBindings.Add("Text", this.bs, "Url");
            this.textBox3.DataBindings.Add("Text", this.bs, "Profit");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this._data == null)
            {
                this._data = new Settings();
                _data.Load();
                bindData();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Text = string.Join(
                "\r\n", 
                _data
                    .GetData()
                    .Select(x => x.name + "=" + x.value));
        }
    }
}
