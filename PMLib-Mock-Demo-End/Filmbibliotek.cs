using System;

namespace PMLibMockDemo
{
    public class Filmbibliotek
    {
        private const string UtlåningsMeddelande = "{0} har lånat filmen {1}";

        private readonly IUtlåningsregister _utlåningsregister;

        public static Filmbibliotek SkapaNytt()
        {
            // TODO: Ersätt med riktig implementation när den finns
            IUtlåningsregister utlåningsregister = null;

            return new Filmbibliotek(utlåningsregister: utlåningsregister);
        }

        public static Filmbibliotek SkapaNytt(IUtlåningsregister utlåningsregister)
        {
            return new Filmbibliotek(utlåningsregister);
        }

        private Filmbibliotek(IUtlåningsregister utlåningsregister)
        {
            _utlåningsregister = utlåningsregister;
        }

        public void RegistreraLån(Film film, Vän låntagare)
        {
            _utlåningsregister.RegistreraLån(film, låntagare);
        }

        public string VisaVemSomLånat(Film film)
        {
            var lån = HittaLånAvFilm(film);
            var meddelande = SkapaUtlåningsMeddelande(lån);

            return meddelande;
        }

        private Lån HittaLånAvFilm(Film film)
        {
            return _utlåningsregister.HittaLånAv(film: film);
        }

        private static string SkapaUtlåningsMeddelande(Lån lån)
        {
            return String.Format(UtlåningsMeddelande, lån.Låntagare.Namn, lån.Film.Titel);
        }
    }
}