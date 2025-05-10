🛠️ Service Monitoring Example
A practical demonstration of a Windows Communication Foundation (WCF) SOAP service hosted via a Windows Service and consumed by a console application. This project serves as a foundational template for service monitoring and communication in .NET environments.


🛠️ Features
🧩 WCF Service using BasicHttpBinding

🖥️ Hosted via a self-contained Windows Service

🧪 Local debugging support without installing the service

📦 Console-based client with manual configuration (no app.config)

🔐 Ready for extension with authentication and metadata exchange


📂 Project Structure
Service-monitoring-example/
├── HealthMonitorClient/       # Console application client
├── ServiceHealthMonitor/      # Windows Service hosting the WCF service
├── SharedDll/                 # Shared interfaces and contracts
└── README.md                  # Project documentation


🚀 Getting Started
Prerequisites
.NET Framework 4.7.2

Visual Studio 2019 or later

Windows OS (for Windows Service hosting)

Running the Application
Clone the Repository:git clone https://github.com/Drapys/Service-monitoring-example.git
Build the Solution:

Open the solution in Visual Studio and build all projects to restore dependencies and compile the code.

Run the Service in Debug Mode:

The HealthMonitorClient project is configured to start the WCF service in debug mode. Set HealthMonitorClient as the startup project and run it. You should see output indicating that the service is running and a response from the service.

Service should be running..
Response granted


🧩 Components Overview
ServiceHealthMonitor
Purpose: Hosts the WCF SOAP service.

Key Files:

ServiceHost.cs: Manages the lifecycle of the Windows Service and hosts the WCF service.

WcfSoapService.cs: Implements the service contract.

App.config: Configures service endpoints and bindings.

SharedDll
Purpose: Contains shared interfaces and contracts between the service and client.

Key Files:

IWcfSoapService.cs: Defines the service contract with the GetResponse method.

HealthMonitorClient
Purpose: Acts as a client to consume the WCF service.

Key Files:

Program.cs: Initializes the service in debug mode and calls the GetResponse method.


⚙️ Configuration Details
Service Endpoint: http://localhost:8000/WcfSoapService

Binding: basicHttpBinding without security for simplicity.

Metadata Exchange (MEX): Enabled for service metadata retrieval.
