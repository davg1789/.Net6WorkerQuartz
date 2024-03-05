using QuartzExample.Domian.Entities;
using Microsoft.Extensions.Logging;

namespace QuartzExample.Domian.Interfaces.Repository
{
    public interface ILocationRepository
    {
        Task<bool> AddAsync(IList<Location> location, ILogger logger);
    }
}
