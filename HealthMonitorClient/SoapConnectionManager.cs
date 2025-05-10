using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HealthMonitorClient
{
    public class SoapConnectionManager
    {
        #region Properties
        WCFSoapService.ServiceHost manager = null;
        ChannelFactory<WCFSoapService.IWcfSoapService> Factory = null;
        public WCFSoapService.IWcfSoapService client = null;
        #endregion

        #region Constructors
        public SoapConnectionManager()
        {
            client = InitializeConfiguration();
          
        }
        #endregion

        #region Methods
        /// <summary>
        /// Configures the channel factory for the WCF client.
        /// </summary>
        public static ChannelFactory<WCFSoapService.IWcfSoapService> CreateAndConfigureFactory(BasicHttpBinding binding, EndpointAddress address)
        {
            var factory = new ChannelFactory<WCFSoapService.IWcfSoapService>(binding, address);
            return factory;
        }

        /// <summary>
        /// Configures basic HTTP binding.
        /// </summary>
        public BasicHttpBinding CreateAndConfigureBinding()
        {

            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Security.Mode = BasicHttpSecurityMode.None; // No transport security
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;
            binding.MaxReceivedMessageSize = 65536;

            return binding;
        }

        /// <summary>
        /// Initializes client configuration.
        /// </summary>
        public WCFSoapService.IWcfSoapService InitializeConfiguration()
        {

            BasicHttpBinding binding = CreateAndConfigureBinding();
            EndpointAddress endpointAddress = new EndpointAddress(new Uri("http://localhost:8000/WcfSoapService"));

            Factory = CreateAndConfigureFactory(binding, endpointAddress);
            WCFSoapService.IWcfSoapService client = Factory.CreateChannel();

            return client;
        }
        #endregion
    }
}
