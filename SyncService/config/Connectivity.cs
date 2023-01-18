using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SyncService.config
{
    public abstract class Connectivity : NetworkInterface
    {
        public static bool IsAvailable = GetIsNetworkAvailable();

        static void NetworkAvailablityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            Console.WriteLine("internet is available : {0}", e.IsAvailable);
            IsAvailable = e.IsAvailable;
        }

        public static void Build()
        {
            NetworkChange.NetworkAvailabilityChanged
                += new NetworkAvailabilityChangedEventHandler(NetworkAvailablityChanged);

            NetworkChange.NetworkAvailabilityChanged += OnNetworkAvailabilityChanged;


        }
        static void OnNetworkAvailabilityChanged(
               object sender, NetworkAvailabilityEventArgs networkAvailability) =>
               Console.WriteLine($"Network is available: {networkAvailability.IsAvailable}");

        public abstract void OnNetworkAvailable();
        public abstract void OnNotAvailbe();
    }


}
