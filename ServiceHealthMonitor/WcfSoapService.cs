using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedDll.Models;

namespace WCFSoapService
{
    /// <summary>
    /// Implementation of the IWcfSoapService interface.
    /// Provides basic SOAP responses to clients.
    /// </summary>
    public class WcfSoapService : IWcfSoapService
    {
        /// <summary>
        /// Returns a hardcoded response string.
        /// </summary>
        public SoapServiceModel GetResponse()
        {
            SoapServiceModel model = new SoapServiceModel();
            model.id = 1;
            model.name = "Response granted";
            return model;
        }
    }
}
