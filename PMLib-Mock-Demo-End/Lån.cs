namespace PMLibMockDemo
{
    public class Lån
    {
        public Vän Låntagare { get; set; }
        public Film Film { get; set; }

        public Lån(Vän låntagare, Film film)
        {
            Låntagare = låntagare;
            Film = film;
        }

        public static Lån SkapaNytt(Vän låntagare, Film film)
        {
            return new Lån(låntagare, film);
        }
    }
}