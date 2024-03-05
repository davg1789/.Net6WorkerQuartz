using Microsoft.Extensions.Logging;

namespace QuartzExample.Application.Services.Interfaces
{
    public interface IFileService
    {
        Task<int> ReadAndSave(ILogger logger);
    }
}