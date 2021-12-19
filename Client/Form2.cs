using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography; // для RSA алгоритма и хэша
using System.IO; // для работы с файлами
using System.Net;
using System.Net.Sockets; // для сокетов
using System.Windows.Forms;

namespace Client
{
    public partial class Form2 : Form
    {
        internal string login;

        // создали протокол общения с сервером
        internal Protocol protocol = new Protocol();
        // создаем элемент сетевого подключения
        internal Connection connection = new Connection();

        byte[] data; // массив байт, передаваемый в сокетах
        StringBuilder builder = new StringBuilder();
        int bytes;

        Hash hpassw;
        fGetSign newForm;

        byte[] blogin, bpassword;


        public Form2()
        {
            InitializeComponent();
            hpassw = new Hash();
            newForm = new fGetSign(this);
        }


        private void RegistrButton_Click(object sender, EventArgs e)
        {
            try
            {
                connection.sendToServer(protocol.commands.registrationRequest); // запрос на регистрацию
                // считываем логин и пароль
                login = LoginBox.Text;

                // хэшируем пароль
                hpassw.GetHash(PasswBox.Text);

                // передаем на сервер логин и хэш и ждем от сервера подтверждения регистрации
                
                connection.sendToServer(login);// отправляем логин
                string f = connection.getFromServer();
                connection.sendToServer(hpassw.output);// отправляем хэш пароля


                // получаем ответ сервера
                string answer = connection.getFromServer();

                // если сервер подтвердил регистрацию, пишем соответствующее сообщение и переходим на новую форму
                if (answer == protocol.feedback.feedbackRegistr)
                {
                    // переходим на основную форму
                    newForm.Show();
                    this.Hide(); // просто скрывает форму, но не закрывает ее
                }

                // если сервер не подтвердил регистрацию, пишем соответствующее сообщение
                if (answer == protocol.feedback.feedbackRegError)
                {
                    MessageBox.Show(protocol.feedback.feedbackRegError, protocol.commands.registrationRequest, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AuthorButton_Click(object sender, EventArgs e)
        {

            try 
            {
                // считываем логин и пароль
                login = LoginBox.Text;

                // хэшируем пароль
                hpassw.GetHash(PasswBox.Text);


                // передаем на сервер логин и хэш и ждем от сервера подтверждения авторизации
                connection.sendToServer(protocol.commands.authorizetionRequest); // запрос на авторизацию
                connection.sendToServer(login);// отправляем логин
                connection.sendToServer(hpassw.output);// отправляем хэш пароля

                // получаем ответ сервера
                string answer = connection.getFromServer();

                // если сервер подтвердил вход, пишем соответствующее сообщение и переходим на новую форму
                if(answer == protocol.feedback.feedbackAuthorized)
                {
                    // переходим на основную форму
                    newForm.Show();
                    this.Close(); // просто скрывает форму, но не закрывает ее
                }

                // если сервер не подтвердил вход, пишем соответствующее сообщение
                if (answer == protocol.feedback.feedbackAuthError)
                {
                    MessageBox.Show("Неверный логин или пароль, попробуйте еще раз", protocol.commands.authorizetionRequest, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            // отправить серверу запрос на отключение
            connection.sendToServer(protocol.commands.disconnectionRequest);
            connection.socket.Shutdown(SocketShutdown.Both);
            connection.socket.Close();
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
           // LoginBox.Clear();
           // PasswBox.Clear();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                LoginBox.Clear();
                PasswBox.Clear();
                // подключаемся к удаленному хосту
                connection.Connect();

                // отправляем запрос на подключение к серверу
                connection.sendToServer(protocol.commands.connectionRequest);

                // получаем ответ
                string answer = connection.getFromServer();
                if (answer == protocol.feedback.feedbackConnection)
                {
                    // выводим месседжбокс о том что все круто
                    MessageBox.Show(protocol.feedback.feedbackConnection, protocol.commands.connectionRequest, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, protocol.commands.connectionRequest, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
