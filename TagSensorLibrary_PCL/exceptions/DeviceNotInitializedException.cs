using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagSensorLibrary_PCL.Exceptions
{
    public class DeviceNotInitializedException : Exception
    {
        public DeviceNotInitializedException()
            : base()
        {

        }

        public DeviceNotInitializedException(string message)
            : base(message)
        {

        }

        public DeviceNotInitializedException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
