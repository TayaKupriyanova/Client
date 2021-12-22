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
        public string sign;         // текст подписанного файла, так как клиент не имеет доступа к облаку
        RSACryptoServiceProvider provider = new RSACryptoServiceProvider(); // создали объект шифровальщикa
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

                byte[] message = Encoding.Unicode.GetBytes(result);
                byte[] data;
                data = Convert.FromBase64String(sign);
                provider.FromXmlString(publickey);
                check = provider.VerifyData(message, new SHA256CryptoServiceProvider(), data);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
