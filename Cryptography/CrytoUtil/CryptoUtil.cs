using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoUtil
{
    public class CryptoUtil
    {
        public static string StringToHex(string value)
        {
            string result = string.Empty;
            foreach (var item in value)
            {
                result += ((int)item).ToString("X2");
            }
            return result;
        }
        public static string HexToString(string value)
        {
            string result = string.Empty;
            StringBuilder sb = new StringBuilder("");
            for (int i = 0; i < value.Length; i = i + 2)
            {
                char[] items = new char[2];
                items[0] = value[i];
                items[1] = value[i + 1];
                int asciiCode = Convert.ToInt32(new string(items), 16);
                sb.Append(char.ConvertFromUtf32(asciiCode));
            }
            result = sb.ToString();
            return result;
        }

        /// <summary>
        /// XOR one time pad encryption
        /// </summary>
        /// <param name="value"></param>
        /// <param name="key"></param>
        /// <param name="returnKey"></param>
        /// <returns>encrypted cypher if returnKey == false or returns key </returns>
        public static string XOROtp(string value, string key, bool returnKey = false)
        {
            if (returnKey)
            {
                return XOROtpReturnKey(value, key);
            }
            if (false && value.Length != key.Length)
            {
                string message = "Key length must be equal with message length";
                throw new NotImplementedException(message);
                Debug.WriteLine(message);
            }

            string result = string.Empty;
            StringBuilder sb = new StringBuilder("");

            for (int i = 0; i < value.Length && i < key.Length; i++)
            {
                uint char1 = (uint)value[i];
                uint char2 = (uint)key[i];
                sb.Append((char)(char1 ^ char2));
            }
            result = sb.ToString();

            return result;
        }
        private static string XOROtpReturnKey(string value, string cypher)
        {
            return XOROtp(value, HexToString(cypher));
        }
        public static string HexToBinary(string value)
        {
            string result = string.Empty;
            StringBuilder sb = new StringBuilder("");
            for (int i = 0; i < value.Length; i = i + 2)
            {
                char[] items = new char[2];
                items[0] = value[i];
                items[1] = value[i + 1];
                sb.Append(String.Join(String.Empty, new string(items).Select(c => Convert.ToString(Convert.ToUInt32(c.ToString(), 16), 2).PadLeft(4, '0'))));
            }
             result = sb.ToString();
            return result;
        }
        public static char BinaryToAscii(string value)
        {

            return (char)Convert.ToInt32(value, 2);
        }
    }
}
