using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApiServerTestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStartUpload_Click(object sender, EventArgs e)
        {
            var url = txtUrlApi.Text;
            Uri uri = null;
            if (string.IsNullOrEmpty(url) || !Uri.TryCreate(url, UriKind.Absolute, out uri))
            {
                return;
            }

            using (var dlg = new OpenFileDialog { CheckFileExists = true, InitialDirectory = Environment.CurrentDirectory })
            {
                if (dlg.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(dlg.FileName))
                {
                    var fileName = dlg.FileName;
                    try
                    {
                        using (HttpClientHandler hdl = new HttpClientHandler())
                        {
                            using (HttpClient clnt = new HttpClient(hdl))
                            {
                                using (MultipartFormDataContent content = new MultipartFormDataContent())
                                {
                                    using (var fileContent = new ByteArrayContent(File.ReadAllBytes(fileName)))
                                    {
                                        fileContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                                        {
                                            FileName = Path.GetFileName(fileName),
                                            Name = "file"
                                        };

                                        content.Add(fileContent);

                                        var response = clnt.PostAsync(uri, content).Result;

                                        var text = response.Content.ReadAsStringAsync().Result;
                                        MessageBox.Show(text);
                                    }
                                }
                            }
                        }
                    }
                    catch(Exception ex) { MessageBox.Show(ex.Message); }
                }
            }
        }
    }
}
