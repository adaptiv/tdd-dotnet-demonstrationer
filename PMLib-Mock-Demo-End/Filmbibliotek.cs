using System;

namespace PMLibMockDemo
{
    public class Filmbibliotek
    {
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

        public L�n HittaL�nAv(Film film)
        {
            return _utl�ningsregister.HittaL�nAv(film: film);
        }

    }
}