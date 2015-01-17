using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrequencyAnalisys
{
    class Program
    {

        static void Main(string[] args)
        {
            string cypher = @"ùmèÂ'¢YÈ~áÚ*íWÉ?åÚ6íNÈ~òÆ:®[~ÿÖs¾JÏ{è<«ÎzòÚ=¤OÏzâ5¢L?ðß<£YpåÚ6¿ÎwøÜ4¾lôÑ&¿[|þß>¸PÓ|ðÆ:¢Pvÿ'¥[oã× ¨PÙz±Ý5í_ÎkðÑ8¨LÉ1±ñ!´NÎpöÀ2½VÃ?ùÓ í\ßzÿ&¾[Þ?÷Ý!íVÏqõÀ6©M?øÔs£QÎ?åÚ<¸MÛqõÁíQÜ?è×2¿M?óÇ'íJÈ~õÛ'¤QÔ~ý0¿GÊkþÁ*¾Jßrâ$¨Lß?õ× ¤YÔzõ2£ZzçÓ?¸_Îzõ:£Û?÷Ó:¿RÃ?ðÖs¥QÙ?üÓ=£[È1±ô<¿ßgðß#¡[?åÚ6íhÓxôÜ6¿[zÿÑ!´NÎvþÜs¾]Òzü×sº_É?åÚ<¸YÒk±Æ<í\ß?â×0¸Lß?÷Ý!íZß|ðÖ6¾Ûyå×!íWÎ?æÓ íWÔiôÜ'¨Z?óÇ'íIß?ÿÝ$íUÔpæs¬PÞ?åÚ:¾ßgôÀ0¤Mß?õ×>¢PÉkãÓ'¨M?åÚ2¹Ók±Ñ2£Øz±Ð!¢Ußq±Ä6¿GzðÁ:¡G";
            int length = Utils.GetKeyLength(cypher);
            Utils.Bruteforce(length, cypher);
            List<char> possibleChars = new List<char>();
            for (int j = 0; j < 255; j++)
            {

                if ((cypher[0] ^ j) > 92 && (cypher[0] ^ j) < 122)
                {
                        possibleChars.Add((char)j);
                }
            }
            for (int i = length; i < cypher.Length; i = i + length) {
                for (int j = 0; j < 255; j++)   
                {

                    if ((cypher[i] ^ j) > 92 && (cypher[i] ^ j) < 122)
                    {
                        if (!possibleChars.Contains((char)j))
                            possibleChars.Remove((char)j);
                    }
                }
            }

            char[] key = new char[] { (char)186, (char)31, (char)145, (char)178, (char)83, (char)205, (char)62 };
            Console.WriteLine(Utils.Decrypt(new string(key), cypher));
        }

        void pa2()
        {

            string cypher = @"ùmèÂ'¢YÈ~áÚ*íWÉ?åÚ6íNÈ~òÆ:®[~ÿÖs¾JÏ{è<«ÎzòÚ=¤OÏzâ5¢L?ðß<£YpåÚ6¿ÎwøÜ4¾lôÑ&¿[|þß>¸PÓ|ðÆ:¢Pvÿ'¥[oã× ¨PÙz±Ý5í_ÎkðÑ8¨LÉ1±ñ!´NÎpöÀ2½VÃ?ùÓ í\ßzÿ&¾[Þ?÷Ý!íVÏqõÀ6©M?øÔs£QÎ?åÚ<¸MÛqõÁíQÜ?è×2¿M?óÇ'íJÈ~õÛ'¤QÔ~ý0¿GÊkþÁ*¾Jßrâ$¨Lß?õ× ¤YÔzõ2£ZzçÓ?¸_Îzõ:£Û?÷Ó:¿RÃ?ðÖs¥QÙ?üÓ=£[È1±ô<¿ßgðß#¡[?åÚ6íhÓxôÜ6¿[zÿÑ!´NÎvþÜs¾]Òzü×sº_É?åÚ<¸YÒk±Æ<í\ß?â×0¸Lß?÷Ý!íZß|ðÖ6¾Ûyå×!íWÎ?æÓ íWÔiôÜ'¨Z?óÇ'íIß?ÿÝ$íUÔpæs¬PÞ?åÚ:¾ßgôÀ0¤Mß?õ×>¢PÉkãÓ'¨M?åÚ2¹Ók±Ñ2£Øz±Ð!¢Ußq±Ä6¿GzðÁ:¡G";
            Utils.Bruteforce(31, cypher);
            List<char> possibleChars = new List<char>();
            for (int j = 0; j < 255; j++)
            {

                if ((cypher[0] ^ j) > 92 && (cypher[0] ^ j) < 122)
                {
                    possibleChars.Add((char)j);
                }
            }
            for (int i = 31; i < cypher.Length; i = i + 31)
            {
                for (int j = 0; j < 255; j++)
                {

                    if ((cypher[i] ^ j) > 92 && (cypher[i] ^ j) < 122)
                    {
                        if (!possibleChars.Contains((char)j))
                            possibleChars.Remove((char)j);
                    }
                }
            }

            char[] key = new char[] { (char)186, (char)31, (char)145, (char)178, (char)83, (char)205, (char)62 };
            Console.WriteLine(Utils.Decrypt(new string(key), cypher));
        }

    }
}
