using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace HttpLoginSaveCookies
{
    class Client
    {
        private HttpClientHandler hdl;
        private CookieContainer cookie;
        private string fkey;
        private const string cookieFileName = "cookies.dat";

        public Client()
        {
            cookie = new CookieContainer();
            hdl = new HttpClientHandler
            {
                AllowAutoRedirect = false,
                AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip | DecompressionMethods.None,
                CookieContainer = cookie,
#if DEBUG
                //Proxy = new WebProxy("127.0.0.1:8888"),
#endif
            };
        }

        public bool LoadCookies()
        {
            if (File.Exists(cookieFileName))
            {
                var formater = new BinaryFormatter();
                using (var strm = File.OpenRead(cookieFileName))
                {
                    cookie = (CookieContainer)formater.Deserialize(strm);
                    return true;
                }
            }

            return false;
        }

        public void SaveCookies()
        {
            var formater = new BinaryFormatter();
            using (var strm = File.Create(cookieFileName))
            {
                formater.Serialize(strm, cookie);
            }
        }

        public async Task<bool> GetLoginPage()
        {
            using (var clnt = new HttpClient(hdl, false))
            {
                clnt.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:91.0) Gecko/20100101 Firefox/91.0");
                clnt.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
                clnt.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.5");
                clnt.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
                clnt.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "document");
                clnt.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "navigate");
                clnt.DefaultRequestHeaders.Add("Sec-Fetch-Site", "none");
                clnt.DefaultRequestHeaders.Add("Sec-Fetch-User", "?1");

                using (var resp = await clnt.GetAsync("https://stackoverflow.com/users/login"))
                {
                    if (resp.IsSuccessStatusCode)
                    {
                        var html = await resp.Content.ReadAsStringAsync();
                        var doc = new HtmlAgilityPack.HtmlDocument();
                        doc.LoadHtml(html);
                        var fkeyNode = doc.DocumentNode.SelectSingleNode(".//input[@name='fkey']");
                        if (fkeyNode != null)
                        {
                            this.fkey = fkeyNode.Attributes["value"].Value;
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public async Task<bool> LoginValidationtrack(string login = "learningtogethersharp%40gmail.com", string password = "uKmznttZF5qk63A")
        {
            using (var clnt = new HttpClient(hdl, false))
            {
                clnt.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:91.0) Gecko/20100101 Firefox/91.0");
                clnt.DefaultRequestHeaders.Add("Accept", "*/*");
                clnt.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.5");
                clnt.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
                clnt.DefaultRequestHeaders.Add("Origin", "https://stackoverflow.com");
                clnt.DefaultRequestHeaders.Referrer = new Uri("https://stackoverflow.com/users/login");
                clnt.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "empty");
                clnt.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "cors");
                clnt.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");

                using (var content = new StringContent($"isSignup=false&isLogin=true&isPassword=false&isAddLogin=false&fkey={this.fkey}&ssrc=login&email={login}&password={password}&oauthversion=&oauthserver=", Encoding.UTF8, "application/x-www-form-urlencoded"))
                {
                    using (var resp = await clnt.PostAsync("https://stackoverflow.com/users/login-or-signup/validation/track", content))
                    {
                        if (resp.IsSuccessStatusCode)
                        {
                            var response = await resp.Content.ReadAsStringAsync();
                            return response == "Login-OK";
                        }
                    }
                }
            }
            return false;
        }

        public async Task<bool> Login(string login = "learningtogethersharp%40gmail.com", string password = "uKmznttZF5qk63A")
        {
            using (var clnt = new HttpClient(hdl, false))
            {
                clnt.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:91.0) Gecko/20100101 Firefox/91.0");
                clnt.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
                clnt.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.5");
                clnt.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
                clnt.DefaultRequestHeaders.Referrer = new Uri("https://stackoverflow.com/users/login");
                clnt.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
                clnt.DefaultRequestHeaders.Add("Origin", "https://stackoverflow.com");
                clnt.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "document");
                clnt.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "navigate");
                clnt.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");
                clnt.DefaultRequestHeaders.Add("Sec-Fetch-User", "?1");

                using (var content = new StringContent($"fkey={this.fkey}&ssrc=login&email={login}&password={password}&oauth_version=&oauth_server=", Encoding.UTF8, "application/x-www-form-urlencoded"))
                {
                    using (var resp = await clnt.PostAsync("https://stackoverflow.com/users/login", content))
                    {
                        if (resp.StatusCode == HttpStatusCode.Found)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
