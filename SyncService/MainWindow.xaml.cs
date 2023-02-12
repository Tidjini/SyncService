using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using SocketIOClient;
using SyncService.models;

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
            test();

        }
        void OnNetworkAvailabilityChanged(
              object sender, NetworkAvailabilityEventArgs networkAvailability) =>
              Console.WriteLine($"Network is available: {networkAvailability.IsAvailable}");


        SocketIO client;

        public async void test()
        {
            Console.WriteLine($"-----------------SOCKET-------------------");

           
            try
            {


                client = new SocketIO("http://localhost:19019/");
                //SocketIoClient socket = new SocketIoClient();
                Console.WriteLine($"-----------------INIT-------------------");

                client.OnConnected += async (sender, e) =>
                {
                    //Console.WriteLine($"-----------------ON CONNECTED-------------------");

                    //// Emit a string
                    //await client.EmitAsync("hi", "socket.io");
                    //Console.WriteLine($"-----------------client.EmitAsync-------------------");

                    //await ((SocketIO)sender).EmitAsync("hi", "socket.io");
                    //Console.WriteLine($"-----------------sender.EmitAsync-------------------");


                    // Emit a string and an object
                  
                };
                await client.ConnectAsync();




            }
            catch(Exception e)
            {
                Console.WriteLine($"-----------------END SOCKET-------------------" + e.Message);
            }
            
        }


      

        private async void OnClickRequest(object sender, RoutedEventArgs e)
        {
            if(client != null)
            {
                Console.WriteLine("Button_Click : {0}", "send sample");
                await client.EmitAsync("request", new Product());

            }

        }

        private async void OnClickResponse(object sender, RoutedEventArgs e)
        {
            if (client != null)
            {
                Console.WriteLine("Button_Click : {0}", "send sample");
                await client.EmitAsync("response", new Product());

            }

        }
    }

}
