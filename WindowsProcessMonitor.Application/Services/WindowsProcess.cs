
using Serilog;
using System;
using System.Linq;
using WindowsProcessMonitor.Domain.Interfaces;

namespace WindowsProcessMonitor.Application.Services
{
    public class WindowsProcess : IWindowsProcess
    {
        private readonly IProcessRepository _processRepository;

        public WindowsProcess(IProcessRepository processRepository)
        {
            _processRepository = processRepository;
        }

        public void KillLongRunningProcess(string processName, double maxLifeTime)
        {
            try 
            {
                var processes = _processRepository.GetProcesses(processName).Where(x=>x.Duration>= maxLifeTime);

                Console.WriteLine($"No of Processes found to kill {processes.Count()}\n");

                foreach(var p in processes)
                {
                    _processRepository.KillProcess(p.ProcessID);
                   
                    Console.WriteLine($"Killing Process, ProcessName : {p.ProcessName}, Duration : {p.Duration}");
                    Log.Information($"Killing Process, ProcessName : {p.ProcessName}, Duration : {p.Duration}");

                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Error from KillLongRunningProcess");
                Log.Error($"Error from KillLongRunningProcess. {ex}");
            }
        }
    }
}
