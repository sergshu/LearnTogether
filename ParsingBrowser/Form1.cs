using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParsingBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                var html = webBrowser1.DocumentText;
                if (!string.IsNullOrEmpty(html))
                {
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);

                    var tables = doc.DocumentNode.SelectNodes(".//div[@class='block_content']//div[@class='two-table-row']//div[@class]");
                    if (tables != null && tables.Count > 0)
                    {
                        Dictionary<string, List<List<string>>> result = new Dictionary<string, List<List<string>>>();

                        foreach (var table in tables)
                        {
                            var titleNode = table.SelectSingleNode(".//div[@class='head_tb']");
                            if (titleNode != null)
                            {
                                var tbl = table.SelectSingleNode(".//div[@class='tab_champ']//table");
                                if (tbl != null)
                                {
                                    var rows = tbl.SelectNodes(".//tr");
                                    if (rows != null && rows.Count > 0)
                                    {
                                        var res = new List<List<string>>();

                                        foreach (var row in rows)
                                        {
                                            var cells = row.SelectNodes(".//td");
                                            if (cells != null && cells.Count > 0)
                                            {
                                                res.Add(new List<string>(cells.Select(c => c.InnerText)));
                                            }
                                        }

                                        result[titleNode.InnerText] = res;
                                    }
                                }
                            }
                        }

                        processResult(result);
                    }
                    else
                    {
                        Console.WriteLine("No tables");
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void processResult(Dictionary<string, List<List<string>>> result)
        {
            if (result != null)
            {
                foreach (var item in result)
                {
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine(item.Key);
                    Console.WriteLine("-----------------------------------------");
                    item.Value.ForEach(r => Console.WriteLine(string.Join("\t", r)));
                    Console.WriteLine("-----------------------------------------\n");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.readfootball.com/tables.html");
        }
    }
}
