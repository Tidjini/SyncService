using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocketIOSharp.Server;

namespace SyncServiceTest.server
{
    internal class DummyServer
    {
        private readonly SocketIOServer _server;
        public ushort Port { get; set; }
        public DummyServer(ushort port = 9001)
        {
            Port = port;
            _server = new SocketIOServer(new SocketIOServerOption(port));

        }

        public DummyServer(SocketIOServer server, ushort port)
        {
            Port = port;
            _server = server;
        }
    }
}
