using System;
using System.Threading.Tasks;
using H.Socket.IO;


namespace SyncService.communication
{


    public class ChatMessage
    {
        public string Username { get; set; }
        public string Message { get; set; }
        public long NumUsers { get; set; }
    }

    
}
