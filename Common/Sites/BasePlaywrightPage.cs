namespace Common.Sites
{
    internal class BasePlaywrightPage
    {
        internal readonly IPage? _webPage;

        internal BasePlaywrightPage(IPage? webPage)
        {
            _webPage = webPage;
        }

        /// <summary>
        /// Locate Element by tag and text
        /// </summary>
        /// <param name="textToFind">content of the element you are trying to find</param>
        /// <param name="cssTag">tag of the element</param>
        /// <returns></returns>
        public ILocator LocateElementByCssText(string textToFind, CssTag cssTag)
        {
            return _webPage.Locator($"{cssTag}", new PageLocatorOptions { HasTextString = textToFind });
        }

        public ILocator LocateElementByXPath(string locator)
        {
            return _webPage.Locator($"xpath={locator}");
        }
    }
}