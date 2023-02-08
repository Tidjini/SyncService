using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocketIOClient;
using SyncService.models;

namespace SyncService.communication
{
    public static class Service
    {
        public static SocketIO socket
        {
            get; set;
        }


        public static async void OnConnect(string url = "http://localhost:19019/")
        {
            socket = new SocketIO(url, new SocketIOOptions
            {
                Query = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("token", "abc123"),
                    new KeyValuePair<string, string>("key", "value")
                }
            });

            
            socket.OnConnected += async (sender, e) =>
            {
                Console.WriteLine("Connected");
                // Emit a string
                await socket.EmitAsync("hi", "socket.io");
                Console.WriteLine("hi socket.io");
                // Emit a string and an object
                var product = new Product();
                await socket.EmitAsync("procom-request", "source", product);
                Console.WriteLine("hi procom.io");
            };
            await socket.ConnectAsync();
        }
    }
}
