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

        [AcceptVerbs("POST")]
        [Route("PostData")]
        public async Task<IHttpActionResult> PostData([FromBody] string[] data)
        {
            return Ok(new { date = DateTime.Now, data });
        }
    }
}
