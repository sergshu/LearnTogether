using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using IronBarCode;

namespace QrCodeRW
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            var qr = BarcodeWriter.CreateBarcode(txtSource.Text, BarcodeEncoding.QRCode);
            pictureBox1.BackgroundImage = (Image)qr.Image.Clone();

            var filePath = Path.Combine(
                Environment.CurrentDirectory,
                Guid.NewGuid().ToString() + ".jpeg");

            qr.SaveAsJpeg(filePath);
            System.Diagnostics.Process.Start(filePath);
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            var qr = BarcodeReader.ReadASingleBarcode(
                pictureBox1.BackgroundImage,
                BarcodeEncoding.QRCode);

            txtResult.Text = qr.Text;
        }
    }
}
