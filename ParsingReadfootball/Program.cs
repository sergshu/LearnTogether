using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ParsingReadfootball
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<List<string>>> result = Parsing(url: "https://www.readfootball.com/tables.html");
            if(result != null)
            {
                foreach(var item in result)
                {
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine(item.Key);
                    Console.WriteLine("-----------------------------------------");
                    item.Value.ForEach(r => Console.WriteLine(string.Join("\t", r)));
                    Console.WriteLine("-----------------------------------------\n");
                }
            }

            Console.ReadKey();
        }

        private static Dictionary<string, List<List<string>>> Parsing(string url)
        {
            try
            {
                Dictionary<string, List<List<string>>> result = new Dictionary<string, List<List<string>>>();

                using (HttpClientHandler hdl = new HttpClientHandler { AllowAutoRedirect = false, AutomaticDecompression = System.Net.DecompressionMethods.Deflate | System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.None })
                {
                    using (var clnt = new HttpClient(hdl))
                    {
                        using (HttpResponseMessage resp = clnt.GetAsync(url).Result)
                        {
                            if (resp.IsSuccessStatusCode)
                            {
                                var html = resp.Content.ReadAsStringAsync().Result;
                                if (!string.IsNullOrEmpty(html))
                                {
                                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                                    doc.LoadHtml(html);

                                    var tables = doc.DocumentNode.SelectNodes(".//div[@class='block_content']//div[@class='two-table-row']//div[@class]");
                                    if (tables != null && tables.Count > 0)
                                    {
                                        foreach (var table in tables)
                                        {
                                            var titleNode = table.SelectSingleNode(".//div[@class='head_tb']");
                                            if (titleNode != null)
                                            {
                                                var tbl = table.SelectSingleNode(".//div[@class='tab_champ']//table");
                                                if(tbl != null)
                                                {
                                                    var rows = tbl.SelectNodes(".//tr");
                                                    if(rows != null && rows.Count > 0)
                                                    {
                                                        var res = new List<List<string>>();

                                                        foreach(var row in rows)
                                                        {
                                                            var cells = row.SelectNodes(".//td");
                                                            if(cells != null && cells.Count > 0)
                                                            {
                                                                res.Add(new List<string>(cells.Select(c => c.InnerText)));
                                                            }
                                                        }

                                                        result[titleNode.InnerText] = res;
                                                    }
                                                }
                                            }
                                        }

                                        return result;
                                    }
                                    else
                                    {
                                        Console.WriteLine("No tables");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return null;
        }
    }
}
