using NUnit.Framework;
using TechTalk.SpecFlow;

namespace PMLibMockDemo.Egenskaper.Steg
{
    [Binding]
    public class VisaFilmlånSteg
    {
        private Filmbibliotek _filmbibliotek;

        [Before]
        public void SkapaFilmbibliotek()
        {
            _filmbibliotek = Filmbibliotek.SkapaNytt();
        }

        [Given(@"att vännen ""(.*)"" har lånat filmen ""(.*)""")]
        public void GivetAttVannenHarLanatFilmen(string namnPåVän, string filmTitel)
        {
            var vän = Vän.SkapaNyMed(namn: namnPåVän);
            var film = Film.SkapaNyMed(titel: filmTitel);
            _filmbibliotek.RegistreraLån(film: film, låntagare: vän);
        }

        [When(@"jag frågar vem som lånat filmen ""(.*)""")]
        public void NarJagFragarVemSomLanatFilmen(string titel)
        {
            var film = Film.SkapaNyMed(titel: titel);
            var lån = _filmbibliotek.HittaLånAv(film: film);
            IVy vy = VisaLånVy.SkapaNyMed(modell: lån);
            ScenarioContext.Current.Set(vy);
        }
        
        [Then(@"ska meddelandet ""(.*)"" visas på skärmen")]
        public void SaSkaMeddelandetVisasPaSkarmen(string meddelande)
        {
            var vy = ScenarioContext.Current.Get<IVy>();
            Assert.That(vy.Rendera(), Is.EqualTo(meddelande));
        }
    }
}
