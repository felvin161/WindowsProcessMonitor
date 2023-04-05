
using System.Collections.Generic;
using WindowsProcessMonitor.Domain.Models;

namespace WindowsProcessMonitor.Domain.Interfaces
{
    public interface IProcessRepository
    {
        IEnumerable<ProcessModel> GetProcesses(string processName);
        void KillProcess(int processId);
    }
}
