
using System;

namespace WindowsProcessMonitor.Domain.Models
{
    public class ProcessModel
    {
        public int ProcessID { get; set; }
        public string ProcessName { get; set; }
        public DateTime StartTime { get; set; }
        public double Duration { get; set; }
    }
}
