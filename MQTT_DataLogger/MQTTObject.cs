using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using MQTT_DataLogger.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MQTT_DataLogger
{
    public class MQTTObject
    {

        private readonly MQTTDbContext _context;

        public MQTTObject(MQTTDbContext context)
        {
            this._context = context;
        }


        public void Initialize()
        {
            Console.WriteLine("Start up");
            Console.WriteLine("========");
            Console.Write("Broker IP: exilehub.net");
            //string brokerIP = Console.ReadLine();
            string brokerIP = "exilehub.net";

            MqttClient mqttClient = new MqttClient(brokerIP);


            string clientID = Guid.NewGuid().ToString();

            
            mqttClient.Connect(clientID);

            mqttClient.MqttMsgPublishReceived += client_recievedMessage;

            Console.WriteLine("Topic: device/#");
            mqttClient.Subscribe(new string[] { "device/#" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });

        }

       
        private async void client_recievedMessage(object sender, MqttMsgPublishEventArgs e)
        {
            await Task.Factory.StartNew(async () =>
            {
                Console.WriteLine("Niger != nice");


                string valueType = null;

                string deviceName = e.Topic.Split('/')[1];
                string component = e.Topic.Split('/')[2];

                if (e.Topic.Split('/').Length > 3)
                {
                    valueType = e.Topic.Split('/')[3];
                }

                var message = Convert.ToDouble(Encoding.Default.GetString(e.Message), System.Globalization.CultureInfo.InvariantCulture);

                Console.WriteLine("Message: " + message);

                var measurement = await _context.Measurements.FirstOrDefaultAsync(m => m.DeviceName == deviceName);

                if (measurement == null)
                {
                    measurement = new()
                    {
                        DeviceName = deviceName,
                        TimeStamp = DateTime.Now
                    };

                    measurement = await setValuesAsync(measurement, component, valueType, message);
                    await _context.AddAsync(measurement);
                    await _context.SaveChangesAsync();

                }

                else
                {
                    measurement = await setValuesAsync(measurement, component, valueType, message);
                    await _context.SaveChangesAsync();
                }
            });
            
        }

        public async Task<Measurement> setValuesAsync(Measurement measurement, string component, string valueType, double message)
        {
            if (component == "cpu")
            {
                switch (valueType)
                {
                    case "load":
                        measurement.CPUUsage = message;
                        break;
                    case "temp":
                        measurement.CPUTemp = message;
                        break;

                    default:
                        break;
                }
            }
            else if (component == "gpu")
            {
                switch (valueType)
                {
                    case "load":
                        measurement.GPUUsage = message;
                        break;
                    case "temp":
                        measurement.GPUTemp = message;
                        break;

                    default:
                        break;
                }
            }
            else
            {
                measurement.RAMUsage = message;
            }



            return measurement; 
        }
    }
}
