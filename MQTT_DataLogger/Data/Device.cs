using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTT_DataLogger.Data
{
    class Device
    {
        public int ID { get; set; }

        public Temperature Temp { get; set; }

        public Usage Usage { get; set; }
    }
}
