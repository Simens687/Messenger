using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ПУПУПУУУУУ
{
    public class TcpServercs
    {
        private Socket socket;
        private List<Socket> clients = new List<Socket>();

        

        public void Initialize(ListBox Messages, CancellationToken token)
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Any, 8888);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(ipPoint);
            socket.Listen(30);

            Listen_to_clients(Messages, token);
        }

        private async Task Listen_to_clients(ListBox Messages, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                var client = await socket.AcceptAsync();
                clients.Add(client);
                Recieve_message(client, Messages, token);
            }
        }

        private async Task Recieve_message(Socket client, ListBox Messages, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                byte[] bytes = new byte[1024];
                await client.ReceiveAsync(bytes, SocketFlags.None);
                string message = Encoding.UTF8.GetString(bytes);
                Messages.Items.Add(message);

                foreach (var item in clients)
                {
                    Send_message(item, message);
                }
            }
        }

        private async Task Send_message(Socket client, string message)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(message);
            await client.SendAsync(bytes, SocketFlags.None);
        }
    }
}
