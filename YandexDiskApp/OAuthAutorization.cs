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

namespace YandexDiskApp
{
    public partial class OAuthAutorization : Form
    {
        Regex regToken = new Regex("access_token=(?<token>[^&]+)", RegexOptions.Compiled);
        public OAuthAutorization()
        {
            InitializeComponent();

            webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted;
        }

        public string Token { get; private set; }
        public bool Success { get; private set; }
        public object ClientId { get; set; }

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if(e.Url.AbsoluteUri.StartsWith("http://localhost:12345/callback"))
            {
                var m = regToken.Match(e.Url.AbsoluteUri);
                if(m.Success)
                {
                    Token = m.Groups["token"].Value;
                    Success = true;
                }

                this.Close();
            }
        }

        private void OAuthAutorization_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate($@"https://oauth.yandex.ru/authorize?response_type=token&client_id={ClientId}");
        }
    }
}
