using System;

namespace PMLibMockDemo
{
    public class Filmbibliotek
    {
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

        public Lån HittaLånAv(Film film)
        {
            return _utlåningsregister.HittaLånAv(film: film);
        }

    }
}