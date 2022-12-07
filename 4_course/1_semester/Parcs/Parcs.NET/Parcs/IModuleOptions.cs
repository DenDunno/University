namespace Parcs
{
    public interface IModuleOptions
    {
        int Priority { get; }
        string Username { get; }
        string ServerIp { get; }
    }
}
