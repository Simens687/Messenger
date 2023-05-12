using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ПУПУПУУУУУ
{
   
    public partial class New_chat : Window
    {
        private CancellationTokenSource isWorking;
        public New_chat()
        {
            InitializeComponent();

            TcpServercs tcpServercs = new TcpServercs();
            isWorking = new CancellationTokenSource();

            tcpServercs.Initialize(Messages, isWorking.Token);

        }

        private void Send(object sender, RoutedEventArgs e)
        {
            if (Mes.Text == @"\disconnect")
            {
                For_exit();
            }
            else
            {
                TcpClients tcpClients = new TcpClients();

                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress localIP = host.AddressList.FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);


                tcpClients.Send_message(localIP.ToString(), Mes.Text);
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            For_exit();
        }

        private void For_exit()
        {
            isWorking.Cancel();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            isWorking.Cancel();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void Logi(object sender, RoutedEventArgs e)
        {
            Logs.Content = new Logis();
        }
    }
}
