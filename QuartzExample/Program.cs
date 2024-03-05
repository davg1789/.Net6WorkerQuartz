using Quartz;
using QuartzExample.Infrastructure.CrossCutting.IoC.DI.DI;
using QuartzExample.QuartzJob.Jobs;
using QuartzExample.QuartzJob.Extensions;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddQuartz(q =>
        {
            q.UseMicrosoftDependencyInjectionScopedJobFactory();
            q.AddJobAndTrigger<GetFilesServiceJob>(hostContext.Configuration);          
        });
        services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
        services.Inject();
    })
    .Build();

await host.RunAsync();
