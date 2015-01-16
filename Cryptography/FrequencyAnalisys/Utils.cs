using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FrequencyAnalisys
{
    public static class Utils
    {
        /// <summary>
        /// Given a cyphertext returns the key length based on frequency analysis
        /// </summary>
        /// <param name="cypher"></param>
        ///
        public static Dictionary<string, double> LetterFrequencies = new Dictionary<string, double>()
        {
            {"a",0.08167},{"b",0.01492},{"c",0.02782},{"d",0.04253},{"e",0.12702},
            {"f",0.02228},{"g",0.02015},{"h",0.06094},{"i",0.06966},{"j",0.00153},
            {"k",0.00772},{"l",0.04025},{"m",0.02406},{"n",0.06749},{"o",0.07507},
            {"p",0.01929},{"q",0.00095},{"r",0.05987},{"s",0.06327},{"t",0.09056},
            {"u",0.02758},{"v",0.00978},{"w",0.02360},{"x",0.00150},{"y",0.01974},
            {"z",0.00074}
        };


        public static int GetKeyLength(string cypher)
        {
            int maximumKeyLength = 13;
            int i = 2;
            double maxDistribution = 0.0;
            int keyLength = 0;
            List<double> distributions = new List<double>();
            for (; i <= maximumKeyLength; i++)
            {
                string substr = "";
                for (int k = 0; k < cypher.Length; k = k + i)
                {
                    substr += cypher[k];

                }
                for (int k = 0; k < substr.Length; k++)
                {
                    double occurance = substr.Count(f => f == substr[k]);
                    distributions.Add(Math.Pow((double)((double)occurance / (double)substr.Length), 2));
                }
                Console.WriteLine(distributions.Sum());
                if (distributions.Sum() > maxDistribution)
                {
                    maxDistribution = distributions.Sum();
                    keyLength = i;
                }
                distributions.Clear();
            }
            return keyLength;
        }

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
                        Debug.WriteLine((double)pt.Count(x => x == 'e') / (double)temp.Length);
                        Debug.WriteLine(k);
                    }

                }
            }

            return result;
        }

        public static string Decrypt(string key, string cypher)
        {
            while (key.Length < cypher.Length)
            {
                key += key;
            }
            string tmp = "";
            for (int i = 0; i < cypher.Length; i++)
            {
               
                tmp += (char)(cypher[i] ^ key[i]);
            }
            return tmp;
        }
    }
}
