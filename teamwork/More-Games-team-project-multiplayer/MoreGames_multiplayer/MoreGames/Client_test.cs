using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;

using System.Threading.Tasks;

namespace MoreGames
{
    internal class Client_test
    {

        public ClientWebSocket ws = new ClientWebSocket();
        private byte[] buf = new byte[1056];
        public Client_test()
        {
            Start();
        }

        async Task Start() {
            await ws.ConnectAsync(new Uri("ws://localhost:5210/ws"), CancellationToken.None);
        }

        async Task<string> ReceiveAsync()
        {

                var result = await ws.ReceiveAsync(buf, CancellationToken.None);
                return Encoding.ASCII.GetString(buf, 0, result.Count);

            //if (result.MessageType == WebSocketMessageType.Close)
            //{
            //    await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, null, CancellationToken.None);

            //    Console.WriteLine(result.CloseStatusDescription);
            //}
            //else
            //{
            //    Console.WriteLine();
            //}

        }

       public  async Task Send(string message)
        {
            byte[] data = Encoding.ASCII.GetBytes(message);
            await ws.SendAsync(data, WebSocketMessageType.Text,
            true, CancellationToken.None);

        }
    }

}
