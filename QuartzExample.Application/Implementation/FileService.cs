using Microsoft.Extensions.Logging;
using QuartzExample.Application.Services.Interfaces;
using QuartzExample.Domian.Entities;
using QuartzExample.Domian.Interfaces.Repository;

namespace QuartzExample.Application.Implementation
{
    public class FileService : IFileService
    {
        private readonly ISettings settings;
        private readonly ILocationRepository locationRepository;

        public FileService(ISettings settings, ILocationRepository locationRepository)
        {
            this.settings = settings;
            this.locationRepository = locationRepository;
        }

        public async Task<int> ReadAndSave(ILogger logger)
        {
            try
            {
                var locations = new List<Location>();
                var result = false;

                using (StreamReader file = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), settings.FileName)))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        Location location = new Location { Name = line.Trim() };
                        locations.Add(location);
                    }
                }

                if (locations.Any())
                {
                    result = await locationRepository.AddAsync(locations, logger);
                }

                return locations.Count;
            }
            catch (Exception ex)
            {
                logger.LogError($"{ex.Message} - {ex.StackTrace}");
                return 0;
            }
        }
    }
}
