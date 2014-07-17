using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XMethodOverride
{
    public class MyMethodOverrideHandler : DelegatingHandler
    {
        const string header = "X-HTTP-Method-Override";
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if(request.Method == HttpMethod.Post && request.Headers.Contains(header))
            {
                var realVerb = request.Headers.GetValues(header).FirstOrDefault();
                if(realVerb != null)
                {
                    request.Method = new HttpMethod(realVerb);
                }
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}
