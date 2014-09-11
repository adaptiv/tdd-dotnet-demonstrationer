using System.IO;
using NUnit.Framework;

namespace PMLibDryDemoEnd
{
    [TestFixture]
    class LoginCommandTest
    {
        
        private LoginCmd _loginCommand;
    
        [SetUp]
        public void SetUp()
        {
            _loginCommand = new LoginCmd("jholm", "pass");
        }

        [Test]
        public void TestWriteLoginCommand()
        {
            using (var stream = new MemoryStream(50))
            {
                _loginCommand.Write(stream);

                byte[] expected = BuildExpectedLoginCommandOutput();
                Assert.AreEqual(expected, stream.GetBuffer());
            }
            
        }

        private byte[] BuildExpectedLoginCommandOutput()
        {
            var expected = new byte[50];
            expected[0] = 0xde;
            expected[1] = 0xad;
            expected[2] = 17;
            expected[3] = 0x01;
            expected[4] = 106;  // j
            expected[5] = 104;  // h
            expected[6] = 111;  // o
            expected[7] = 108;  // l
            expected[8] = 109;  // m
            expected[9] = 0x00;
            expected[10] = 112; // p
            expected[11] = 97;  // a
            expected[12] = 115; // s
            expected[13] = 115; // s
            expected[14] = 0x00;
            expected[15] = 0xbe;
            expected[16] = 0xef;
            return expected;
        }
    }
}
