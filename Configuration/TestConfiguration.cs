using Microsoft.Extensions.Configuration;

namespace Configuration
{
    public class TestConfiguration : ITestConfiguration
    {
        private static IConfiguration? _configuration;
        private const string BrowserConfiguration = "BrowserConfiguration";

        public TestConfiguration()
        {
            _configuration = LoadConfiguration.InitaliseConfiguration();
            if (_configuration == null)
                throw new Exception("Test configuration has not been loaded, please investigate");
        }

        public Browser Browser => GetValue<Browser>(nameof(Browser), BrowserConfiguration);

        public bool Headless => GetValue<bool>(nameof(Headless), BrowserConfiguration);

        public bool StartMaximised => GetValue<bool>(nameof(StartMaximised), BrowserConfiguration);

        public string TestName { get; set; }

        private T GetValue<T>(string configurationValue, string section)
        {
            return _configuration.GetSection(section).GetValue<T>(configurationValue);
        }
    }
}