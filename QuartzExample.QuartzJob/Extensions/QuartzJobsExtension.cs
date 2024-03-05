using Microsoft.Extensions.Configuration;
using Quartz;

namespace QuartzExample.QuartzJob.Extensions
{
    public static class QuartzJobsExtension
    {
        public static void AddJobAndTrigger<T>(
            this IServiceCollectionQuartzConfigurator quartz,
            IConfiguration config)
            where T : IJob
        {            
            string nomeJob = typeof(T).Name;

            var configKey = $"Quartz:{nomeJob}";
            var cronHorarioExecucao = config[configKey]; 

            if (string.IsNullOrEmpty(cronHorarioExecucao))
            {
                throw new Exception($"No Quartz.NET Cron schedule found for job in configuration at {configKey}");
            }

            //registrando o job
            var jobKey = new JobKey(nomeJob);
            quartz.AddJob<T>(opts => opts.WithIdentity(jobKey));

            quartz.AddTrigger(opts => opts
                .ForJob(jobKey)
                .WithIdentity(nomeJob + "-trigger")
                .WithCronSchedule(cronHorarioExecucao));
        }
    }
}
