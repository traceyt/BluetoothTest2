using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagSensorLibrary_PCL.interfaces;

namespace TagSensorLibrary_PCL
{
    public class Devices
    {
        private static IDevices _devices;

        public Devices(IDevices devices)
        {
            if (devices == null) throw new ArgumentNullException(nameof(devices));
            _devices = devices;
        }
        public Task<bool> Initialize() => _devices.Initialize();
        public static Task<List<Devices>> FindAllAsync(string selector) => _devices.FindAllAsync(selector);


    }
}
