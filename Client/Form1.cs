using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography; // для RSA алгоритма
using System.IO; // для работы с файлами
using System.Net;
using System.Net.Sockets; // для сокетов
using System.Windows.Forms;

namespace Client
{
    public partial class StartPage : Form
    {

        // создали протокол общения с сервером
        internal Protocol protocol = new Protocol();
        // создаем элемент сетевого подключения
        internal Connection connection = new Connection();
        
        byte[] data; // массив байт, передаваемый в сокетах
        StringBuilder builder = new StringBuilder();
        int bytes;

        public StartPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // подключаемся к удаленному хосту
                connection.Connect();
                
                // создаем запрос на подключение к серверу
                data = Encoding.Unicode.GetBytes(protocol.commands.connectionRequest);
                connection.socket.Send(data); // отправляем серверу

                // получаем ответ
                data = new byte[256]; // буфер для ответа
                bytes = 0; // количество полученных байт
                do
                {
                    bytes = connection.socket.Receive(data, data.Length, 0);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (connection.socket.Available > 0);

                
                if (builder.ToString() == protocol.feedback.feedbackConnection)
                {
                    // выводим месседжбокс о том что все круто
                    MessageBox.Show(protocol.feedback.feedbackConnection, protocol.commands.connectionRequest, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // открываем следующую форму
                    //Form2 newForm = new Form2(this);
                    //newForm.Show();
                    this.Hide(); // просто скрывает форму, но не закрывает ее
                }
                
            }
            catch (Exception ex)
            {
                // выводим месседжбокс об ошибке, содержащий ex.Message
                MessageBox.Show(ex.Message, protocol.commands.connectionRequest, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StartPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            // отправить запрос серверу на отключение от него
            connection.sendToServer(protocol.commands.disconnectionRequest);

            // закрыть главную форму
            Application.OpenForms[0].Close();
        }
    }
}


// главная форма: кнопка подключиться к серверу (если все подключились, вывести месседжбокс что все ок и открыть форму авторизации)
// если не ок, то вывести месседжбокс что все не ок и остаться на этой форме
// тут же подключиться к БД (или файловой системе)
//
// форма авторизации: текстбокс для логина, пароля (поколдовать так, чтобы он маскировался точками (и по возможности становился видимым))
// кнопка войти: выводит месседжбокс если строки логина и пароля пусты; если заполнены, хэширует пароль, и проверяет в базе данных совпадение по логину и хэшу
// если все ок, открываем основную форму
// если не ок, вывести месседжбокс что все не ок
// кнопка зарегистрироваться: записать в базу данных новый логин и значение хэша пароля (предварительно проверив, что логин уникален)
// вывести месседжбокс что мы успешно зарегались и открыть основную форму
//
// основная форма:

