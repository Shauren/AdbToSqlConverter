using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ADBParser
{
    public static class Extensions
    {
        /// <summary>
        /// Reads a null-terminated string from a given <see cref="BinaryReader"/>.
        /// </summary>
        /// <param name="reader">The reader to read the string from.</param>
        /// <param name="encoding">The encoding to use (<see cref="ASCIIEncoding"/> by default).</param>
        /// <returns>The string read from the given reader.</returns>
        public static string ReadCString(this BinaryReader reader, Encoding encoding = null)
        {
            var list = new List<byte>();

            while (true)
            {
                var chr = reader.ReadByte();

                if (chr == 0)
                    break;

                list.Add(chr);
            }

            var arr = list.ToArray();
            return (encoding ?? Encoding.ASCII).GetString(arr);
        }

        public static string EscapeSQL(this string str)
        {
            return string.Format("'{0}'", str.Replace("'", "''"));
        }
    }
}
