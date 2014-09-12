namespace PMLibDryDemoEnd
{
    public class AddMovieCommand : Command
    {
        public AddMovieCommand(string title, string director, int minutes, string rating)
            : base(title, director, minutes.ToString(), rating)
        {
        }

        protected override byte[] CommandChar
        {
            get { return new byte[] { 0x02 }; }
        }
    }
}