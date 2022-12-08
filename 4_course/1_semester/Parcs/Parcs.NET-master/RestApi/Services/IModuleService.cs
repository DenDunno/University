namespace RestApi.Services
{
    public interface IModuleService
    {
        string[] GetAvailableModules();
        string GetModuleFilePath(string moduleName);
    }
}
