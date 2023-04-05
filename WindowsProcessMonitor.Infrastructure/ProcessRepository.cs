
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WindowsProcessMonitor.Domain.Interfaces;
using WindowsProcessMonitor.Domain.Models;

namespace WindowsProcessMonitor.Infrastructure
{
    public class ProcessRepository : IProcessRepository
    {
        public IEnumerable<ProcessModel> GetProcesses(string processName)
        {
            return Process.GetProcessesByName(processName).Select(p => new ProcessModel
            {
                ProcessID = p.Id,
                ProcessName = p.ProcessName,
                StartTime = p.StartTime,
                Duration = (DateTime.Now - p.StartTime).TotalMinutes
            });
        }

        public void KillProcess(int processId)
        {
            Process.GetProcessById(processId).Kill();
        }
    }
}
