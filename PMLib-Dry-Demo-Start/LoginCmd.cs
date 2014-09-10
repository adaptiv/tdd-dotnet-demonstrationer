using System.IO;
using System.Text;

namespace PMLibDryDemoStart
{
    public class LoginCmd
    {

        private static readonly byte[] header = {0xde, 0xad};
        private static readonly byte[] commandChar = {0x01};
        private static readonly byte[] footer = {0xbe, 0xef};
        private const int SizeLength = 1;
        private const int CmdByteLength = 1;

        private readonly string _userName;
        private readonly string _password;

        public LoginCmd(string userName, string password)
        {
            _userName = userName;
            _password = password;
        }

        private int GetSize()
        {
            return header.Length +
                   SizeLength +
                   CmdByteLength +
                   footer.Length +
                   ToBytes(_userName).Length + 1 +
                   ToBytes(_password).Length + 1;
        }

        public void Write(Stream outputStream)
        {
            outputStream.Write(header);
            outputStream.WriteByte((byte) GetSize());
            outputStream.Write(commandChar);
            outputStream.Write(ToBytes(_userName));
            outputStream.WriteByte(0x00);
            outputStream.Write(ToBytes(_password));
            outputStream.WriteByte(0x00);
            outputStream.Write(footer);
        }

        private static byte[] ToBytes(string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }
    }

}
 