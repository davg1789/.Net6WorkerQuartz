using Microsoft.Extensions.Logging;
using Quartz;
using QuartzExample.Application.Services.Interfaces;

namespace QuartzExample.QuartzJob.Jobs
{
    public class GetFilesServiceJob : IJob
    {

        private readonly IFileService fileService;
        private readonly ILogger<GetFilesServiceJob> logger;

        public GetFilesServiceJob(ILogger<GetFilesServiceJob> logger, IFileService fileService) 
        {
            this.fileService = fileService;
            this.logger = logger;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                logger.LogInformation($"(GetFilesService) - Start  {DateTime.Now}");

                var result = await fileService.ReadAndSave(logger);

                logger.LogInformation($"(GetFilesService) - Completion date: {DateTime.Now} - {result} locations added");
            }
            catch (Exception ex)
            {
                logger.LogError($"(GetFilesService) - Error: {ex.Message}");
            }
        }
    }
}