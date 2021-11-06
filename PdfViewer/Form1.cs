using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PdfViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.StartDirectory = Environment.CurrentDirectory;
        }

        public string StartDirectory { get; }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory =
                Path.Combine(
                    StartDirectory,
                    "Docs");
            openFileDialog1.FileName = Path.Combine(
                    StartDirectory,
                    "Docs",
                    "WHO-INFLUENZA-MortalityEstimate_ru.pdf");

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                switch (tabControl1.SelectedIndex)
                {
                    case 0:
                        Process.Start(openFileDialog1.FileName);
                        break;
                    case 1:
                        webBrowser1.Navigate(openFileDialog1.FileName);
                        break;
                    case 2:
                        string path = Path.Combine(
                    StartDirectory,
                    "Docs",
                    "WHO-INFLUENZA-MortalityEstimate_ru-180.pdf");

                        var doc = PdfiumViewer.PdfDocument.Load(openFileDialog1.FileName);
                        doc.RotatePage(0, PdfiumViewer.PdfRotation.Rotate180);
                        doc.Save(path);

                        doc = PdfiumViewer.PdfDocument.Load(path);
                        pdfViewer1.Document = doc;
                        break;
                }
            }
        }
    }
}
