using System;
using System.ServiceModel;

namespace AppDiarista.Common.ExtensionMethods
{
    public static class EndPointWCFExtensions
    {
        public static HttpBindingBase RetornarBindingPelaURI(this EndpointAddress endPoint, int minutosTimeout = 6, long tamanhoMaximoMsg = 2147483647)
        {
            if (endPoint == null)
            {
                return null;
            }

            HttpBindingBase binding = new BasicHttpBinding() { SendTimeout = TimeSpan.FromMinutes(minutosTimeout), MaxReceivedMessageSize = tamanhoMaximoMsg };
            if (endPoint.Uri.Scheme == Uri.UriSchemeHttps)
            {
                binding = new BasicHttpsBinding() { SendTimeout = TimeSpan.FromMinutes(minutosTimeout), MaxReceivedMessageSize = tamanhoMaximoMsg };
            }

            return binding;
        }
    }
}
