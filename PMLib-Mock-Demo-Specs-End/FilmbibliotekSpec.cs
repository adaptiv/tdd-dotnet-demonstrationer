using Moq;
using NUnit.Framework;

namespace PMLibMockDemo
{
    [TestFixture]
    public class FilmbibliotekSpec
    {
        private Filmbibliotek _filmbibliotek ;
        private Mock<IUtlåningsregister> _lånRegisterMock;

        [SetUp]
        public void SkapaFilmbibliotek()
        {
            _lånRegisterMock = new Mock<IUtlåningsregister>();
            _filmbibliotek = Filmbibliotek.SkapaNytt(utlåningsregister: _lånRegisterMock.Object);
        }

        [Test]
        public void RegistrerarLån()
        {
            // Arrange
            Film film = Film.SkapaNyMed(titel: "Hajen");
            Vän vän = Vän.SkapaNyMed(namn: "Måns");

            // Act
            _filmbibliotek.RegistreraLån(film: film, låntagare: vän);

            // Assert
            _lånRegisterMock.Verify(l => l.RegistreraLån(film, vän));
        }

        [Test]
        public void VisarVemSomLånatEnFilm()
        {
            // Arrange
            Vän låntagare = Vän.SkapaNyMed(namn: "Måns");
            Film film = Film.SkapaNyMed(titel: "Hajen");
            Lån lån = Lån.SkapaNytt(film: film, låntagare: låntagare);
            _lånRegisterMock.Setup(l => l.HittaLånAv(film)).Returns(lån);

            // Act
            string resultat = _filmbibliotek.VisaVemSomLånat(film);

            // Assert
            Assert.That(resultat, Is.EqualTo("Måns har lånat filmen Hajen"));
        }
    }
}
