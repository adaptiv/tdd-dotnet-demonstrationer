namespace PMLibDryDemoEnd
{
    public class AddMovieCommand : Command
    {
        public AddMovieCommand(string title, string director, int minutes, string rating)
        {
            Fields.Add(title);
            Fields.Add(director);
            Fields.Add(minutes.ToString());
            Fields.Add(rating);
        }

        protected override byte[] CommandChar
        {
            get { return new byte[] { 0x02 }; }
        }
    }
}