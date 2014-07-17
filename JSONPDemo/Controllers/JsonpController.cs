using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace JSONPDemo.Controllers
{
    public class JsonpController : ApiController
    {
        // GET api/values
        public HttpResponseMessage Get(int id, string callback)
        {
            var content = new JSONPreturn
            {
                Callback = callback,
                JSON = "{'id': '" + id + "', 'data': 'Hello from JSONP Web API Style'}"
            };

            var msg = Request.CreateResponse(HttpStatusCode.OK, content, "application/javascript");
            return msg;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}