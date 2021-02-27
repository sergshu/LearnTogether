using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YandexDisk.Client.Clients;
using YandexDisk.Client.Http;
using YandexDisk.Client.Protocol;

namespace YandexDiskApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
                {
                    try
                    {
                        //http://localhost:12345/callback#access_token=****************&token_type=bearer&expires_in=31536000
                        var api = new DiskHttpApi("****************");

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
                });

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
