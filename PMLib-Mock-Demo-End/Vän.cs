namespace PMLibMockDemo
{
    public class V�n
    {
        private V�n(string namn)
        {
            Namn = namn;
        }

        public string Namn { get; private set; }

        public static V�n SkapaNyMed(string namn)
        {
            return new V�n(namn);
        }
    }
}