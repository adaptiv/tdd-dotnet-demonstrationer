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
        public void SkaparFilmbibliotek()
        {
            _lånRegisterMock = new Mock<IUtlåningsregister>();
            _filmbibliotek = Filmbibliotek.SkapaNytt(utlåningsregister: _lånRegisterMock.Object);
        }

        [Test]
        public void RegistrerarLån()
        {
            // Arrange
            var film = Film.SkapaNyMed(titel: "Hajen");
            var vän = Vän.SkapaNyMed(namn: "Måns");

            // Act
            _filmbibliotek.RegistreraLån(film: film, låntagare: vän);

            // Assert
            _lånRegisterMock.Verify(l => l.RegistreraLån(film, vän));
        }

        [Test]
        public void HittarLånAvFilm()
        {
            // Arrange
            Vän låntagare = Vän.SkapaNyMed(namn: "Måns");
            Film film = Film.SkapaNyMed(titel: "Hajen");
            Lån lån = Lån.SkapaNytt(film: film, låntagare: låntagare);
            _lånRegisterMock.Setup(l => l.HittaLånAv(film)).Returns(lån);

            // Act
            var resultat = _filmbibliotek.HittaLånAv(film);

            // Assert
            Assert.That(resultat, Is.EqualTo(lån));
        }
    }
}
