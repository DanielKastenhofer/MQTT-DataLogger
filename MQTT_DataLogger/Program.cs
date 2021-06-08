using System;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MQTT_DataLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            MqttClient mqttClient = new MqttClient("broker.mqttdashboard.com");

            mqttClient.MqttMsgPublishReceived += client_recievedMessage;

            string clientID = Guid.NewGuid().ToString();

            mqttClient.Connect(clientID);

            Console.WriteLine("Subscriber: MachineData/");
            mqttClient.Subscribe(new string[] { "maxi/geck" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });

        }

        static void client_recievedMessage(object sender, MqttMsgPublishEventArgs e)
        {
            var message = System.Text.Encoding.Default.GetString(e.Message);
            Console.WriteLine("Message: " + message);
        }
    }
}
