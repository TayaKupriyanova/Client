using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Security.Cryptography; // для RSA алгоритма
using System.IO; // для работы с файлами
using System.Net;
using System.Net.Sockets; // для сокетов


namespace Client
{
    internal class Connection
    {
        // адрес и порт сервера, к которому будем подключаться
        public static int port = 1111; // порт сервера
        public static string address = "127.0.0.1"; // адрес сервера

        public IPEndPoint ipPoint;
        public Socket socket;

        public Connection()
        {
            ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); ;
        }

        public void Connect()
        {
            socket.Connect(ipPoint);
        }

        public string getFromServer()
        {
            StringBuilder builder = new StringBuilder();
            byte[] data = new byte[256]; // буфер для ответаf
            int bytes = 0; // количество полученных байт
            do
            {
                bytes = socket.Receive(data, data.Length, 0);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (socket.Available > 0);
            return builder.ToString();
        }

        public void sendToServer(string msg)
        {
            byte[] data;
            data = Encoding.Unicode.GetBytes(msg);
            socket.Send(data);
        }

        public byte [] getKeyFromServer()
        {
           // StringBuilder builder = new StringBuilder();
            byte[] data = new byte[256]; // буфер для ответа
            int bytes = 0; // количество полученных байт
            do
            {
                bytes = socket.Receive(data, data.Length, 0);
               // builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (socket.Available > 0);
            return data;

        }
    }
}
