using System;
using System.Net.NetworkInformation;
using System.Windows;
using H.Socket.IO;
using Quobject.SocketIoClientDotNet.Client;


namespace SyncService
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Console.WriteLine("Enter Main Window");
            NetworkChange.NetworkAvailabilityChanged += OnNetworkAvailabilityChanged;
            //communication.Service.OnConnect();
            test();
            //ConnectToChatNowShTest().Start();

        }
        void OnNetworkAvailabilityChanged(
              object sender, NetworkAvailabilityEventArgs networkAvailability) =>
              Console.WriteLine($"Network is available: {networkAvailability.IsAvailable}");




        public void test()
        {
            Console.WriteLine($"-----------------SOCKET-------------------");
            SocketIoClient socket = new SocketIoClient();
           
            socket.On(Socket.EVENT_CONNECT, () =>
            {
                Console.WriteLine($"Network is available: True");
                socket.Emit("hi");
            });

            socket.On("hi", (data) =>
            {
                Console.WriteLine(data);
                //socket.Disconnect();
            });
            Console.WriteLine($"-----------------END SOCKET-------------------");
        }
        //public async Task ConnectToChatNowShTest()
        //{
        //    SocketIoClient client = new SocketIoClient();

        //    client.Connected += (sender, args) => Console.WriteLine($"Connected: {args.Namespace}");
        //    client.Disconnected += (sender, args) => Console.WriteLine($"Disconnected. Reason: {args.Reason}, Status: {args.Status:G}");
        //    client.EventReceived += (sender, args) => Console.WriteLine($"EventReceived: Namespace: {args.Namespace}, Value: {args.Value}, IsHandled: {args.IsHandled}");
        //    client.HandledEventReceived += (sender, args) => Console.WriteLine($"HandledEventReceived: Namespace: {args.Namespace}, Value: {args.Value}");
        //    client.UnhandledEventReceived += (sender, args) => Console.WriteLine($"UnhandledEventReceived: Namespace: {args.Namespace}, Value: {args.Value}");
        //    client.ErrorReceived += (sender, args) => Console.WriteLine($"ErrorReceived: Namespace: {args.Namespace}, Value: {args.Value}");
        //    client.ExceptionOccurred += (sender, args) => Console.WriteLine($"ExceptionOccurred: {args}");

        //    client.On("login", () =>
        //    {
        //        Console.WriteLine("You are logged in.");
        //    });
        //    client.On("login", json =>
        //    {
        //        Console.WriteLine($"You are logged in. Json: \"{json}\"");
        //    });
        //    client.On<ChatMessage>("login", message =>
        //    {
        //        Console.WriteLine($"You are logged in. Total number of users: {message.NumUsers}");
        //    });
        //    client.On<ChatMessage>("user joined", message =>
        //    {
        //        Console.WriteLine($"User joined: {message.Username}. Total number of users: {message.NumUsers}");
        //    });
        //    client.On<ChatMessage>("user left", message =>
        //    {
        //        Console.WriteLine($"User left: {message.Username}. Total number of users: {message.NumUsers}");
        //    });
        //    client.On<ChatMessage>("typing", message =>
        //    {
        //        Console.WriteLine($"User typing: {message.Username}");
        //    });
        //    client.On<ChatMessage>("stop typing", message =>
        //    {
        //        Console.WriteLine($"User stop typing: {message.Username}");
        //    });
        //    client.On<ChatMessage>("new message", message =>
        //    {
        //        Console.WriteLine($"New message from user \"{message.Username}\": {message.Message}");
        //    });

        //    await client.ConnectAsync(new Uri("ws://localhost:19019/"));

        //    await client.Emit("add user", "C# H.Socket.IO Test User");

        //    await Task.Delay(TimeSpan.FromMilliseconds(200));

        //    await client.Emit("typing");

        //    await Task.Delay(TimeSpan.FromMilliseconds(200));

        //    await client.Emit("new message", "hello");

        //    await Task.Delay(TimeSpan.FromMilliseconds(200));

        //    await client.Emit("stop typing");

        //    await Task.Delay(TimeSpan.FromSeconds(2));

        //    await client.DisconnectAsync();
        //}
        //}
    }

}
