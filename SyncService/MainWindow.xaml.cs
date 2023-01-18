using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SyncService.config;

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
            
        }
        void OnNetworkAvailabilityChanged(
              object sender, NetworkAvailabilityEventArgs networkAvailability) =>
              Console.WriteLine($"Network is available: {networkAvailability.IsAvailable}");
    }
}
