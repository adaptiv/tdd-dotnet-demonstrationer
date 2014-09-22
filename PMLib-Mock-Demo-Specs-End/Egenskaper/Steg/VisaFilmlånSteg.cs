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
            string resultat = _filmbibliotek.VisaVemSomLånat(film);
            ScenarioContext.Current.Set<string>(resultat, "resultat");
        }
        
        [Then(@"ska meddelandet ""(.*)"" visas på skärmen")]
        public void SaSkaMeddelandetVisasPaSkarmen(string meddelande)
        {
            var resultat = ScenarioContext.Current.Get<string>("resultat");
            Assert.That(resultat, Is.EqualTo(meddelande));
        }
    }
}
