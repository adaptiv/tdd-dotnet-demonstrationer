using System.IO;
using System.Text;

namespace PMLibDryDemoStart
{
    static class Extensions
    {
        public static void Write(this Stream stream, byte[] buffer)
        {
            stream.Write(buffer, 0, buffer.Length);
        }

        public static byte[] ToBytes(this string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }
    }
}
