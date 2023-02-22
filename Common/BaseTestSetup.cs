namespace Common
{
    /// <summary>
    /// Extend to use in any base test setup
    /// Inherit to Nunit, Xunit or (MstTest if you want!)
    /// </summary>
    public abstract class BaseTestSetup
    {
        /// <summary>
        /// Test Configuration
        /// </summary>
        public ITestConfiguration Configuration;

        /// <summary>
        /// Initalised Playwright browser
        /// </summary>
        public IBrowser? TestBrowser;

        /// <summary>
        /// Initalise a new web page
        /// </summary>
        public IPage? WebPage;

        /// <summary>
        /// Play
        /// </summary>
        internal IPlaywright? PlaywrightDriver;

        public BaseTestSetup()
        {
            Configuration = new TestConfiguration();
        }

        /// <summary>
        /// Will initalise a new webpage and navigate to it
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task NavigateToPage(string url)
        {
            await SetUpPage(url);
        }

        private async Task InitalisePlaywrightAndBrowser()
        {
            if (PlaywrightDriver == null)
                await InitalisePlaywright();

            if (TestBrowser == null || !TestBrowser.IsConnected)
                await InitalisePlaywrightBrowser();
        }

        private async Task InitalisePlaywright()
        {
            try
            {
                if (Configuration.Browser == Browser.None)
                    throw new Exception($"Browser {Configuration.Browser} is not valid to initalise playwright");

                int exitCode = Program.Main(new[] { "install" });
                if (exitCode != 0)
                    throw new Exception($"{nameof(InitalisePlaywright)} Playwright exited with code {exitCode}");

                PlaywrightDriver = await Playwright.CreateAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(InitalisePlaywright)} {ex.Message}");
            }
        }

        private async Task InitalisePlaywrightBrowser()
        {
            var browserLaunchOptions = new BrowserTypeLaunchOptions
            {
                Headless = Configuration.Headless,
                Args = new List<string>()
            };

            if (Configuration.StartMaximised)
                browserLaunchOptions.Args.ToList().Add("--start-maximized");

            switch (Configuration.Browser)
            {
                case Browser.Chromium:
                    TestBrowser = await PlaywrightDriver.Chromium.LaunchAsync(browserLaunchOptions);
                    break;

                case Browser.Chrome:
                    browserLaunchOptions.Channel = "chrome";
                    TestBrowser = await PlaywrightDriver.Chromium.LaunchAsync(browserLaunchOptions);
                    break;

                case Browser.Edge:
                    browserLaunchOptions.Channel = "msedge";
                    TestBrowser = await PlaywrightDriver.Chromium.LaunchAsync(browserLaunchOptions);
                    break;

                case Browser.Safari:
                    TestBrowser = await PlaywrightDriver.Webkit.LaunchAsync(browserLaunchOptions);
                    break;

                case Browser.Firefox:
                    TestBrowser = await PlaywrightDriver.Firefox.LaunchAsync(browserLaunchOptions);
                    break;

                default:
                    throw new Exception($"{nameof(InitalisePlaywrightBrowser)} is unable to handle browser configuration of {Configuration.Browser}");
            }
        }

        private async Task SetUpPage(string url)
        {
            await InitalisePlaywrightAndBrowser();
            IBrowserContext browserContext;

            browserContext = await TestBrowser.NewContextAsync(new BrowserNewContextOptions { ViewportSize = ViewportSize.NoViewport });

            WebPage = await browserContext.NewPageAsync();
            await WebPage.GotoAsync(url);

            if (WebPage == null)
                throw new Exception($"{nameof(NavigateToPage)} IPage is null, initalising {Configuration.Browser} to url {url} has failed");
        }
    }
}