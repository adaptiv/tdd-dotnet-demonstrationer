
namespace PMLibDryDemoEnd
{
    public class LoginCommand : Command
    {
        public LoginCommand(string userName, string password)
            : base(userName, password)
        {
        }

        protected override byte[] CommandChar
        {
            get { return new byte[] { 0x01 }; }
        }
    }

}
