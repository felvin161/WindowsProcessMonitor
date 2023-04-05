
using Quartz;
using Quartz.Spi;
using Unity;

namespace WindowsProcessMonitor.UI.DependencyInjector
{
    public class DependencyInjectionJobFactory : IJobFactory
    {
        private readonly IUnityContainer _unityContainer;
        public DependencyInjectionJobFactory(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            var jobDetail = bundle.JobDetail;
            var jobType = jobDetail.JobType;

            return (IJob)_unityContainer.Resolve(jobType);
        }

        public void ReturnJob(IJob job){ }
    }
}
