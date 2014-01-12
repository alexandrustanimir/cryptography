using System;
using CryptoUtil;

namespace Cryto
{
    class Program
    {
        static void Main(string[] args)
        {
            string value = "attack at dawn";
            string cypher = "6c73d5240a948c86981bc294814d";
            Console.WriteLine(CryptoUtil.CryptoUtil.StringToHex(value));

           string key = CryptoUtil.CryptoUtil.XOROtp(CryptoUtil.CryptoUtil.StringToHex(value), cypher);
           string result = (CryptoUtil.CryptoUtil.XOROtp(CryptoUtil.CryptoUtil.StringToHex("attack at dust"), @key));
           Console.WriteLine(result);

        }
    }
}
