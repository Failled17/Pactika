using Pactika.Соmponens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pactika.MyPages
{
    /// <summary>
    /// Логика взаимодействия для RegiPage.xaml
    /// </summary>
    public partial class RegiPage : Window
    {
        public RegiPage()
        {
            InitializeComponent();
        }

        private void RegFormBtn_Click(object sender, RoutedEventArgs e)
        {

            string login = LoginTb.Text.Trim();
            string pass = Password.Password;
            string pass_2 = Password_1.Password;
            string Phnum = PhNum.Text;
            string FName = FirstName.Text.Trim();
            string LName = LastName.Text.Trim();
            //string patr = Patronymic.Text.Trim();
            string mail = Mail.Text.Trim();

            var check = Connection.db.User.Where(x => x.login == login).FirstOrDefault();
            if (check == null)
            {
                if (login.Length > 0 && pass.Length > 0 && pass_2.Length > 0)
                {

                    if (Connection.db.User.Local.Any(x => x.login == login))
                    {
                        MessageBox.Show("Такой пользователль уже существует ");
                        return;
                    }
                    else
                    {

                        Connection.db.User.Add(new User
                        {
                            login = login,
                            password = pass,
                            LastName = LName,
                            FirstName = FName,
                            //Patronymic = patr
                        });

                        if (pass.Length >= 6)
                        {
                            bool symbo = false;
                            bool number = true;
                            for (int i = 0; i < pass.Length; i++)
                            {
                                if (pass[i] >= '0' && pass[i] <= '9')
                                    number = true;
                                if (pass[i] == '_' || pass[i] == '-' || pass[i] == '!')
                                    symbo = true;
                            }
                            if (symbo != true || number != true)
                            {
                                MessageBox.Show("Добавьте один из символов _ - !");
                            }
                            if (number != true)
                            {
                                MessageBox.Show("Добавьте хотя бы 1 цифру ");
                            }
                        }

                        else
                        {
                            MessageBox.Show("Пароль должен быть больше 6 символов ");
                        }
                        if (pass != pass_2)
                        {
                            MessageBox.Show("Пароли не совпадают ");

                        }
                        if (mail.Contains("@") && mail.Contains("."))
                        {
                            MessageBox.Show("Адресс должен содержать @ и.");
                        }
                        if (login.Length < 1)
                        {
                            MessageBox.Show("Введите логин");
                        }
                        else
                        {

                        }
                        if (Phnum.Length != 11)
                        {
                            MessageBox.Show("Введите номер из 11 цифр ");
                        }
                        else
                        {

                        }
                        if (FName.Length < 1)
                        {
                            MessageBox.Show("Введите Фамилию");

                        }
                        else
                        {

                        }
                        if (LName.Length < 1)
                        {
                            MessageBox.Show("Введите имя");
                        }
                        else
                        {

                        }
                        //MessageBox.Show("Заполните поля");
                        //Connection.db.SaveChanges();


                    }
                
                MessageBox.Show("Пользователь сохранен");
            }
}

            else
            {
                MessageBox.Show("Такой логмин уже существует");
            }

        }
    }
}