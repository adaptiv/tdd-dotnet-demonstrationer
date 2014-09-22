using System;

namespace PMLibMockDemo
{
    public class Filmbibliotek
    {
        private const string Utl�ningsMeddelande = "{0} har l�nat filmen {1}";

        private readonly IUtl�ningsregister _utl�ningsregister;

        public static Filmbibliotek SkapaNytt()
        {
            // TODO: Ers�tt med riktig implementation n�r den finns
            IUtl�ningsregister utl�ningsregister = null;

            return new Filmbibliotek(utl�ningsregister: utl�ningsregister);
        }

        public static Filmbibliotek SkapaNytt(IUtl�ningsregister utl�ningsregister)
        {
            return new Filmbibliotek(utl�ningsregister);
        }

        private Filmbibliotek(IUtl�ningsregister utl�ningsregister)
        {
            _utl�ningsregister = utl�ningsregister;
        }

        public void RegistreraL�n(Film film, V�n l�ntagare)
        {
            _utl�ningsregister.RegistreraL�n(film, l�ntagare);
        }

        public string VisaVemSomL�nat(Film film)
        {
            var l�n = HittaL�nAvFilm(film);
            var meddelande = SkapaUtl�ningsMeddelande(l�n);

            return meddelande;
        }

        private L�n HittaL�nAvFilm(Film film)
        {
            return _utl�ningsregister.HittaL�nAv(film: film);
        }

        private static string SkapaUtl�ningsMeddelande(L�n l�n)
        {
            return String.Format(Utl�ningsMeddelande, l�n.L�ntagare.Namn, l�n.Film.Titel);
        }
    }
}