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
    public class GattDeviceService : IGattDeviceService
    {
        public TagSensorLibrary_PCL.Devices FromIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public string GetDeviceSelectorFromUuid(Guid guid)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Retrieves a list of devices which offer the service specified with the Uuid. In case of a sensor tag service (e.g. temperature),
        /// this lists all Sensor Tags.
        /// </summary>
        /// <param name="serviceUuid">Uuid for the type of service u're looking for.</param>
        /// <returns>List of DeviceInformation</returns>
        public async Task<List<DeviceInformation>> GetDevicesOfService(string serviceUuid)
        {
            Validator.RequiresNotNullOrEmpty(serviceUuid);

            string selector = Windows.Devices.Bluetooth.GenericAttributeProfile.GattDeviceService.GetDeviceSelectorFromUuid(new Guid(serviceUuid));
            var devices = await DeviceInformation.FindAllAsync(selector);
            return devices.ToList<DeviceInformation>();
        }

        Task<List<TagSensorLibrary_PCL.Devices>> IGattDeviceService.GetDevicesOfService(string serviceUuid)
        {
            throw new NotImplementedException();
        }
    }
}
