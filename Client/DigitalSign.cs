using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // для работы с файлами
using System.Security.Cryptography; // для RSA алгоритма

namespace Client
{
    internal class DigitalSign
    {
        public string msgFileName;  // имя подписанного файла
        public string publickey;    // значение открытого ключа
        public string signedFile;   // имя подписанного файла
        public string sign;         // тест подписанного файла, так как клиент не имеет доступа к облаку
        RSACryptoServiceProvider provider = new RSACryptoServiceProvider(); // создали объект шифровальщикa
        byte[] decryptedData;
        public int sizeSign;
        public bool check; // результат проверки

        public DigitalSign() { }
        public DigitalSign(string pkey, string s, string m, string ssign, int size)
        {
            publickey = pkey;
            signedFile = s;
            msgFileName = m;
            sign = ssign;
            sizeSign = size;
        }

        public void getDecrypted() // не факт что войд
        {
            try {
                string result = "";
                using (StreamReader sr = new StreamReader(msgFileName, System.Text.Encoding.Default))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        result += line;
                    }
                    sr.Close();
                }

                byte[] message = Convert.FromBase64String(result);
                byte[] data;
                data = Convert.FromBase64String(sign);
                provider.FromXmlString(publickey);

                // bool success = false;
                // SHA512Managed Hash = new SHA512Managed();
                // byte[] hashedData = Hash.ComputeHash(sign);
                // success = provider.VerifyData(bytesToVerify/**/, CryptoConfig.MapNameToOID("SHA512"), signedBytes);


                //provider.
                check = provider.VerifyData(message, new SHA256CryptoServiceProvider(), data); //HashAlgorithmName.SHA1, decryptedData);

                //builder.Append(Encoding.Unicode.GetString(decryptedData)).ToString();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void checkSign(string filename)
        {
            //считать файл который надо было подписать
            byte[] msg;
            string result = "";
            using (StreamReader sr = new StreamReader(filename, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    result += line;
                }
                sr.Close();
            }
            msg= Encoding.Unicode.GetBytes(result);

            // сравнить содержимое файлов 
            
        }

        private static byte[] GetModulus(byte[] pDer)
        {
            //Size header is 29 bits
            //The key size modulus is 128 bits, but in hexa string the size is 2 digits => 256 
            string lModulus = BitConverter.ToString(pDer).Replace("-", "").Substring(58, 256);

            return StringHexToByteArray(lModulus);
        }

        private static byte[] GetExponent(byte[] pDer)
        {
            int lExponentLenght = pDer[pDer.Length - 3];
            string lExponent = BitConverter.ToString(pDer).Replace("-", "").Substring((pDer.Length * 2) - lExponentLenght * 2, lExponentLenght * 2);

            return StringHexToByteArray(lExponent);
        }

        public static byte[] StringHexToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        private static RSAParameters GetRSAParameters(string pPublicKey)
        {
            //Set RSAKeyInfo to the public key values. 
            int lBeginStart = "-----BEGIN PUBLIC KEY-----".Length;
            int lEndLength = "-----END PUBLIC KEY-----".Length;
            string KeyString = pPublicKey.Substring(lBeginStart, (pPublicKey.Length - lBeginStart - lEndLength));
            string tobase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(KeyString));
            byte[] lDer = new byte[256];
            lDer = Convert.FromBase64String(tobase64); 
            //byte[] lDer = new byte[pPublicKey.Length - lBeginStart - lEndLength];
            //for(int i =0; i<pPublicKey.Length - lEndLength - lBeginStart; i++)
            //{
            //    lDer[i] = pPublicKey[i  + lBeginStart];
            //}

            //Create a new instance of the RSAParameters structure.
            RSAParameters lRSAKeyInfo = new RSAParameters();

            lRSAKeyInfo.Modulus = GetModulus(lDer);
            lRSAKeyInfo.Exponent = GetExponent(lDer);

            return lRSAKeyInfo;
        }
    }
}
