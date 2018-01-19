using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace WebApiAccess
{
    public class Access
    {
        protected Binding Binding
        {
            get
            {
                var binding = new BasicHttpBinding();
                binding.Name = "basicHttpsBinding";
                binding.MaxReceivedMessageSize = 2147483647;
                binding.MaxBufferSize = 2147483647;
                binding.MaxBufferPoolSize = 50000000;
                binding.ReaderQuotas.MaxNameTableCharCount = 2147483647;
                binding.ReaderQuotas.MaxDepth = 50000000;
                binding.ReaderQuotas.MaxArrayLength = 50000000;
                binding.ReaderQuotas.MaxBytesPerRead = 2147483647;
                binding.ReaderQuotas.MaxStringContentLength = 50000000;
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
                binding.Security.Mode = BasicHttpSecurityMode.None;
                return binding;
            }
        }

        protected EndpointAddress Endpoint
        {
            get { return new EndpointAddress(this.UrlWCF); }
        }

        protected string UrlWCF { get; set; }
    }
}
