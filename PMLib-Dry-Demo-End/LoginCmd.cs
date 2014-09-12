using System.IO;

namespace PMLibDryDemoEnd
{
    public class LoginCmd : Command
    {
        private readonly string _userName;
        private readonly string _password;

        public LoginCmd(string userName, string password)
        {
            _userName = userName;
            _password = password;
        }

        protected override int GetBodySize()
        {
            return _userName.ToBytes().Length + 1 +
                   _password.ToBytes().Length + 1;
        }

        protected override byte[] CommandChar
        {
            get { return new byte[] {0x01}; }
        }

        protected override void WriteBody(Stream outputStream)
        {
            WriteField(outputStream, _userName);
            WriteField(outputStream, _password);
        }
    }

}
 