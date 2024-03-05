using Microsoft.Extensions.Configuration;
using QuartzExample.Application.Services.Interfaces;

namespace QuartzExample.Application.Implementation
{
    public class Settings : ISettings
    {
        private readonly IGenericSettings genericSettings;
        private readonly IConfiguration iconfiguration;

        public Settings(IGenericSettings genericSettings, IConfiguration iconfiguration)
        {
            this.genericSettings = genericSettings;
            this.iconfiguration = iconfiguration;
        }
        public string FileName
        {
            get { return genericSettings.ReadString(iconfiguration, "Settings:FileName"); }
        }

        public string ConnectionString
        {
            get { return genericSettings.ReadString(iconfiguration, "ConnectionStrings:DefaultConnection"); }
        }
    }
}
