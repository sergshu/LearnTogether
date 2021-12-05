using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson19Streams
{
    public partial class Form1 : Form
    {
        private byte[] _result;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnZip_Click(object sender, EventArgs e)
        {
             _result = Zipper.Zip(txt: txtInput.Text);
        }

        private void btnUnzip_Click(object sender, EventArgs e)
        {
            txtOutput.Text = Zipper.Unzip(bytes: _result);
        }
    }
}
