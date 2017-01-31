using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravianBot.Models
{
    public class TravianJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Travian.RunTest();
        }
    }
}