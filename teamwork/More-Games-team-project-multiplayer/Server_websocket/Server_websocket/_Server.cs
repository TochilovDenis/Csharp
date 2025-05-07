using System.Collections.Concurrent;
using System.Linq;
using System.Net.WebSockets;
using System.Text;

namespace Server_websocket
{
    public class _Server
    {
        private ConcurrentDictionary<string, WebSocket> clients;
        private ConcurrentDictionary<string, ConcurrentDictionary<string, WebSocket>> room_ =new ConcurrentDictionary<string, ConcurrentDictionary<string, WebSocket>>();
        public _Server(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();


            app.UseWebSockets();

            clients = new ConcurrentDictionary<string, WebSocket>();

            app.Map("/ws", async context =>
            {
                if (context.WebSockets.IsWebSocketRequest)
                {
                    var webSocket = await context.WebSockets.AcceptWebSocketAsync();
                    var clientId = Guid.NewGuid().ToString();
                    clients.TryAdd(clientId, webSocket);

                    Console.WriteLine($"Client connected: {clientId}");

                    await ReceiveMessages(webSocket, clientId);
                }
            });
            app.Run();
        }

        public _Server()
        {
            var builder = WebApplication.CreateBuilder();
            var app = builder.Build();


            app.UseWebSockets();

            clients = new ConcurrentDictionary<string, WebSocket>();

            app.Map("/ws", async context =>
            {
                if (context.WebSockets.IsWebSocketRequest)
                {
                    var webSocket = await context.WebSockets.AcceptWebSocketAsync();
                    var clientId = Guid.NewGuid().ToString();
                    clients.TryAdd(clientId, webSocket);

                    Console.WriteLine($"Client connected: {clientId}");
                 
                    await ReceiveMessages(webSocket, clientId);
                }
            });

            app.Run();
           
        }

        // Dictionary to track connected clients


        async Task ReceiveMessages(WebSocket webSocket, string clientId)
        {
            var buffer = new byte[1024 * 4];

            try
            {
                while (webSocket.State == WebSocketState.Open)
                {
                    var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, null, CancellationToken.None);
                        break;
                    }

                    string message_m = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    string[] message = message_m.Split(";");
                    /* message [] 
                     * 0-комманда
                     * 1-название комнаты
                     * 2..-дальнейшие команды
                     * */


                    if (message[0].IndexOf("cr_r") == 0)
                    {
                        try
                        {
                            Console.WriteLine($"Create room: {message[1]}");
                            room_.TryAdd(message[1], new ConcurrentDictionary<string, WebSocket>());

                            await MessageClient(webSocket, "cr_r;200");
                        }
                        catch (Exception ex) { await MessageClient(webSocket, $"connct;400;{ex.Message}"); }
                    }
                    if (message[0].IndexOf("connct") == 0)
                    {
                        try
                        {
                            room_[message[1]].TryAdd(clientId, webSocket);
                            await MessageClient(webSocket, "connct;200");
                            Console.WriteLine($"Connect room: {message[1]}");
                        }
                        catch (Exception ex) { await MessageClient(webSocket, $"connct;400;{ex.Message}"); }
                    }
                    if (message[0].IndexOf("cmd") == 0 || message[0].IndexOf("sms") == 0)
                    {
                        try
                        {
                            room_[message[1]].TryAdd(clientId, webSocket);
                            await MessageRoom(room_[message[1]], message_m);
                            Console.WriteLine($"cmd/sms: {message[1]}");
                        }
                        catch (Exception ex) { await MessageClient(webSocket, $"cmd;400;{ex.Message}"); }
                    }
                    if (message[0].IndexOf("all_") == 0 )
                    {
                        try
                        {
                            room_[message[1]].TryAdd(clientId, webSocket);
                            await BroadcastMessage(message_m);
                            Console.WriteLine($"all_: {message[1]}");
                        }
                        catch (Exception ex) { await MessageClient(webSocket, $"cmd;400;{ex.Message}"); }
                    }

                }
            }
            finally
            {
                clients.TryRemove(clientId, out _);
                Console.WriteLine($"Client disconnected: {clientId}");
            }
        }
        async Task MessageClient(WebSocket client, string message)
        {
            var bytes = Encoding.UTF8.GetBytes(message);

            if (client.State == WebSocketState.Open)
            {
                await client.SendAsync(
                    new ArraySegment<byte>(bytes),
                    WebSocketMessageType.Text,
                    true,
                    CancellationToken.None);
            }

        }
        async Task MessageRoom(ConcurrentDictionary<string, WebSocket> rooms__, string message)
        {
            var bytes = Encoding.UTF8.GetBytes(message);

            foreach (var client in rooms__)
            {
                if (client.Value.State == WebSocketState.Open)
                {
                    await client.Value.SendAsync(
                        new ArraySegment<byte>(bytes),
                        WebSocketMessageType.Text,
                        true,
                        CancellationToken.None);
                }
            }
        }

        async Task BroadcastMessage(string message)
        {
            var bytes = Encoding.UTF8.GetBytes(message);
            foreach (var client in clients)
            {
                if (client.Value.State == WebSocketState.Open)
                {
                    await client.Value.SendAsync(
                        new ArraySegment<byte>(bytes),
                        WebSocketMessageType.Text,
                        true,
                        CancellationToken.None);
                }
            }
        }

    }
}
