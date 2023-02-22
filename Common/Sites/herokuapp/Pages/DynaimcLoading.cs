namespace Common.Sites.herokuapp.Pages
{
    internal class DynaimcLoading : BasePlaywrightPage
    {
        internal DynaimcLoading(IPage? webPage) : base(webPage)
        { }

        private ILocator Example2 => LocateElementByCssText("Example 2: Element rendered after the fact", CssTag.a);
        private ILocator StartButton => LocateElementByCssText("Start", CssTag.button);
        private ILocator Loader => LocateElementByCssText("loading", CssTag.id);
        private ILocator HellowWorldHeader => LocateElementByCssText("Hello World", CssTag.h4);

        internal async Task ClickExample2()
        {
            await Example2.ClickAsync();
        }

        internal async Task ClickStartButton()
        {
            await StartButton.ClickAsync();
        }

        internal async Task<string> GetHelloWroldHeader()
        {
            return await HellowWorldHeader.InnerTextAsync();
        }

        internal async Task WaitForLoader()
        {
            await Loader.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden });
        }
    }
}