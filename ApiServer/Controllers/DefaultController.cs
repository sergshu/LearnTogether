using System;
using System.Collections.Generic;
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
    }
}
