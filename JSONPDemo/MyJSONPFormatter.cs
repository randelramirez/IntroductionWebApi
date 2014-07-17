using JSONPDemo.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace JSONPDemo
{
    public class MyJSONPFormatter : MediaTypeFormatter
    {
        public MyJSONPFormatter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/javascript"));
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return type == typeof(JSONPreturn);
        }

        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            //return base.WriteToStreamAsync(type, value, writeStream, content, transportContext);
            return Task.Factory.StartNew(() =>
            {
                var jsonp = (JSONPreturn)value;
                var sw = new StreamWriter(writeStream, UTF8Encoding.Default);
                sw.Write("{0}({1});",jsonp.Callback, jsonp.JSON);
                sw.Flush();
            });
        }
    }
}
