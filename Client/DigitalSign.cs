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
        public string msgFileName;
        public string publickey;
        public string signedFileName;
        RSACryptoServiceProvider provider = new RSACryptoServiceProvider(); // создали объект шифровальщикa
        byte[] decryptedData;

        public DigitalSign(string p, string s, string m)
        {
            publickey = p;
            signedFileName = s;
            msgFileName = m;
        }

        public void getDecrypted() // не факт что войд
        {
            try { 
            byte[] data;
            StringBuilder builder = new StringBuilder();

            // прочитать файл signedFileName
            string result = "";
            using (StreamReader sr = new StreamReader(signedFileName, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    result += line;
                }
                sr.Close();
            }
            data = Encoding.Unicode.GetBytes(result);

                //преобразовать byte[] в RSAParametrs для использования открытого ключа

                var prov = new RSACryptoServiceProvider();

                byte[] keyBlobBytes = Convert.FromBase64String(publickey);
                prov.ImportCspBlob(keyBlobBytes);
                var parameters = prov.ExportParameters(false);


                provider.ImportParameters(parameters); // установили закрытый ключ 

            decryptedData = provider.Decrypt(data, false);

            builder.Append(Encoding.Unicode.GetString(decryptedData)).ToString();
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

        private static RSAParameters GetRSAParameters(byte[] pPublicKey)
        {
            //Set RSAKeyInfo to the public key values. 
            int lBeginStart = "-----BEGIN PUBLIC KEY-----".Length;
            int lEndLength = "-----END PUBLIC KEY-----".Length;
            //string KeyString = pPublicKey.Substring(lBeginStart, (pPublicKey.Length - lBeginStart - lEndLenght));
            //lDer = pPublicKey.//= Convert.FromBase64String(KeyString);
            byte[] lDer = new byte[pPublicKey.Length - lBeginStart - lEndLength];
            for(int i =0; i<pPublicKey.Length - lEndLength - lBeginStart; i++)
            {
                lDer[i] = pPublicKey[i  + lBeginStart];
            }

            //Create a new instance of the RSAParameters structure.
            RSAParameters lRSAKeyInfo = new RSAParameters();

            lRSAKeyInfo.Modulus = GetModulus(lDer);
            lRSAKeyInfo.Exponent = GetExponent(lDer);

            return lRSAKeyInfo;
        }
    }
}
