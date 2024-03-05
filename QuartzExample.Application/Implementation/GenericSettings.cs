using Microsoft.Extensions.Configuration;
using QuartzExample.Application.Services.Interfaces;

namespace QuartzExample.Application.Implementation
{
    public class GenericSettings : IGenericSettings
    {
        public string ReadString(IConfiguration iconfiguration, string key, string defaultValue = null)
        {
            string value = iconfiguration.GetSection(key).Value ?? defaultValue;
            return value;
        }

        public double ReadDouble(IConfiguration iconfiguration, string key, double defaultValue)
        {
            string value = ReadString(iconfiguration, key);
            return value == null ? defaultValue : double.Parse(value);
        }

        public DateTime ReadTime(IConfiguration iconfiguration, string key, DateTime defaultValue)
        {
            string value = ReadString(iconfiguration, key);

            return value == null ? defaultValue : DateTime.Parse(value);
        }
    }
}
