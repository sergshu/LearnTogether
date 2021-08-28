using System;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YandexDiskApp
{
    internal class OAuthAutorizationHelper
    {
        private string appId;
        private int counter = 0;

        private ManualResetEvent manualReset = new ManualResetEvent(false);

        public OAuthAutorizationHelper(string appId)
        {
            this.appId = appId;
        }

        public bool Success { get; internal set; }
        public string Token { get; internal set; }

        internal async Task GetToken()
        {
            Process.Start($"https://oauth.yandex.ru/authorize?response_type=token&client_id={this.appId}");

            Task.Run(RunServer);

            manualReset.WaitOne(600000);
        }

        private void RunServer()
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:12345/");

            listener.Start();

            while (listener.IsListening)
            {
                var context = listener.GetContext();
                processContext(context);
            }
        }

        private void processContext(HttpListenerContext context)
        {
            if (context.Request.Url.AbsoluteUri.EndsWith("favicon.ico"))
            {
                return;
            }

            if (counter > 0)
            {
                byte[] b = Encoding.UTF8.GetBytes($@"
<html>
<body>
{context.Request.QueryString["access_token"]}
</body>
</html>");
                Token = context.Request.QueryString["access_token"];
                Success = !string.IsNullOrEmpty(Token);

                context.Response.StatusCode = 200;
                context.Response.KeepAlive = false;
                context.Response.ContentLength64 = b.Length;

                var output = context.Response.OutputStream;
                output.Write(b, 0, b.Length);
                context.Response.Close();

                Console.WriteLine(context.Request.Url.AbsoluteUri);

                if (Success)
                {
                    manualReset.Set();
                }

                counter++;
            }
            else if (counter == 0)
            {
                byte[] b = Encoding.UTF8.GetBytes($@"
<html>
<body>
Processing...
<script>
var newUrl = window.location.href.replace('#','?');
window.location.href=newUrl;
</script>
</body>
</html>");
                context.Response.StatusCode = 200;
                context.Response.KeepAlive = false;
                context.Response.ContentLength64 = b.Length;

                var output = context.Response.OutputStream;
                output.Write(b, 0, b.Length);
                context.Response.Close();

                Console.WriteLine(context.Request.Url.AbsoluteUri);

                counter++;
            }
        }
    }
}