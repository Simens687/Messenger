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

namespace ПУПУПУУУУУ
{
    public partial class MainWindow : Window
    {
        Polz polz = new Polz();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Create_new_chat(object sender, RoutedEventArgs e)
        {
            try
            {
                polz.Name = name_txt.Text;
                Other.Name = polz.Name;

                New_chat new_chat = new New_chat();
                new_chat.Show();
                Application.Current.MainWindow.Close();
            }
            catch 
            {
                MessageBox.Show("Поле 'Введите имя' не должно быть пустым и в него можно вбивать только буквы, цифры и '_'");
            }
        }

        private void Connect_chat(object sender, RoutedEventArgs e)
        {
            bool one = false, two = false;
            try
            {
                polz.Name = name_txt.Text;
                Other.Name = polz.Name;
                one = true;
            }
            catch
            {
                MessageBox.Show("Поле 'Введите имя' не должно быть пустым и в него можно вбивать только буквы, цифры и '_'");
            }

            try
            {
                polz.IP = IP_txt.Text;
                Other.IP = polz.IP;
                two = true;
            }
            catch
            {
                MessageBox.Show("Нарушен формат IP-адреса");
            }

            if (one == true && two == true)
            {
                Old_chat old_chat = new Old_chat();
                old_chat.Show();
                Application.Current.MainWindow.Close();
            }
        }
    }
}
