using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Web.Http.SelfHost;
using System.Web.Http.SelfHost.Channels;

namespace SelfHostingSecurity
{
    public class MyConfig : HttpSelfHostConfiguration
    {
        // Add reference to System.ServiceModel
        protected override BindingParameterCollection OnConfigureBinding(HttpBinding httpBinding)
        {
            httpBinding.Security.Mode = HttpBindingSecurityMode.TransportCredentialOnly;
            httpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;
            return base.OnConfigureBinding(httpBinding);
        }

        public MyConfig(string ba): base(ba)
        {

        }
    }
}
