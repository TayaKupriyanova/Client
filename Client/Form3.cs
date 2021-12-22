using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // для работы с файлами
using System.Windows.Forms;

namespace Client
{
    public partial class fGetSign : Form
    {
        Form2 form2;
        string fileName;

        DigitalSign digitalSign  = new DigitalSign();
        OpenFileDialog open_dialog;

        public fGetSign()
        {
            InitializeComponent();
        }

        public fGetSign(Form2 f)
        {
            InitializeComponent();
            form2 = f;
        }

        private void fGetSign_Load(object sender, EventArgs e) 
        {
            // отобразили на форме логин пользователя
            LoginBox.Text = form2.login;

            // загрузили все подписанные файлы в комбобокс
            // отправить запрос серверу
            form2.connection.sendToServer(form2.protocol.commands.getFilesRequest);
            // приняли ответ с сервера
            string answer = form2.connection.getFromServer();

            // получать в цикле файлы и отправлять ответ о получении
            string buffer;
            while ((buffer = form2.connection.getFromServer()) != "Последний файл") //пока есть что принимать
            {
                cbFiles.Items.Add(buffer); // записываем в комбобокс (имя файла)
                form2.connection.sendToServer("файл принят");
            }
        }

        private void bLogOut_Click(object sender, EventArgs e)
        {
            form2.connection.sendToServer(form2.protocol.commands.logOutRequest);  // передать серверу команду стереть информацию о пользователе

            // принять ответ от сервера
            string answer = form2.connection.getFromServer();

            form2.login = "";// затереть инфу о логине с предыдущей формы
            Application.OpenForms[1].Show();// открыть предыдущую форму
            this.Close();// скрываем форму
        }

        private void LoadFile_Click(object sender, EventArgs e)
        {
            // открыть диалоговое окно с выбором файла
            open_dialog = new OpenFileDialog(); //создание диалогового окна для выбора файла
            open_dialog.Filter = "Text files | *.txt"; // формат загружаемого файла МОЖЕТ ПОМЕНЯТЬ ЕСЛИ ПОЛУЧИТСЯ
            open_dialog.Multiselect = false; // можно выбрать только один файл
            if (open_dialog.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                try
                {
                    fileName = open_dialog.FileName; // задаем путь к файлу
                    PathBox.Text = fileName;
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e) // кнопка подписи файла
        {
            fileName = PathBox.Text; // считали путь файла
            // послали запрос на подпись
            form2.connection.sendToServer(form2.protocol.commands.getSignRequest);

            // приняли ответ с сервера
            string answer = form2.connection.getFromServer();

            // переслать на сервер путь к файлу
            form2.connection.sendToServer(fileName);

            // получаем зашифрованный файл и его имя с сервера? его размер и открытый ключ
            string sign = form2.connection.getFromServer();
            form2.connection.sendToServer("Текст получен");
            string signedfileName = form2.connection.getFromServer();
            form2.connection.sendToServer("Файл получен");
            int size = Convert.ToInt32(form2.connection.getFromServer());
            form2.connection.sendToServer("Размер получен");
            string pkey = form2.connection.getFromServer();

            // создаем объект
            digitalSign = new DigitalSign(pkey, signedfileName, fileName, sign, size);

            // добавить файл в комбобокс
           
            if (!cbFiles.Items.Contains(signedfileName))
                cbFiles.Items.Add(signedfileName); // если такого еще не было, то добавить

            cbFiles.SelectedItem = signedfileName;

            // вывести в месседж бокс сообщение о том что мы все подписали и мы молодцы
            MessageBox.Show("Файл подписан!", form2.protocol.commands.getSignRequest, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void bCheckSign_Click(object sender, EventArgs e)
        {
            // проверка подписи на подлинность
            //fileName = PathBox.Text; // считать из текст бокса имя файла

            // расшифровать открытым ключом закодированный файл
            digitalSign.getDecrypted();
            MessageBox.Show(digitalSign.check.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           // }
           // else
           // {
           //     MessageBox.Show("False", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           // }
        }

        private void ViewSign_Click(object sender, EventArgs e)
        {
            //запрос на получение текста файла, выбранного в комбобоксе
            form2.connection.sendToServer(form2.protocol.commands.getTextRequest);
            string f = form2.connection.getFromServer(); // получили ответ
            form2.connection.sendToServer(cbFiles.SelectedItem.ToString()); // отправили имя файла
            f = form2.connection.getFromServer(); // получили текст
            Signtb.Text += f;// переписать его в текстбокс
        }

        private void GetPublicKey_Click(object sender, EventArgs e)
        {
            //получить с сервера значение открытого ключа
            form2.connection.sendToServer(form2.protocol.commands.getkeyRequest);

            // приняли ответ с сервера
            string key = form2.connection.getFromServer();
            digitalSign.publickey = key;

            // вывести в текстбокс значение открытого ключа
            Signtb.Text += Environment.NewLine + "Значение ключа: " + Environment.NewLine + digitalSign.publickey;
        }

        private void fGetSign_FormClosing(object sender, FormClosingEventArgs e)
        {
            // добавить запрос на logout
           
            Application.OpenForms[0].Show();
        }

        private void ClearB_Click(object sender, EventArgs e)
        {
            Signtb.Clear();
        }
    }
}
