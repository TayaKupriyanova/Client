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
        //StartPage sp;
        Form2 form2;
        string fileName;
        string signedfile;
        string pkey;

        DigitalSign digitalSign;
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

        private void fGetSign_Load(object sender, EventArgs e) // отобразили на форме логин пользователя
        {
            LoginBox.Text = form2.login;
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

            // переслать на сервер путь к файлу (или сам файл????)
            form2.connection.sendToServer(fileName);

            // получаем открытый ключ и зашифрованный файл с сервера
            pkey = form2.connection.getFromServer();
            form2.connection.sendToServer("Ключ получен");
            signedfile = form2.connection.getFromServer();

            // создаем объект
            digitalSign = new DigitalSign(pkey, signedfile, fileName);

            
            // вывести в месседж бокс сообщение о том что мы все подписали и мы молодцы
            MessageBox.Show("Файл подписан!", form2.protocol.commands.getSignRequest, MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void bCheckSign_Click(object sender, EventArgs e)
        {
            // проверка подписи на подлинность
            fileName = PathBox.Text; // считать из текст бокса имя файла

            // расшифровать открытым ключом закодированный файл
            digitalSign.getDecrypted();

            // сравнить файл из текстбокса и полученный
           // if(digitalSign.checkSign(fileName)) // если функция проверки подписи вернула true
           // {
           //     MessageBox.Show("True", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           // }
           // else
           // {
           //     MessageBox.Show("False", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           // }
        }

        private void ViewSign_Click(object sender, EventArgs e)
        {
            //Открыть полученный из ЦП файл
            // переписать его в текстбокс
            using (StreamReader sr = new StreamReader(digitalSign.signedFileName, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Signtb.Text += line;
                }
            }
        }

        private void GetPublicKey_Click(object sender, EventArgs e)
        {
            // вывести в текстбокс значение открытого ключа
            Signtb.Text += "Значение ключа: " + Environment.NewLine + digitalSign.publickey; //Convert.ToBase64String(digitalSign.publickey);
        }

        private void fGetSign_FormClosing(object sender, FormClosingEventArgs e)
        {
            // добавить запрос на logout
           
            Application.OpenForms[0].Show();

            /*// отправить запрос серверу на отключение от него
            sp.connection.sendToServer(sp.protocol.commands.disconnectionRequest);

            // закрыть главную форму
            Application.OpenForms[0].Close();*/

        }
    }
}
