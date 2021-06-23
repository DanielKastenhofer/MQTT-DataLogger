using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTT_DataLogger.Data
{
    public class Measurement
    {
        public int ID { get; set; }

        public String DeviceName { get; set; }


        public double CPUUsage { get; set; }

        public double CPUTemp { get; set; }

        public double GPUUsage { get; set; }

        public double GPUTemp { get; set; }

        public double RAMUsage { get; set; }

        public DateTime TimeStamp { get; set; }

    }
}
