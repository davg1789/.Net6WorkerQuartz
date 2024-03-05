using Microsoft.Extensions.Configuration;

namespace QuartzExample.Application.Services.Interfaces
{
    public interface IGenericSettings
    {
        string ReadString(IConfiguration iconfiguration, string key, string defaultValue = null);

        double ReadDouble(IConfiguration iconfiguration, string key, double defaultValue = 0);

        DateTime ReadTime(IConfiguration iconfiguration, string key, DateTime defaultValue = default(DateTime));
    }
}