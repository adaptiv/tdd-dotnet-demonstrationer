namespace PMLibMockDemo
{
    public class Film
    {
        private Film(string titel)
        {
            Titel = titel;
        }

        public string Titel { get; private set; }


        public static Film SkapaNyMed(string titel)
        {
            return new Film(titel);

        }
    }
}