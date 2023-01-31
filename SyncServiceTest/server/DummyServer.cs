using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

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
        private const int DEFAULT_PROT = 9089;
        private const int BACKLOG = 10;

        private readonly Socket _server;
        public int Port { get; set; }
        public bool IsRunning
        {
            get; set;
        }

        public int Connections { get; set; }


        public DummyServer(int port = DEFAULT_PROT)
        {            

            _server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Port = port;
            Logger.Log($"============= DUMMY SERVER INTIALISATION : {port} =============");

        }



        public DummyServer(Socket server, ushort port = DEFAULT_PROT)
        {

            Logger.Log($"============= DUMMY SERVER : {port} =============");
            Port = port;
            _server = server;
        }

        public void Start(int backlog = BACKLOG)
        {

            try
            {

                IPHostEntry host = Dns.GetHostEntry("localhost");
                IPAddress ipAddress = host.AddressList[0];
                IPEndPoint localEndPoint = new IPEndPoint(ipAddress, Port);
                _server.Bind(localEndPoint);
                _server.Listen(backlog);
                Logger.Log("Started with success");
                IsRunning = true;       
                
                OnConnection();

            }
            catch(Exception)
            {
                Logger.Log("Start Exception");
                IsRunning = false;
            }

        }

        public void Stop()
        {
            Logger.Log("Shutdown and Close");
            _server.Shutdown(SocketShutdown.Both);
            _server.Close();
            Connections = 0;
            IsRunning = false;
        }





        public void OnConnection()
        {


            Socket handler = _server.Accept();

            // Incoming data from the client.
            string data = null;
            byte[] bytes = null;

            while (true)
            {
                bytes = new byte[1024];
                int bytesRec = handler.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                if (data.IndexOf("<EOF>") > -1)
                {
                    break;
                }
            }
        }




    }
}
