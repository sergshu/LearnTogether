using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace SimpleParsing
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            Dictionary<string, List<List<string>>> result = Parsing("https://www.yr.no/place/Sweden/Stockholm/Stockholm/");
            if(result != null && result.Count > 0)
            {
                foreach(var r in result)
                {
                    Console.WriteLine(r.Key);

                    foreach(var row in r.Value)
                    {
                        Console.WriteLine(string.Join("\t", row));
                    }
                }
            }

            System.Diagnostics.Debugger.Break();
        }

        private static Dictionary<string, List<List<string>>> Parsing(string url)
        {
            try
            {
                using (HttpClientHandler hdl = new HttpClientHandler { AllowAutoRedirect = false, AutomaticDecompression = System.Net.DecompressionMethods.Deflate | System.Net.DecompressionMethods.GZip })
                {
                    using (var client = new HttpClient(hdl))
                    {
                        using (HttpResponseMessage resp = client.GetAsync(url).Result)
                        {
                            if(resp.IsSuccessStatusCode)
                            {
                                var html = resp.Content.ReadAsStringAsync().Result;
                                var doc = new HtmlAgilityPack.HtmlDocument();
                                doc.LoadHtml(html);

                                var tables = doc.DocumentNode.SelectNodes(".//div[@clas='yr-content-stickynav-three-fifths left lp_cleft']//table");

                                if (tables != null && tables.Count > 0)
                                {
                                    Dictionary<string, List<List<string>>> result = new Dictionary<string, List<List<string>>>();

                                    foreach (var table in tables)
                                    {
                                        var caption = table.SelectSingleNode(".//caption");
                                        if(caption != null)
                                        {
                                            var rows = table.SelectNodes(".//tr");
                                            if (rows != null)
                                            {
                                                var resRows = new List<List<string>>();
                                                foreach (var row in rows)
                                                {
                                                    var cells = row.SelectNodes(".//td");
                                                    if (cells != null)
                                                    {
                                                        resRows.Add(new List<string>(cells.Select(c => c.InnerText)));
                                                    }
                                                }

                                                result[caption.InnerText] = resRows;
                                            }
                                        }
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
