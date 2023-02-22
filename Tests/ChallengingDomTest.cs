using Common.Models;

namespace WebTests
{
    [TestFixture]
    public class ChallengingDomTest : HerokuappTestSetup
    {
        [Test]
        public async Task WhenRedButtonIsClickedThenButtonIdsShouldChange()
        {
            //Arrange
            await InitaliseHerokuapp("https://the-internet.herokuapp.com/challenging_dom");
            ChallengingDomId currentIds = await ChallengingDomActions.GetButtonIds();

            //Act
            ChallengingDomId result = await ChallengingDomActions.ClickRedButtonAndRetrunIds();

            //Assert
            using (new AssertionScope())
            {
                result.RedBoxId.Should().NotBeSameAs(currentIds.RedBoxId);
                result.BlueBoxId.Should().NotBeSameAs(currentIds.BlueBoxId);
                result.GreenBoxId.Should().NotBeSameAs(currentIds.GreenBoxId);
            }
        }
    }
}