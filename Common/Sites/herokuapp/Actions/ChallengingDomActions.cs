namespace Common.Sites.herokuapp.Actions
{
    public class ChallengingDomActions
    {
        private ChallengingDom challengingDom;

        public ChallengingDomActions(IPage? webPage)
        {
            challengingDom = new ChallengingDom(webPage);
        }

        public async Task<ChallengingDomId> GetButtonIds()
        {
            return new ChallengingDomId
            {
                RedBoxId = await challengingDom.GetIdOfRedButton(),
                BlueBoxId = await challengingDom.GetIdOfBlueButton(),
                GreenBoxId = await challengingDom.GetIdOfGreenButton()
            };
        }

        public async Task<ChallengingDomId> ClickRedButtonAndRetrunIds()
        {
            await challengingDom.ClickRedButton();
            return new ChallengingDomId
            {
                RedBoxId = await challengingDom.GetIdOfRedButton(),
                BlueBoxId = await challengingDom.GetIdOfBlueButton(),
                GreenBoxId = await challengingDom.GetIdOfGreenButton()
            };
        }
    }
}