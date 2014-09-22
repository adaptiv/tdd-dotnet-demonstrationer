namespace PMLibMockDemo
{
    public interface IUtlåningsregister
    {
        void RegistreraLån(Film film, Vän låntagare);

        Lån HittaLånAv(Film film);
    }
}