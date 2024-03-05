using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using QuartzExample.Application.Implementation;
using QuartzExample.Application.Services.Interfaces;
using QuartzExample.Domian.Interfaces.Repository;
using QuartzExample.Infrastructure.Data.SqlServer.Repository;
using QuartzExample.QuartzJob.Jobs;
using System.Diagnostics.CodeAnalysis;

namespace QuartzExample.Infrastructure.CrossCutting.IoC.DI.DI
{
    public static class DependencyInjection
    {
        [ExcludeFromCodeCoverage]
        public static void Inject(this IServiceCollection services)
        {
            #region Services            
            services.AddSingleton<IFileService, FileService>();
            services.AddSingleton<ISettings, Settings>();
            services.AddSingleton<IGenericSettings, GenericSettings>();
            #endregion

            #region Repositories            
            services.AddSingleton<ILocationRepository, LocationRepository>();
            #endregion

            #region Hangfire     
            //services.AddSingleton<IGetFilesService, GetFilesService>();
            #endregion

            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<GetFilesServiceJob>>();
            services.AddSingleton(typeof(ILogger), logger);
        }
    }
}