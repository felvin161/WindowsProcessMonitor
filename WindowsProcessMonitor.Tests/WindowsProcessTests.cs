
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using WindowsProcessMonitor.Application.Services;
using WindowsProcessMonitor.Domain.Interfaces;
using WindowsProcessMonitor.Infrastructure;

namespace WindowsProcessMonitor.Tests
{
    [TestFixture]
    public class WindowsProcessTests
    {

        private IServiceScope _serviceScope;
        private IWindowsProcess _windowsProcess;

        [SetUp]
        public void SetUp()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IWindowsProcess, WindowsProcess>()
                .AddTransient<IProcessRepository, ProcessRepository>()
                .BuildServiceProvider();

            _serviceScope = serviceProvider.CreateScope();

            _windowsProcess = _serviceScope.ServiceProvider.GetRequiredService<IWindowsProcess>();
        }

        [Test]
        public void KillLongRunningProcess()
        {
            _windowsProcess.KillLongRunningProcess("notepad", 1);
        }
    }
}
