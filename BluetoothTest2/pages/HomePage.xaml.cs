using System;
using System.Threading.Tasks;
using TagSensorLibrary_PCL;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BluetoothTest2.pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {

        public HomePage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await startTracking();
            }
            catch (Exception ex)
            {
                //ex.Message;
            }
        }

        private async Task startTracking()
        {
            // get the list of devices to track
            TagSensorLibrary_Windows.Devices s = new TagSensorLibrary_Windows.Devices();
            TagSensorLibrary_PCL.Devices c = new TagSensorLibrary_PCL.Devices(s);

            await c.Initialize();

            //foreach (GattDeviceService deviceService in deviceInfoService.deviceServices)
            //{
            //    TagReaderService tagReader = new TagReaderService();
            //    await tagReader.InitializeSensor();
            //    SensorInformation.Text += await tagReader.GetSensorID(deviceService);
            //    if (tagReader != null)
            //        this.tagReaders.Add(tagReader);
            //}


            //eventHubService = new EventHubService(app.ServiceBusNamespace,
            //app.EventHubName, app.SharedAccessPolicyName, app.SharedAccessPolicyKey);

            ////StatusField.Text = "The sensor is connected";
            //txtError.Text = "";
            //eventHubWriterTimer.Start();
            //StartCommand.Content = "Stop";
            //StartCommand.Tag = "STARTED";


            //numberOfFailedCallsToEventHub = numberOfCallsDoneToEventHub = 0;
            //EventHubInformation.Text = $"Calls: {numberOfCallsDoneToEventHub}, Failed Calls: {numberOfFailedCallsToEventHub}";
        }

        private void StartCommand_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SimulateCommand_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EnableRemote_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DisableRemote_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OnSettingsChanged(object sender, RoutedEventArgs e)
        {

        }
    }

}
