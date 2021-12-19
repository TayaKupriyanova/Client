using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Client
{
    internal class Hash
    {
        // хэшированное сообщение
        public string output;
        public Hash()
        { }

        //метод, принимающий строку, хеширующий ее с помощью алгоритма MD5 и записывающий результат в поле объекта
        public void GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            output = Convert.ToBase64String(hash);
        }
    }
}
