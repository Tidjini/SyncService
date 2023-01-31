using System;
using Newtonsoft.Json.Linq;
using SocketIOSharp.Server;
using SocketIOSharp.Server.Client;

namespace SyncServiceTest.server
{

    static class ServerEvent
    {
        public static readonly string CONNECTION = "connection";
        public static readonly string DISCONNECT = "disconnect";
        public static readonly string ERROR = "error";
        public static readonly string INPUT = "input";
    }


    internal class Logger
    {
        public static void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
    internal class DummyServer
    {
        private const ushort DEFAULT_PROT = 9001;
        private readonly SocketIOServer _server;
        public ushort Port { get; set; }



        public DummyServer(ushort port = DEFAULT_PROT)
        {

            Logger.Log($"============= DUMMY SERVER INTIALISATION : {port} =============");
            Port = port;
            _server = new SocketIOServer(new SocketIOServerOption(port));

        }

        public DummyServer(SocketIOServer server, ushort port = DEFAULT_PROT)
        {

            Logger.Log($"============= DUMMY SERVER : {port} =============");
            Port = port;
            _server = server;
        }

        public void Start()
        {
            Logger.Log("Started");
            _server.Start();
            Logger.Log("Start listening to incomming connections...");
            OnConnection();
        }

        public void Stop()
        {
            Logger.Log("Stopped");
            _server.Dispose();
            _server.Stop();
        }





        public void OnConnection()
        {
            _server.OnConnection((SocketIOSocket socket) =>
            {
                Logger.Log("Client Connected...");
                socket.On(ServerEvent.INPUT, (JToken[] Data) =>
                {

                    foreach (JToken token in Data)
                    {

                    }

                    Console.WriteLine();

                    socket.Emit("echo", Data);
                });


                socket.On(ServerEvent.DISCONNECT, () =>
                {
                    Logger.Log("Client Disconnected");

                });


            });
        }




    }
}
