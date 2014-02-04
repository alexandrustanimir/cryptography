using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Globalization;


namespace Cryto
{
    class Program
    {
        static void Main(string[] args)
        {
            // ProgrammingWeek1();
            ProgrammingWeek2();
            return;
            string value = "attack at dawn";
            string cypher = "6c73d5240a948c86981bc294814d";
            Console.WriteLine(CryptoUtil.CryptoUtil.StringToHex(value));

            string key = CryptoUtil.CryptoUtil.XOROtp(CryptoUtil.CryptoUtil.StringToHex(value), cypher);
            string result = (CryptoUtil.CryptoUtil.XOROtp(CryptoUtil.CryptoUtil.StringToHex("attack at dust"), @key));
            Console.WriteLine(result);

        }

        static void ProgrammingWeek1()
        {
            List<string> items = new List<string>()
            {
               "315c4eeaa8b5f8aaf9174145bf43e1784b8fa00dc71d885a804e5ee9fa40b16349c146fb778cdf2d3aff021dfff5b403b510d0d0455468aeb98622b137dae857553ccd8883a7bc37520e06e515d22c954eba5025b8cc57ee59418ce7dc6bc41556bdb36bbca3e8774301fbcaa3b83b220809560987815f65286764703de0f3d524400a19b159610b11ef3e","234c02ecbbfbafa3ed18510abd11fa724fcda2018a1a8342cf064bbde548b12b07df44ba7191d9606ef4081ffde5ad46a5069d9f7f543bedb9c861bf29c7e205132eda9382b0bc2c5c4b45f919cf3a9f1cb74151f6d551f4480c82b2cb24cc5b028aa76eb7b4ab24171ab3cdadb8356f","32510ba9a7b2bba9b8005d43a304b5714cc0bb0c8a34884dd91304b8ad40b62b07df44ba6e9d8a2368e51d04e0e7b207b70b9b8261112bacb6c866a232dfe257527dc29398f5f3251a0d47e503c66e935de81230b59b7afb5f41afa8d661cb","32510ba9aab2a8a4fd06414fb517b5605cc0aa0dc91a8908c2064ba8ad5ea06a029056f47a8ad3306ef5021eafe1ac01a81197847a5c68a1b78769a37bc8f4575432c198ccb4ef63590256e305cd3a9544ee4160ead45aef520489e7da7d835402bca670bda8eb775200b8dabbba246b130f040d8ec6447e2c767f3d30ed81ea2e4c1404e1315a1010e7229be6636aaa","3f561ba9adb4b6ebec54424ba317b564418fac0dd35f8c08d31a1fe9e24fe56808c213f17c81d9607cee021dafe1e001b21ade877a5e68bea88d61b93ac5ee0d562e8e9582f5ef375f0a4ae20ed86e935de81230b59b73fb4302cd95d770c65b40aaa065f2a5e33a5a0bb5dcaba43722130f042f8ec85b7c2070","32510bfbacfbb9befd54415da243e1695ecabd58c519cd4bd2061bbde24eb76a19d84aba34d8de287be84d07e7e9a30ee714979c7e1123a8bd9822a33ecaf512472e8e8f8db3f9635c1949e640c621854eba0d79eccf52ff111284b4cc61d11902aebc66f2b2e436434eacc0aba938220b084800c2ca4e693522643573b2c4ce35050b0cf774201f0fe52ac9f26d71b6cf61a711cc229f77ace7aa88a2f19983122b11be87a59c355d25f8e4","32510bfbacfbb9befd54415da243e1695ecabd58c519cd4bd90f1fa6ea5ba47b01c909ba7696cf606ef40c04afe1ac0aa8148dd066592ded9f8774b529c7ea125d298e8883f5e9305f4b44f915cb2bd05af51373fd9b4af511039fa2d96f83414aaaf261bda2e97b170fb5cce2a53e675c154c0d9681596934777e2275b381ce2e40582afe67650b13e72287ff2270abcf73bb028932836fbdecfecee0a3b894473c1bbeb6b4913a536ce4f9b13f1efff71ea313c8661dd9a4ce","315c4eeaa8b5f8bffd11155ea506b56041c6a00c8a08854dd21a4bbde54ce56801d943ba708b8a3574f40c00fff9e00fa1439fd0654327a3bfc860b92f89ee04132ecb9298f5fd2d5e4b45e40ecc3b9d59e9417df7c95bba410e9aa2ca24c5474da2f276baa3ac325918b2daada43d6712150441c2e04f6565517f317da9d3","271946f9bbb2aeadec111841a81abc300ecaa01bd8069d5cc91005e9fe4aad6e04d513e96d99de2569bc5e50eeeca709b50a8a987f4264edb6896fb537d0a716132ddc938fb0f836480e06ed0fcd6e9759f40462f9cf57f4564186a2c1778f1543efa270bda5e933421cbe88a4a52222190f471e9bd15f652b653b7071aec59a2705081ffe72651d08f822c9ed6d76e48b63ab15d0208573a7eef027","466d06ece998b7a2fb1d464fed2ced7641ddaa3cc31c9941cf110abbf409ed39598005b3399ccfafb61d0315fca0a314be138a9f32503bedac8067f03adbf3575c3b8edc9ba7f537530541ab0f9f3cd04ff50d66f1d559ba520e89a2cb2a83"
            };
            string result = CryptoUtil.CryptoUtil.HexToBinary(items[0]);
            List<string> xoreditems = new List<string>();
            for (int i = 1; i < items.Count; i++)
            {
                result = CryptoUtil.CryptoUtil.XOROtp(result, CryptoUtil.CryptoUtil.HexToBinary(items[i]));
                xoreditems.Add(result);
            }
            StringBuilder sb = new StringBuilder("");
            while (result.Length > 0)
            {
                sb.Append(CryptoUtil.CryptoUtil.BinaryToAscii(result.Substring(0, 8)));
                result = result.Substring(8);
            }
            Console.WriteLine(sb.ToString())
    ;
        }


        static void ProgrammingWeek2()
        {
            ProgrammingWeek2Q1();
            Console.WriteLine("----");
            ProgrammingWeek2Q2();
            Console.WriteLine("----");
            ProgrammingWeek2Q3();
            Console.WriteLine("----");
            ProgrammingWeek2Q4();
        }

        static void ProgrammingWeek2Q1()
        {

            StringBuilder sb = new StringBuilder("");
            List<string> values = new List<string>(){
            "28a226d160dad07883d04e008a7897ee",
            "2e4b7465d5290d0c0e6c6822236e1daa",
            "fb94ffe0c5da05d9476be028ad7c1d81"};

            byte[] mergedArray = new byte[48];

            var toDecrypt = DecryptBlockCBC(values[0], "140b41b22a29beb4061bda66b6747e14");
            Console.Write(Encoding.ASCII.GetString(XorBytes(toDecrypt, ConvertHexStringToByteArray("4ca00ff4c898d61e1edbf1800618fb28"))));
            for(int i = 1;i < values.Count;i++)
            {
                toDecrypt = DecryptBlockCBC(values[i], "140b41b22a29beb4061bda66b6747e14");
                toDecrypt = XorBytes(ConvertHexStringToByteArray(values[i-1]), toDecrypt);
                Console.Write(Encoding.ASCII.GetString(toDecrypt));
            }

            
        }
        static void ProgrammingWeek2Q2()
        {

            StringBuilder sb = new StringBuilder("");
            List<string> values = new List<string>(){
            "b4832d0f26e1ab7da33249de7d4afc48",
            "e713ac646ace36e872ad5fb8a512428a",
            "6e21364b0c374df45503473c5242a253"};

            byte[] mergedArray = new byte[48];

            var toDecrypt = DecryptBlockCBC(values[0], "140b41b22a29beb4061bda66b6747e14");
            Console.Write(Encoding.UTF8.GetString(XorBytes(toDecrypt, ConvertHexStringToByteArray("5b68629feb8606f9a6667670b75b38a5"))));
            for (int i = 1; i < values.Count; i++)
            {
                toDecrypt = DecryptBlockCBC(values[i], "140b41b22a29beb4061bda66b6747e14");
                toDecrypt = XorBytes(ConvertHexStringToByteArray(values[i - 1]), toDecrypt);
                Console.Write(Encoding.UTF8.GetString(toDecrypt));
            }
        }

        static void ProgrammingWeek2Q3()
        {
            string key = "36f18357be4dbd77f050515c73fcf9f2";
            string cyphertext = "69dda8455c7dd4254bf353b773304eec0ec7702330098ce7f7520d1cbbb20fc388d1b0adb5054dbd7370849dbf0b88d393f252e764f1f5f7ad97ef79d59ce29f5";
            string IV = "69dda8455c7dd4254bf353b773304eec";
            List<string> blocks = new List<string>() { "0ec7702330098ce7f7520d1cbbb20fc3", "88d1b0adb5054dbd7370849dbf0b88d3", "93f252e764f1f5f7ad97ef79d59ce29f", "5f51eeca32eabedd9afa9329" };
            for(int i = 0 ; i < blocks.Count;i++)
            { 
            var toDecrypt = EncryptBlock(ConvertHexStringToByteArray(IV), ConvertHexStringToByteArray(key));
            string ivplus = (int.Parse(IV.Substring(30), System.Globalization.NumberStyles.HexNumber) + 1).ToString("X");
            IV = IV.Substring(0, 30) + ivplus;
            Console.Write(Encoding.UTF8.GetString(XorBytes(toDecrypt,ConvertHexStringToByteArray( blocks[i]))));
            }

        }


        static void ProgrammingWeek2Q4()
        {
            string key = "36f18357be4dbd77f050515c73fcf9f2";
            string cyphertext = "770b80259ec33beb2561358a9f2dc617e46218c0a53cbeca695ae45faa8952aa0e311bde9d4e01726d3184c34451";
            string IV = "770b80259ec33beb2561358a9f2dc617";
            List<string> blocks = new List<string>() { "e46218c0a53cbeca695ae45faa8952aa", "0e311bde9d4e01726d3184c34451"};
            for (int i = 0; i < blocks.Count; i++)
            {
                var toDecrypt = EncryptBlock(ConvertHexStringToByteArray(IV), ConvertHexStringToByteArray(key));
                string ivplus = (int.Parse(IV.Substring(30), System.Globalization.NumberStyles.HexNumber) + 1).ToString("X");
                IV = IV.Substring(0, 30) + ivplus;
                Console.Write(Encoding.UTF8.GetString(XorBytes(toDecrypt, ConvertHexStringToByteArray(blocks[i]))));
            }

        }
        private static byte[] DecryptBlockCBC(string cypherHex, string key)
        {
            byte[] cypher = ConvertHexStringToByteArray(cypherHex);
            Rijndael aes = Rijndael.Create();
            aes.Key = ConvertHexStringToByteArray(key);
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.None;

            MemoryStream ms = new MemoryStream(cypher);
            CryptoStream decryptedStream = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
            byte[] plainbytes = new byte[aes.BlockSize / 8];
            decryptedStream.Read(plainbytes, 0, aes.BlockSize / 8);
            return plainbytes;
        }
        private static byte[] DecryptBlockCTR(string cypherHex, string key,byte[] IV)
        {
            byte[] cypher = ConvertHexStringToByteArray(cypherHex);
            Rijndael aes = Rijndael.Create();
            aes.Key = ConvertHexStringToByteArray(key);
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.None;
            aes.IV = IV;

            MemoryStream ms = new MemoryStream(cypher);
            CryptoStream decryptedStream = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
            byte[] plainbytes = new byte[aes.BlockSize / 8];
            decryptedStream.Read(plainbytes, 0, aes.BlockSize / 8);
            return plainbytes;
        }

        private static byte[] EncryptBlock(byte[] IV,byte[] key)
        {
            Rijndael aes = Rijndael.Create();
            aes.Key = key;
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.None;

            MemoryStream ms = new MemoryStream(IV);
            CryptoStream decryptedStream = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Read);
            byte[] plainbytes = new byte[aes.BlockSize / 8];
            decryptedStream.Read(plainbytes, 0, aes.BlockSize / 8);
            return plainbytes;
        }

        public static byte[] ConvertHexStringToByteArray(string hexString)
        {
            if (hexString.Length % 2 != 0)
            {
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString));
            }

            byte[] HexAsBytes = new byte[hexString.Length / 2];
            for (int index = 0; index < HexAsBytes.Length; index++)
            {
                string byteValue = hexString.Substring(index * 2, 2);
                HexAsBytes[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            return HexAsBytes;
        }

        public static Byte[] XorBytes(Byte[] firstBytes, Byte[] secondBytes)
        {

            int maxLength = Math.Min(firstBytes.Length, secondBytes.Length);

            var result = new byte[maxLength];

            for (int i = 0; i < maxLength; i++)

                result[i] = (Byte)(firstBytes[i] ^ secondBytes[i]);

            return result;

        }

        

    }
}
