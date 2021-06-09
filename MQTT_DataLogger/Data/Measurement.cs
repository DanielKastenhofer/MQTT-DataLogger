using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTT_DataLogger.Data
{
    class Measurement
    {
        public int ID { get; set; }

        public double Value { get; set; }

        public DateTime TimeStamp { get; set; }

        public Device Device { get; set; }

    }
}
