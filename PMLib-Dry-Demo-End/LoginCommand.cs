
namespace PMLibDryDemoEnd
{
    public class LoginCommand : Command
    {
        public LoginCommand(string userName, string password)
        {
            Fields.Add(userName);
            Fields.Add(password);
        }

        protected override byte[] CommandChar
        {
            get { return new byte[] { 0x01 }; }
        }
    }

}
