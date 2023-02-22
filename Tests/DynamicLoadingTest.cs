namespace WebTests
{
    [TestFixture]
    public class DynamicLoadingTest : HerokuappTestSetup
    {
        [Test]
        public async Task WhenStartIsClickedThenHellowWorldWillRender()
        {
            //Arrange
            await InitaliseHerokuapp("https://the-internet.herokuapp.com/dynamic_loading");
            await DynamicLoadingActions.ClickExample2AndStart();

            //Act
            await DynamicLoadingActions.WaitForLoad();
            string result = await DynamicLoadingActions.HelloWorldHeader();

            //Assert
            result.Should().Be("Hello World!");
        }
    }
}