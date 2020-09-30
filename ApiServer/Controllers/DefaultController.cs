using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApiServer.Controllers
{
    public class DefaultController : ApiController
    {
        [AcceptVerbs("GET")]
        [Route("Ping/{id}")]
        public async Task<IHttpActionResult> Ping(int id)
        {
            return Ok(new { date = DateTime.Now, data = id });
        }

        /// <summary>
        /// Передаваемые данные:
        //POST https://localhost:44318/PostData HTTP/1.1
        //Content-Type: application/javascript
        //Cache-Control: no-cache
        //Host: localhost:44318
        //Content-Length: 19

        //["first", "second"]
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [AcceptVerbs("POST")]
        [Route("PostData")]
        public async Task<IHttpActionResult> PostData([FromBody] string[] data)
        {
            return Ok(new { date = DateTime.Now, data });
        }

        [AcceptVerbs("POST")]
        [Route("UploadFile")]
        public async Task<IHttpActionResult> UploadFile()
        {
            try
            {
                MultipartMemoryStreamProvider provider = new MultipartMemoryStreamProvider();
                await Request.Content.ReadAsMultipartAsync(provider);

                if(provider.Contents != null && provider.Contents.Count > 0)
                {
                    foreach(var cont in provider.Contents)
                    {
                        if(!string.IsNullOrEmpty( cont.Headers.ContentDisposition.FileName))
                        {
                           var fileName = cont.Headers.ContentDisposition.FileName;

                            var saveDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files");
                            if(!Directory.Exists(saveDir))
                            {
                                Directory.CreateDirectory(saveDir);
                            }

                            var filePath = Path.Combine(saveDir, fileName);
                            if(File.Exists(filePath))
                            {
                                File.Delete(filePath);
                            }

                            var bites = await cont.ReadAsByteArrayAsync();
                            if(bites != null && bites.Length > 0)
                            {
                                using (var streamMemory = new MemoryStream(bites))
                                {
                                    streamMemory.Seek(0, SeekOrigin.Begin);
                                    using(var fileStream = File.Create(filePath))
                                    {
                                        streamMemory.CopyTo(fileStream);
                                    }
                                }
                            }
                            else
                            {
                                return Ok(new { message = "File Empty" });
                            }
                        }
                        else
                        {
                            return Ok(new { message = "No file name" });
                        }
                    }

                    return Ok(new { message = "Success" });
                }
                else
                {
                    return Ok(new { message = "Not found" });
                }
            }
            catch (Exception ex) { return InternalServerError(ex); }
        }
    }
}
