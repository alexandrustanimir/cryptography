using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA2
{
    class Program
    {
        public static List<string> Bruteforce(int keyLength, string cypher)
        {
            List<string> result = new List<string>();
            string temp = "";
            {
                for (int i = 5; i < cypher.Length; i = i + keyLength)
                {
                    temp += cypher[i];
                }
                for (int k = 0; k < 256; k++)
                {
                    if (temp.All(x => (x ^ k) >= 32 && (x ^ k) <= 122) == true)
                    {
                        result.Add(k.ToString());
                        string pt = "";
                        for (int i = 0; i < temp.Length; i++)
                        {
                            pt += (char)(temp[i] ^ k);
                        }
                        //Debug.WriteLine((double)pt.Count(x => x == 'e') / (double)temp.Length);
                        //Debug.WriteLine(k);
                    }

                }
            }

            return result;
        }
        static void Main(string[] args)
        {
            List<string> cyphers = new List<string>()
            {
                CryptoUtil.CryptoUtil.HexToString("BB3A65F6F0034FA957F6A767699CE7FABA855AFB4F2B520AEAD612944A801E"),
                CryptoUtil.CryptoUtil.HexToString("BA7F24F2A35357A05CB8A16762C5A6AAAC924AE6447F0608A3D11388569A1E"),
                CryptoUtil.CryptoUtil.HexToString("A67261BBB30651BA5CF6BA297ED0E7B4E9894AA95E300247F0C0028F409A1E"),
                CryptoUtil.CryptoUtil.HexToString("A57261F5F0004BA74CF4AA2979D9A6B7AC854DA95E305203EC8515954C9D0F"),
                CryptoUtil.CryptoUtil.HexToString("BB3A70F3B91D48E84DF0AB702ECFEEB5BC8C5DA94C301E0BECD241954C831E"),
                CryptoUtil.CryptoUtil.HexToString("A6726DE8F01A50E849EDBC6C7C9CF2B2A88E19FD423E0647ECCB04DD4C9D1E"),
                CryptoUtil.CryptoUtil.HexToString("BC7570BBBF1D46E85AF9AA6C7A9CEFA9E9825CFD5E3A0047F7CD009305A71E")
            };
            string key = "";
            for (int j = 0; j < 31; j++)
            {
                for (int l = 0; l < 31; l++)
                    for (int k = 0; k < 256; k++)
                    {
                        bool ok = true;
                        for (int i = 0; i < cyphers.Count; i++)
                        {
                            if ((cyphers[i][l] ^ k) < 97 || (cyphers[i][l] ^ k) > 122)
                            {
                                ok = false;
                            }
                        }
                        if (ok == true)
                        {
                            key += (char)k;
                            break;
                        }
                    }
            }
            foreach (var item in cyphers)
            {
                Console.WriteLine(CryptoUtil.CryptoUtil.XOROtp(item, key));
            }
        }
    }
}
