namespace PMLibMockDemo
{
    public class Vän
    {
        private Vän(string namn)
        {
            Namn = namn;
        }

        public string Namn { get; private set; }

        public static Vän SkapaNyMed(string namn)
        {
            return new Vän(namn);
        }
    }
}