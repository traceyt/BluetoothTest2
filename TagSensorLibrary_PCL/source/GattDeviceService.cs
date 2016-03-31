using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagSensorLibrary_PCL.interfaces;

namespace TagSensorLibrary_PCL
{
    public class GattDeviceService
    {
        private static IGattDeviceService _gattDeviceService;

        public GattDeviceService(IGattDeviceService gattDeviceService)
        {
            if (gattDeviceService == null) throw new ArgumentNullException(nameof(gattDeviceService));
            _gattDeviceService = gattDeviceService;
        }


        public static Devices FromIdAsync(string id) => _gattDeviceService.FromIdAsync(id);

        public static string GetDeviceSelectorFromUuid(Guid guid) => _gattDeviceService.GetDeviceSelectorFromUuid(guid);

    }
}
