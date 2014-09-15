using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PMLibDryDemoEnd
{
    public abstract class Command
    {
        private const int SizeLength = 1;
        private const int CmdByteLength = 1;
        private const int TerminatorCharLength = 1;
        private static readonly byte[] Header = { 0xde, 0xad };
        private static readonly byte[] Footer = { 0xbe, 0xef };

        protected readonly List<string> Fields = new List<string>();

        public void Write(Stream outputStream)
        {
            WriteHeader(outputStream);
            WriteBody(outputStream);
            WriteFooter(outputStream);
        }

        private void WriteHeader(Stream outputStream)
        {
            outputStream.Write(Header);
            outputStream.WriteByte((byte) GetSize());
            outputStream.Write(CommandChar);
        }

        private int GetSize()
        {
            return Header.Length +
                   SizeLength +
                   CmdByteLength +
                   Footer.Length +
                   GetBodySize();
        }

        private int GetBodySize()
        {
            return Fields.Sum(field => GetFieldSize(field));
        }

        private static int GetFieldSize(string field)
        {
            return field.ToBytes().Length + TerminatorCharLength;
        }

        protected abstract byte[] CommandChar { get; }

        private void WriteBody(Stream outputStream)
        {
            Fields.ForEach(field => WriteField(outputStream, field));
        }

        private static void WriteField(Stream outputStream, string field)
        {
            outputStream.Write(field.ToBytes());
            outputStream.WriteByte(0x00);
        }

        private static void WriteFooter(Stream outputStream)
        {
            outputStream.Write(Footer);
        }
    }
}