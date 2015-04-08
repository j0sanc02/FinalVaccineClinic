using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using UniversityofLouisvilleVaccine.ScheduledTasks;
using Quartz;
using Quartz.Impl;
using System.Net.Mail;

namespace UniversityofLouisvilleVaccine
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            JobScheduler.Start();

            // http://stackoverflow.com/questions/3245975/quartz-net-setup-in-an-asp-net-website
            // http://www.dijksterhuis.org/using-csharp-to-send-an-e-mail-through-smtp/
            // Code below lets Quartz know when to start this process 
            // DateTimeOffset startTime = DateBuilder.FutureDate(1, IntervalUnit.Hour);
            IJobDetail job = JobBuilder.Create<sendmail>()
                                       .WithIdentity("job1")
                                       .Build();
            ITrigger trigger = TriggerBuilder.Create()
                                             .WithIdentity("trigger1")
                                             // .StartAt(startTime)
                                             .WithSimpleSchedule(x => x.WithIntervalInMinutes(1))
                                             .Build();
            ISchedulerFactory sf = new StdSchedulerFactory();
            IScheduler sc = sf.GetScheduler();
            sc.ScheduleJob(job, trigger);
            sc.Start();
        }
    }
    public class sendmail : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            SmtpClient client = new SmtpClient();
            MailAddress toUser = new MailAddress("test@test.com");
            MailAddress fromUser = new MailAddress("syntax@syntaxsolutions.com");
            MailMessage msg = new MailMessage(fromUser, toUser);
            msg.Subject = "Test Message";
            msg.Body = "This is a test message. " + Environment.NewLine;
            msg.Body += "This is another line.";
            client.Send(msg);

            

        }
    }
}
