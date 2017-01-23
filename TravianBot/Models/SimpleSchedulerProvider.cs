namespace TravianBot
{
    using System;
    using CrystalQuartz.Core.SchedulerProviders;
    using Quartz;

    public class SimpleSchedulerProvider : StdSchedulerProvider
    {
        protected override System.Collections.Specialized.NameValueCollection GetSchedulerProperties()
        {
            var properties = base.GetSchedulerProperties();
            // Place custom properties creation here:
            //     properties.Add("test1", "test1value");
            return properties;
        }

        protected override void InitScheduler(IScheduler scheduler)
        {
            // Put jobs creation code here


        }

        internal class HelloJob : IJob
        {
            public void Execute(IJobExecutionContext context)
            {
                Console.WriteLine("Hello, CrystalQuartz!");
            }
        }
    }
}