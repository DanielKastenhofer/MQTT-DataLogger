using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTT_DataLogger.Data
{
    public class MQTTDbContextFactory : IDesignTimeDbContextFactory<MQTTDbContext>
    {
        public object ServerVersion { get; private set; }

        public MQTTDbContext CreateDbContext(string[]? args = null)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            string mySqlConnectionStr = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<MQTTDbContext>();
            optionsBuilder
                .UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);


            return new MQTTDbContext(optionsBuilder.Options);
        }
    }
}
