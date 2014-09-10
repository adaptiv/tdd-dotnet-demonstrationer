using System.IO;

namespace PMLibDryDemoStart
{
    static class StreamExtensions
    {
        public static void Write(this Stream stream, byte[] buffer)
        {
            stream.Write(buffer, 0, buffer.Length);
        }
    }
}
