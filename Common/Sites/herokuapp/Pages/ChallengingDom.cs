namespace Common.Sites.herokuapp.Pages
{
    internal class ChallengingDom : BasePlaywrightPage
    {
        internal ChallengingDom(IPage? webPage) : base(webPage)
        { }

        private ILocator RedButton => LocateElementByXPath("/html/body/div[2]/div/div/div/div/div[1]/a[2]");
        private ILocator BlueButton => LocateElementByXPath("/html/body/div[2]/div/div/div/div/div[1]/a[1]");
        private ILocator GreenButton => LocateElementByXPath("/html/body/div[2]/div/div/div/div/div[1]/a[3]");

        internal async Task<string> GetIdOfBlueButton()
        {
            IElementHandle? element = await BlueButton.ElementHandleAsync();
            var id = await element.GetAttributeAsync("id");

            if (id == null)
                throw new NullReferenceException($"{nameof(GetIdOfBlueButton)} has no id");

            return id;
        }

        internal async Task<string> GetIdOfRedButton()
        {
            IElementHandle? element = await RedButton.ElementHandleAsync();
            var id = await element.GetAttributeAsync("id");

            if (id == null)
                throw new NullReferenceException($"{nameof(GetIdOfRedButton)} has no id");

            return id;
        }

        internal async Task<string> GetIdOfGreenButton()
        {
            IElementHandle? element = await GreenButton.ElementHandleAsync();
            var id = await element.GetAttributeAsync("id");

            if (id == null)
                throw new NullReferenceException($"{nameof(GetIdOfGreenButton)} has no id");

            return id;
        }

        internal async Task ClickRedButton()
        {
            await RedButton.ClickAsync();
        }
    }
}