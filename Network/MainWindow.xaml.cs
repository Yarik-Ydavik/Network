using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Net;
using System.Windows.Threading;
using System.Net.NetworkInformation;

namespace Network
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        NetworkInterfaceInfo selectedInterfaceInfo;

        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 1) };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        public NetworkInterface[] nicArr;

        
        private void Timer_Tick(object sender, EventArgs e)
        {
            nicArr = NetworkInterface.GetAllNetworkInterfaces();
            for (int i = 0; i < nicArr.Length; i++)
                selectedInterfaceComboBox.Items.Add(nicArr[i].Name);

            /*            UpdateNetworkInterface();
            */
        }

        /*private void UpdateNetworkInterface()
        {
            if (selectedInterfaceComboBox.SelectedItem != null)
            {
                selectedInterfaceInfo = new NetworkInterfaceInfo((NetworkInterfaceType)selectedInterfaceComboBox.SelectedItem);
                selectedInterfaceInfo.UpdateData();
                interfaceInfoTextBlock.Text = selectedInterfaceInfo.ToString();
            }
           
        }

        private void selectedInterfaceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (selectedInterfaceComboBox.SelectedItem != null)
            {
                selectedInterfaceInfo = new NetworkInterfaceInfo((NetworkInterfaceType)selectedInterfaceComboBox.SelectedItem);
                selectedInterfaceInfo.UpdateData();
                interfaceInfoTextBlock.Text = selectedInterfaceInfo.ToString();
            }
        }
*/
    }
}
