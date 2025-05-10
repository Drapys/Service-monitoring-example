using SharedDll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFSoapService
{
    /// <summary>
    /// Interface defining the SOAP service contract.
    /// </summary>
    [ServiceContract]
    public interface IWcfSoapService
    {
        /// <summary>
        /// Returns a string response.
        /// </summary>
        /// <returns>Service response</returns>
        [OperationContract]
        SoapServiceModel GetResponse();
    }
}
