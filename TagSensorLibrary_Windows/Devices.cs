using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagSensorLibrary_PCL;
using TagSensorLibrary_PCL.interfaces;
using Windows.Devices.Enumeration;

namespace TagSensorLibrary_Windows
{
    public class Devices : IDevices
    {

        public Windows.Devices.Bluetooth.GenericAttributeProfile.GattDeviceService deviceService;
        public List<Windows.Devices.Bluetooth.GenericAttributeProfile.GattDeviceService> deviceServices;
        private bool disposed;

        public Task<List<object>> FindAllAsync(string selector)
        {
            throw new NotImplementedException();
        }

        public TagSensorLibrary_PCL.Devices FindIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Devices FromIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<List<TagSensorLibrary_PCL.Devices>> IDevices.FindAllAsync(string selector)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Retrieves the sensor device and saves it for further usage.
        /// IMPORTANT: Has to be called from UI thread the first time the app uses the device to be able to ask the user for permission to use it
        /// </summary>
        /// <returns>Indicates if the gatt service could be retrieved and set successfully</returns>
        /// <exception cref="DeviceNotFoundException">Thrown if there isn't a device which matches the sensor service id.</exception>
        public async Task<bool> Initialize()
        {
            if (this.deviceServices != null)
            {
                Clean();
            }
            List<DeviceInformation> devicesInfo = await GetDevicesOfService(SensorTagUuid.UUID_INF_SERV);
            this.deviceServices = new List<Windows.Devices.Bluetooth.GenericAttributeProfile.GattDeviceService>();
            foreach (DeviceInformation deviceInfo in devicesInfo)
            {
                Windows.Devices.Bluetooth.GenericAttributeProfile.GattDeviceService _deviceService = await Windows.Devices.Bluetooth.GenericAttributeProfile.GattDeviceService.FromIdAsync(deviceInfo.Id);
                if (_deviceService != null) this.deviceServices.Add(_deviceService);
            }
            if (this.deviceServices == null)
                return false;
            return true;

        }

        /// <summary>
        /// Retrieves a list of devices which offer the service specified with the Uuid. In case of a sensor tag service (e.g. temperature),
        /// this lists all Sensor Tags.
        /// </summary>
        /// <param name="serviceUuid">Uuid for the type of service u're looking for.</param>
        /// <returns>List of DeviceInformation</returns>
        public static async Task<List<DeviceInformation>> GetDevicesOfService(string serviceUuid)
        {
            Validator.RequiresNotNullOrEmpty(serviceUuid);

            string selector = Windows.Devices.Bluetooth.GenericAttributeProfile.GattDeviceService.GetDeviceSelectorFromUuid(new Guid(serviceUuid));
            var devices = await DeviceInformation.FindAllAsync(selector);
            return devices.ToList<DeviceInformation>();
        }

        /// <summary>
        /// Should clean the objects resources. Disposes the deviceservice if it's not null and removes possible event handler.
        /// </summary>
        private void Clean()
        {
            if (deviceService != null)
                deviceService.Dispose();
            deviceService = null;
        }
    }
}
