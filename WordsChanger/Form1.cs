using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordsChanger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var helper = new WordHelper("blank-zayavleniya-o-priyome-na-rabotu.doc");

            var items = new Dictionary<string, string>
            {
                { "<ORG>", textBox1.Text },
                { "<FIO>" , textBox2.Text },
                { "<PROF>" , textBox3.Text },
                { "<DATE_FROM>", dateTimePicker1.Value.ToString("dd.MM.yyyy") },
                { "<MONTHS>", numericUpDown1.Value.ToString() },
                { "<SALARY> ", textBox4.Text },
                { "<DATE>" , dateTimePicker2.Value.ToString("dd.MM.yyyy") },
            };

            helper.Process(items);
        }
    }
}
