using ClosedXML.Excel;
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

namespace BankiRuJsonParsing
{
    public partial class Form1 : Form
    {
        private IEnumerable<CandleData> _data;

        public Form1()
        {
            InitializeComponent();

            var dir = Path.Combine(Environment.CurrentDirectory, "Export");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
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

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Export", "data.csv");
            var rows = _data.Select(c => $"{c.begin},{c.open},{c.close}");
            File.WriteAllLines(path, rows);
        }

        private void btnExportXlsx_Click(object sender, EventArgs e)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Export", "data.xlsx");

            var wb = new XLWorkbook();
            var sh = wb.Worksheets.Add("Banki.ru");

            for (int i = 0; i < _data.Count(); i++)
            {
                sh.Cell(i + 1, 1).SetValue(_data.ElementAt(i).begin);
                sh.Cell(i + 1, 2).SetValue(_data.ElementAt(i).open);
                sh.Cell(i + 1, 3).SetValue(_data.ElementAt(i).close);
                sh.Cell(i + 1, 4).SetFormulaR1C1("RC[-1] - RC[-2]");
            }

            wb.SaveAs(path);
        }
    }
}
