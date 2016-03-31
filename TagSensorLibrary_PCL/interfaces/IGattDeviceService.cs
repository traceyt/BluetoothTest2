using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagSensorLibrary_PCL;

namespace TagSensorLibrary_PCL.interfaces
{
    public interface IGattDeviceService
    {
        string GetDeviceSelectorFromUuid(Guid guid);
        Devices FromIdAsync(string id);

        Task<List<Devices>> GetDevicesOfService(string serviceUuid);

    }
}
