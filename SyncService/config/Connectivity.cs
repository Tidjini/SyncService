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

        void NetworkAvailablityChanged(object sender, NetworkAvailabilityEventArgs e)
        {

        }

        public void Build()
        {
            NetworkChange.NetworkAvailabilityChanged
                += new NetworkAvailabilityChangedEventHandler(NetworkAvailablityChanged);
        }




        public abstract void OnNetworkAvailable();
        public abstract void OnNotAvailbe();
    }
}
