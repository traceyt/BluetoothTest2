using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagSensorLibrary_PCL.interfaces
{
    public interface IDevices
    {
        Task<List<Devices>> FindAllAsync(string selector);


        Task<bool> Initialize();

    }
}
