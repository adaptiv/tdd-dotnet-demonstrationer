namespace PMLibMockDemo
{
    public class L�n
    {
        public V�n L�ntagare { get; set; }
        public Film Film { get; set; }

        public L�n(V�n l�ntagare, Film film)
        {
            L�ntagare = l�ntagare;
            Film = film;
        }

        public static L�n SkapaNytt(V�n l�ntagare, Film film)
        {
            return new L�n(l�ntagare, film);
        }
    }
}