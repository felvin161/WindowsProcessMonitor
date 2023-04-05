
using Quartz;
using Quartz.Impl;
using System;
using WindowsProcessMonitor.UI.DependencyInjector;

namespace WindowsProcessMonitor.UI.Job
{
    public  static class CronJob
    { 
        public static void InitializeJob(params object[] values)
        {
            JobDataMap parameters = new JobDataMap();
            parameters.Put("name", values[0].ToString());
            parameters.Put("lifeTime", Convert.ToInt32(values[1]));


            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            IScheduler scheduler = schedulerFactory.GetScheduler();

            IJobDetail jobDetail = JobBuilder.Create<WindowsProcessMonitorJobs>()
                .UsingJobData(parameters)
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInMinutes(Convert.ToInt32(values[1]))
                    .RepeatForever())
                .Build();

            scheduler.JobFactory = new DependencyInjectionJobFactory(UnityContainerConfig.Container);
            scheduler.ScheduleJob(jobDetail, trigger);
            scheduler.Start();
        }
    }
}
