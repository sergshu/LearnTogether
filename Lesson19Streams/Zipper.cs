using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson19Streams
{
    class Zipper
    {
        internal static byte[] Zip(string txt)
        {
            var bytes = Encoding.UTF8.GetBytes(txt);
            using (var inpStr = new MemoryStream(bytes))
            {
                using (var outStr = new MemoryStream())
                {
                    using (var zipStr = new GZipStream(outStr, CompressionMode.Compress))
                    {
                        var buffer = new byte[4096];
                        int cnt = 0;
                        while ((cnt = inpStr.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            zipStr.Write(buffer, 0, cnt);
                        }
                    }

                    return outStr.ToArray();
                }
            }
        }

        internal static string Unzip(byte[] bytes)
        {
            using (var inpStr = new MemoryStream(bytes))
            {
                using (var outStr = new MemoryStream())
                {
                    using (var zipStr = new GZipStream(inpStr, CompressionMode.Decompress))
                    {
                        var buffer = new byte[4096];
                        int cnt = 0;
                        while ((cnt = zipStr.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            outStr.Write(buffer, 0, cnt);
                        }

                        var result = outStr.ToArray();

                        return Encoding.UTF8.GetString(result);
                    }
                }
            }
        }
    }
}
