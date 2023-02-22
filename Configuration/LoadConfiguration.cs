using Microsoft.Extensions.Configuration;

namespace Configuration
{
    internal static class LoadConfiguration
    {
        internal static IConfiguration InitaliseConfiguration()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.Development.json")
               .Build();

            return config;
        }
    }
}