﻿using System.IO;

namespace PMLibDryDemoEnd
{
    public abstract class Command
    {
        protected const int SizeLength = 1;
        protected const int CmdByteLength = 1;
        protected static readonly byte[] header = {0xde, 0xad};
        protected static readonly byte[] footer = {0xbe, 0xef};

        protected static void WriteField(Stream outputStream, string field)
        {
            outputStream.Write(field.ToBytes());
            outputStream.WriteByte(0x00);
        }

        protected abstract byte[] CommandChar { get; }

        protected abstract int GetSize();

        protected abstract void WriteBody(Stream outputStream);

        public void Write(Stream outputStream)
        {
            outputStream.Write(header);
            outputStream.WriteByte((byte) GetSize());
            outputStream.Write(CommandChar);
            WriteBody(outputStream);
            outputStream.Write(footer);
        }
    }
}