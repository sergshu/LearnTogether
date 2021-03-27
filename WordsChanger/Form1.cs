using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        Regex _regTo = new Regex(@"КОМУ (?<ORG>.+)", RegexOptions.Compiled | RegexOptions.Singleline);
        Regex _regFrom = new Regex(@"ОТ КОГО (?<FIO>.+)", RegexOptions.Compiled | RegexOptions.Singleline);
        Regex _regBody = new Regex(@"в качестве (?<PROF>.+)\s+с\s+(?<DATE_FROM>[0-9]+\.[0-9]+\.[0-9]+)", RegexOptions.Compiled | RegexOptions.Singleline);
        Regex _regRow = new Regex(@"С испытательным сроком (?<MONTHS>[0-9]+) месяца и окладом (?<SALARY>.+)рублей", RegexOptions.Compiled | RegexOptions.Singleline);
        Regex _regDate = new Regex(@"(?<DATE>[0-9]+\.[0-9]+\.[0-9]+)", RegexOptions.Compiled | RegexOptions.Singleline);

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var helper = new WordHelper("20210220 125048 blank-zayavleniya-o-priyome-na-rabotu.doc");
                List<string> textBlocks = helper.ReadText();

                string to = null, from = null, prof = null, dateFrom = null, months = null, salary = null, date = null;

                foreach (var block in textBlocks.Where(b => !string.IsNullOrEmpty(b)))
                {
                    Match m = null;
                    if (string.IsNullOrEmpty(to))
                    {
                        m = _regTo.Match(block);
                        if (m != null && m.Success)
                        {
                            to = m.Groups["ORG"].Value;
                        }
                    }

                    if (string.IsNullOrEmpty(from))
                    {
                        m = _regFrom.Match(block);
                        if (m != null && m.Success)
                        {
                            from = m.Groups["FIO"].Value;
                        }
                    }

                    if (string.IsNullOrEmpty(prof))
                    {
                        m = _regBody.Match(block);
                        if (m != null && m.Success)
                        {
                            prof = m.Groups["PROF"].Value;
                            dateFrom = m.Groups["DATE_FROM"].Value;
                        }
                    }

                    if (string.IsNullOrEmpty(months))
                    {
                        m = _regRow.Match(block);
                        if (m != null && m.Success)
                        {
                            months = m.Groups["MONTHS"].Value;
                            salary = m.Groups["SALARY"].Value;
                        }
                    }
                }

                for (int i = textBlocks.Count - 1; i >= 0; i--)
                {
                    var m = _regDate.Match(textBlocks[i]);
                    if (m != null && m.Success)
                    {
                        date = m.Groups["DATE"].Value;
                    }
                }

                Console.WriteLine($"to = {to}, from = {from}, prof = {prof}, dateFrom = {dateFrom}, months = {months}, salary = {salary}, date = {date}");
            }
            catch { }
        }
    }
}
