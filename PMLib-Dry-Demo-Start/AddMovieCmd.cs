using System.IO;
using System.Text;

namespace PMLibDryDemoStart
{
    class AddMovieCmd
    {
        private static readonly byte[] header = {0xde, 0xad};
        private static readonly byte[] commandChar = {0x02};
        private static readonly byte[] footer = {0xbe, 0xef};
        private const int SizeLength = 1;
        private const int CmdByteLength = 1;
        
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
        
        private int GetSize()
        {
            return header.Length +
            SizeLength + 
            CmdByteLength +
            footer.Length + 
            Encoding.UTF8.GetBytes(_title).Length + 1 +
            Encoding.UTF8.GetBytes(_director).Length + 1 +
            Encoding.UTF8.GetBytes(_minutes).Length + 1 +
            Encoding.UTF8.GetBytes(_rating).Length + 1;
        }


        public void Write(Stream outputStream)
        {
            outputStream.Write(header);
            outputStream.WriteByte((byte) GetSize());
            outputStream.Write(commandChar, 0, commandChar.Length);
            outputStream.Write(Encoding.UTF8.GetBytes(_title));
            outputStream.WriteByte(0x00);
            outputStream.Write(Encoding.UTF8.GetBytes(_director));
            outputStream.WriteByte(0x00);
            outputStream.Write(Encoding.UTF8.GetBytes(_minutes));
            outputStream.WriteByte(0x00);
            outputStream.Write(Encoding.UTF8.GetBytes(_rating));
            outputStream.WriteByte(0x00);
            outputStream.Write(footer);
        }
    }
}
