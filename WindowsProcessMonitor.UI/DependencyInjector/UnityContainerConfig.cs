

using Unity;
using WindowsProcessMonitor.Application.Services;
using WindowsProcessMonitor.Domain.Interfaces;
using WindowsProcessMonitor.Domain.Validation;
using WindowsProcessMonitor.Infrastructure;
using WindowsProcessMonitor.UI.Job;

namespace WindowsProcessMonitor.UI.DependencyInjector
{
    internal static class UnityContainerConfig
    {
        internal static IUnityContainer Container { get; set; }

        static UnityContainerConfig()
        {
            Container = new UnityContainer();
            Container.RegisterType<IApplication_Start, Application_Start>();
            Container.RegisterType<IProcessRepository, ProcessRepository>();
            Container.RegisterType<IWindowsProcess, WindowsProcess>();
            Container.RegisterType<IValidator, UserInputValidator>();
            Container.RegisterType<WindowsProcessMonitorJobs>();
        }
    }
}
