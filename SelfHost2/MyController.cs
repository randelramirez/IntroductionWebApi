using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SelfHost2
{
    public class MyController : ApiController
    {
        public string Get()
        {
            return "Hello from Controller in Self-Hosting";
        }
    }
}
