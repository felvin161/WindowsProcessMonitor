
using Quartz;
using Serilog;
using System;
using WindowsProcessMonitor.Domain.Interfaces;

namespace WindowsProcessMonitor.UI.Job
{
    public class WindowsProcessMonitorJobs : IJob
    {
        private readonly IWindowsProcess _windowsProcess;

        public WindowsProcessMonitorJobs(IWindowsProcess windowsProcess)
        {
            _windowsProcess = windowsProcess;
        }

        public void Execute(IJobExecutionContext context)
        {
            Log.Information("Checking for processes to kill..");
            Console.WriteLine("Checking for processes to kill..\n");

            JobDataMap dataMap = context.MergedJobDataMap;

            string processName = dataMap.GetString("name");
            int lifeTime = dataMap.GetInt("lifeTime");

            _windowsProcess.KillLongRunningProcess(processName, lifeTime);

        }
    }
}
