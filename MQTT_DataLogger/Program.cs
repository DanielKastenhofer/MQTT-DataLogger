using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using MQTT_DataLogger.Data;
using System;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;

namespace MQTT_DataLogger
{

    class Program
    {   


        static void Main(string[] args)
        {


            var host = CreateHostBuilder(args).Build();


            using var scope = host.Services.CreateScope();
            using var dc = scope.ServiceProvider.GetRequiredService<MQTTDbContext>();

            Console.WriteLine("Instantiate mqtt");
            MQTTObject mqtt = new(dc);
            mqtt.Initialize();

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        static async void client_recievedMessage(object sender, MqttMsgPublishEventArgs e)
        {
            String deviceName = e.Topic.Split('/')[1];

            var message = Convert.ToDouble(Encoding.Default.GetString(e.Message));

            Console.WriteLine("Message: " + message);

            Measurement measurement = new()
            {
                DeviceName = deviceName,
                CPUTemp = message
            };

        }
    }
}
