
namespace WindowsProcessMonitor.Domain.Interfaces
{
    public interface IWindowsProcess
    {
        void KillLongRunningProcess(string processName, double maxLifeTime);
    }
}
