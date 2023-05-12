using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ПУПУПУУУУУ
{
    public class TcpClients
    {
        private Socket server;

        public void Initialize(string IP, ListBox Messages, CancellationToken token)
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.ConnectAsync(IP, 8888);

            Recieve_message(Messages, token);
        }

        private async Task Recieve_message(ListBox Messages, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                byte[] bytes = new byte[1024];
                await server.ReceiveAsync(bytes, SocketFlags.None);
                string message = Encoding.UTF8.GetString(bytes);
                Messages.Items.Add(message);
            }
        }

        public async Task Send_message(string IP, string message)
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.ConnectAsync(IP, 8888);

            byte[] bytes = Encoding.UTF8.GetBytes(DateTime.Now + " " + Other.Name + " " + message);
            await server.SendAsync(bytes, SocketFlags.None);

        }
    }
}
