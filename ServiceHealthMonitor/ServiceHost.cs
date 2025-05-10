using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WCFSoapService
{
    /// <summary>
    /// Windows service host for the WCF SOAP service.
    /// Supports debug mode and optional automatic shutdown.
    /// </summary>
    public partial class ServiceHost : ServiceBase
    {
        private System.ServiceModel.ServiceHost _debugHost = null;
        private System.ServiceModel.ServiceHost _serviceHost = null;

        public ServiceHost()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Called when the service starts. Contains both debug and production start logic.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        protected override void OnStart(string[] args)
        {
            #region Debug Mode
            onDebugStart();
            #endregion

            #region Production Mode (Commented Out)
            // Uncomment this block to use production hosting
            //_serviceHost?.Close();
            //_serviceHost = new System.ServiceModel.ServiceHost(typeof(WcfSoapService));
            //_serviceHost.Open();

            //// Auto-stop after 60 seconds
            //Task.Run(async () =>
            //{
            //    await Task.Delay(TimeSpan.FromSeconds(60));
            //    this.Stop(); 
            //});
            #endregion
        }

        /// <summary>
        /// Called when the service is stopped.
        /// </summary>
        protected override void OnStop()
        {
            if (_serviceHost != null)
            {
                _serviceHost.Close();
                _serviceHost = null;
            }
        }

        /// <summary>
        /// Starts the WCF service for debugging purposes with a basic HTTP binding.
        /// </summary>
        public void onDebugStart()
        {
            _debugHost = new System.ServiceModel.ServiceHost(typeof(WcfSoapService));
            _debugHost.AddServiceEndpoint(
               typeof(IWcfSoapService),
               new BasicHttpBinding(),
               "http://localhost:8000/WcfSoapService");
            _debugHost.Open();

            // Auto-close after 60 seconds
            Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(60));
                onDebugStop();
            });
        }

        /// <summary>
        /// Stops the debug WCF service.
        /// </summary>
        public void onDebugStop()
        {
            _debugHost?.Close();
            _debugHost = null;
        }
    }
}