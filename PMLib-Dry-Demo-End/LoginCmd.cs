using System.IO;

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
                   _userName.ToBytes().Length + 1 +
                   _password.ToBytes().Length + 1;
        }

        public void Write(Stream outputStream)
        {
            outputStream.Write(header);
            outputStream.WriteByte((byte) GetSize());
            outputStream.Write(commandChar);
            outputStream.Write(_userName.ToBytes());
            outputStream.WriteByte(0x00);
            outputStream.Write(_password.ToBytes());
            outputStream.WriteByte(0x00);
            outputStream.Write(footer);
        }
    }

}
 