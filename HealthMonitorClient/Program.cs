using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFSoapService;
using SharedDll;
using SharedDll.Models;
namespace HealthMonitorClient
{
    /// <summary>
    /// Test client for WCF SOAP service.
    /// </summary>
    internal class Program
    {
        #region Properties
        WCFSoapService.ServiceHost serviceManager = null;
        WCFSoapService.IWcfSoapService client = null;
        #endregion
        static void Main(string[] args)
        {
            Program p = new Program();
        }
        #region Constructors
        public Program()
        {
            SoapConnectionManager manager = new SoapConnectionManager();

            serviceManager = new WCFSoapService.ServiceHost();
            serviceManager.onDebugStart();  // Start the WCF service in debug mode
            client = manager.client;

            Console.WriteLine("Service is running..");
            SoapServiceModel model = new SoapServiceModel();
            model= client.GetResponse();
            string result = Ping();
            if (result == "Response granted")
            {
                Console.WriteLine("Service is reachable");
            }
            else
            {
                Console.WriteLine("Service is not reachable");
                Console.WriteLine(result);
            }

        }
        #endregion  
        /// <summary>
        /// Ping method to test reachability of the service.
        /// </summary>
        /// <returns></returns>
        string Ping()
        {
            string result = string.Empty;
            try
            {
                result = client.GetResponse().name;
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }


    }
}