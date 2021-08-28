using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YandexDisk.Client.Clients;
using YandexDisk.Client.Http;
using YandexDisk.Client.Protocol;

namespace YandexDiskApp
{
    class Program
    {
        [STAThread]
        static async Task Main(string[] args)
        {
            var appId = "*************";
            string token = null;
#if BROWSER
            var form = new OAuthAutorization();
            form.ClientId = "****";

            Application.Run(form);

            if(form.Success && !string.IsNullOrEmpty(form.Token))
            {
                write($"Token {form.Token}");
                //Console.ReadKey();
                //return;
            }
            else
            {
                throw new Exception("Not found");
            }
#else
            var helper = new OAuthAutorizationHelper(appId);

            await helper.GetToken();

            if (helper.Success && !string.IsNullOrEmpty(helper.Token))
            {
                write($"Token {helper.Token}");
                //Console.ReadKey();
                //return;
            }
            else
            {
                throw new Exception("Not found");
            }

#endif
            try
            {
                //http://localhost:12345/callback#access_token=****************&token_type=bearer&expires_in=31536000
                var api = new DiskHttpApi(token);

                var rootFolderData = await api.MetaInfo.GetInfoAsync(new ResourceRequest
                {
                    Path = "/"
                });

                foreach (var item in rootFolderData.Embedded.Items)
                {
                    write($"{item.Name}\t{item.Type}\t{item.MimeType}");
                }

                const string folderName = "TestFolder";

                if (!rootFolderData.Embedded.Items.Any(i => i.Type == ResourceType.Dir && i.Name.Equals(folderName)))
                {
                    await api.Commands.CreateDictionaryAsync("/" + folderName);
                }

                var files = Directory.GetFiles(Environment.CurrentDirectory, "*.jpg");

                foreach (var file in files)
                {
                    try
                    {
                        var link = await api.Files.GetUploadLinkAsync("/" + folderName + "/" + Path.GetFileName(file), overwrite: false);
                        using (var fs = File.OpenRead(file))
                        {
                            await api.Files.UploadAsync(link, fs);
                        }
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                }

                var testFolderData = await api.MetaInfo.GetInfoAsync(new ResourceRequest
                {
                    Path = "/" + folderName
                });


                foreach (var item in testFolderData.Embedded.Items)
                {
                    write($"{item.Name}\t{item.Type}\t{item.MimeType}");
                }

                var destDir = Path.Combine(Environment.CurrentDirectory, "Download");
                if (!Directory.Exists(destDir))
                {
                    Directory.CreateDirectory(destDir);
                }

                foreach (var item in testFolderData.Embedded.Items)
                {
                    await api.Files.DownloadFileAsync(path: item.Path, Path.Combine(destDir, item.Name));
                    var lnk = await api.Files.GetDownloadLinkAsync(item.Path);

                    write(item.Name + "\t" + lnk.Href);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            Console.WriteLine("Нажмите кнопку");
            Console.ReadKey();
        }

        private static void writeNewLine()
        {
            Console.WriteLine();
        }

        private static void write(string v)
        {
            Console.WriteLine(v);
        }
    }
}
