using TechTalk.SpecFlow;

namespace PMLibMockDemo.Egenskaper.Steg
{
    [Binding]
    public class VisaFilmlånSteg
    {
        [Given(@"att vännen ""(.*)"" har lånat filmen ""(.*)""")]
        public void GivetAttVannenHarLanatFilmen(string namnPåVän, string filmTitel)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"jag frågar vem som lånat filmen ""(.*)""")]
        public void NarJagFragarVemSomLanatFilmen(string filmTitel)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"ska meddelandet ""(.*)"" visas på skärmen")]
        public void SaSkaMeddelandetVisasPaSkarmen(string meddelande)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
