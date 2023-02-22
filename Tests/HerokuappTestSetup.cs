using Common;

namespace WebTests
{
    public class HerokuappTestSetup : BaseTestSetup
    {
        public ChallengingDomActions ChallengingDomActions;
        public DynamicLoadingActions DynamicLoadingActions;

        /// <summary>
        /// Will run after every test
        /// </summary>
        /// <returns></returns>
        [TearDown]
        public async Task TearDown()
        {
            if (TestBrowser != null)
                await TestBrowser.DisposeAsync();
        }

        /// <summary>
        /// Will run at the start of every test
        /// </summary>
        [SetUp]
        public async Task Setup()
        {
            Configuration.TestName = TestContext.CurrentContext.Test.Name;
        }

        /// <summary>
        /// Attach a file to the test results
        /// </summary>
        /// <param name="filePath"> The full location of the file you wish to attach </param>
        /// <param name="fileName"> The name you want the attached file to be known as on the test results</param>
        public void AttachFileToTestResults(string filePath, string fileName)
        {
            TestContext.AddTestAttachment(filePath, $"{fileName}");
        }

        /// <summary>
        /// Takes a url, then Initalises PageObjects
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task InitaliseHerokuapp(string url)
        {
            await NavigateToPage(url);
            ChallengingDomActions = new ChallengingDomActions(WebPage);
            DynamicLoadingActions = new DynamicLoadingActions(WebPage);
        }
    }
}