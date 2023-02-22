namespace Common.Sites.herokuapp.Actions
{
    public class DynamicLoadingActions
    {
        private DynaimcLoading dynamicLoading;

        public DynamicLoadingActions(IPage? webPage)
        {
            dynamicLoading = new DynaimcLoading(webPage);
        }

        public async Task ClickExample2AndStart()
        {
            await dynamicLoading.ClickExample2();
            await dynamicLoading.ClickStartButton();
        }

        public async Task WaitForLoad()
        {
            await dynamicLoading.WaitForLoader();
        }

        public async Task<string> HelloWorldHeader()
        {
            return await dynamicLoading.GetHelloWroldHeader();
        }
    }
}