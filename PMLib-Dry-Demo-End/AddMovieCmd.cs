using System.IO;

namespace PMLibDryDemoEnd
{
    public class AddMovieCmd : Command
    {
        private readonly string _title;
        private readonly string _director;
        private readonly string _minutes;
        private readonly string _rating;

        public AddMovieCmd(string title, string director, int minutes, string rating)
        {
            _title = title;
            _director = director;
            _minutes = minutes.ToString();
            _rating = rating;
        }

        protected override int GetBodySize()
        {
            return _title.ToBytes().Length + 1 +
                   _director.ToBytes().Length + 1 +
                   _minutes.ToBytes().Length + 1 +
                   _rating.ToBytes().Length + 1;
        }

        protected override byte[] CommandChar
        {
            get { return new byte[] {0x02}; }
        }

        protected override void WriteBody(Stream outputStream)
        {
            WriteField(outputStream, _title);
            WriteField(outputStream, _director);
            WriteField(outputStream, _minutes);
            WriteField(outputStream, _rating);
        }
    }
}
