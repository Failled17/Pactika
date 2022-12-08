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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Pactika.MyPages;
using Pactika.Соmponens;

namespace Pactika.MyPages
{
    /// <summary>
    /// Логика взаимодействия для AutoPage.xaml
    /// </summary>
    public partial class AutoPage : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        public AutoPage()
        {
            InitializeComponent();
            if (Properties.Settings.Default.login != null)
                LoginTb.Text = Properties.Settings.Default.login;
            if (Properties.Settings.Default.password != null)
                Password.Password = Properties.Settings.Default.password;
        }
        

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            RegiPage taskWindow = new RegiPage();
            taskWindow.Show();
            Close();
           
        }

        private void EntranceBtn_Click(object sender, RoutedEventArgs e)
        {
            int countAuto = Properties.Settings.Default.CountAuth;
            
            string login = LoginTb.Text.Trim();
            string password = Password.Password.Trim();
            
            if (countAuto < 3)
            {
                if (LoginTb.Text != null || Password.Password != null)
                {
                    var User = Connection.db.User.ToList().Find(x => x.login == login && x.password == password);
                        if (User != null)
                            {
                                     if (RememberCh.IsChecked == true)
                                            {
                                                Properties.Settings.Default.login = LoginTb.Text;
                                                Properties.Settings.Default.password = Password.Password;
                                                Properties.Settings.Default.Save();
                                            }
                                     else
                                            {
                                                Properties.Settings.Default.login = null;
                                                Properties.Settings.Default.password = null;
                                                Properties.Settings.Default.Save();
                                            }
                                     MainWindow Pr = new MainWindow();
                                     Pr.Show();
                                     Close();
                                     countAuto = 0;
                               }
                        else
                                {
                                    countAuto += 1;
                                    Properties.Settings.Default.CountAuth = countAuto;
                                    MessageBox.Show("Такого пользователя нет", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                                }
                }
                else
                {
                    MessageBox.Show("Не заполнены поля", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                }
            }
            else
            {
                MessageBox.Show("Вы ввели 3 раза неправильный пароль\nВход заблокировани на 1 минуту", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                countAuto = 0;
                EntranceBtn.IsEnabled = false;
                RegisterBtn.IsEnabled = false;
                timer.Interval = new TimeSpan(0, 1, 0);
                timer.Tick += new EventHandler(isVisibleBTN);
                timer.Start();
            }


        }
        private void isVisibleBTN(object sender, EventArgs e)
        {
            EntranceBtn.IsEnabled = true;
            RegisterBtn.IsEnabled = true;
            timer.Stop();
        }
    }

}

