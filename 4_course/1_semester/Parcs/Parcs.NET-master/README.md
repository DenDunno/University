# Parcs.NET
Parallel distributed system for .NET

<b>Docker support</b>

Host Server: https://hub.docker.com/r/andriikhavro/parcshostserver/

Daemon: https://hub.docker.com/r/andriikhavro/parcsdaemon/

Web: https://hub.docker.com/r/andriikhavro/parcsweb/

Module example: https://hub.docker.com/r/andriikhavro/parcsmatrixmodule/

<b>Prerequisites</b>

You must have .NET Framework 4.5 or higher installed on your machine to use Parcs.NET. 


<b>Installation</b>

To run Parcs.NET locally, you need to do the following steps:

1. Clone the repository 
2. Open Powershell
3. Go to Installation folder (using cd command)
4. Run .\Setup.ps1 -IpAdresses $your_local_IP_address$ -LocalIp $your_local_IP_address$

The script should install NuGet packages, build the solution using MSBuild, put your IP address in HostServer/bin/Release/hosts.txt file and run both HostServer and Daemon locally. For NuGet install you need nuget command line installed. (https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference).

Alternatively, you can do those steps manually using Visual Studio.

<b>How to create your own module</b>
1. Create Visual Studio Console Application project.
2. Install Parcs and Parcs.Module.CommandLine (optional) NuGet packages.
3. Create a class derived from MainModule and write Run method with orchestration logic which will be run locally.
4. Create a number of classes (usually one) which implement IModule interface. Run method will be run on Daemon. To run this method, call point.ExecuteClass() method with full name of the class.
5. Create a class implementing IModuleOptions interface or use BaseModuleOptions from Parcs.Module.CommandLine NuGet package. (optional)
6. Inside Main method call ModuleInfo.RunModule() method on the class derived from MainModule. Pass an instance of IModuleOptions to the method or null if you don't want to run your module with Web interface.
7. Add server.txt file next to .exe file with your HostServer IP address or set it to IModuleOptions.ServerIp.
8. Make sure HostServer and Daemon are running. (see Installation steps)
9. Run your module.

<b>Examples</b>

The example of a module can be found in NewMatrixModule folder.
To run the module:
1. Perform Installation steps (see Installation section)
2. Add server.txt file with HostServer IP Address (your local) 
3. Create two matrixes with MatrixGenerator
4. Copy NewMatrixModule/launch.bat and created matrixes to bin folder with NewMatrixModule.exe.
5. Open launch.bat with notepad or any text editor.
6. Replace matrix file names in launch.bat and number of points (threads) you want to run the module on.
7. Run launch.bat

<b>Azure</b>

To create Azure Virtual Machine for HostServer and Web Application, run Installation/Azure.ps1 script. The script is taken from https://docs.microsoft.com/en-us/azure/virtual-machines/windows/quick-create-powershell.
Script creates Azure Resource Group called <i>ParcsResourceGroup</i> with all necessary stuff for Virtual Machine. The most important part of it is Network Security Group (called <i>ParcsSecurityGroup</i>) which allows communication using the ports used by Parcs. The script will prompt to login to Azure and then enter credential which will be used for RDP connection to new Virtual Machine. If the script is executed successfully, you should have HostServer VM up and running.

After you have created HostServer VM, you can create VM for Daemon using Azure portal (the script is not written yet). Make sure you use the same ParcsResourceGroup, ParcsSecurityGroup and Public Addresses.

Also create Azure SQL database via Azure Portal for web authentication. Username and password will be used in connection string. After creating it, you will be able to copy connection string from Azure Portal.

Then connect to Daemon VM using RDP and do the following:
1. Run Installation\RemoteDaemon.ps1 which will open firewall
2. Copy Daemon\bin\Release folder to VM. 
3. Run DaemonPr.exe from Release folder

You can create as many Daemons as you want.

Then connect to HostServer VM using RDP and do the following:
1. Run Installation\RemoteHostServer.ps1 which will open firewall and enable IIS
2. Copy HostServer\bin\Release folder to VM.
3. Add/Update Release\hosts.txt with Daemon local IP addresses (which are displayed in console when you run DaemonPr.exe each of Daemom VM)
4. Update HostServerContext connection string with created SQL Database in HostServer Web.config.
5. Copy RestApi folder to VM
6. Update HostServerContext connection string with created SQL Database in RestApi Web.config.
7. Open IIS (Windows Administrative Tools -> Internet Information Services (IIS) Manager
8. Point Sites -> Default Web Site -> Advanced Settings -> Physical Path to RestApi folder
9. Recycle Default App Pool
10. Run HostServer.exe from Release folder

After all those steps you should be able to open the site by HostServer Public IP address.

To run the module via web interface, create C:\ParcsModules folder and place there your module.
