using CommandLine;
using Parcs.Module.CommandLine;

Lab lab = new();
BaseModuleOptions options = new()
{
    ServerIp = "127.0.0.1" 
};

Parser.Default.ParseArguments(args, options.GetType());
lab.RunModule(options);