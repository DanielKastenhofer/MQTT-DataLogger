using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace MQTT_DataLogger.Data
{
    class MQTTContext : DbContext
    {
        public MQTTContext(DbContextOptions<MQTTContext> options)
            : base(options)
        {
        }

        public DbSet<Device> Devices => Set<Device>();

        public DbSet<Measurement> Measurements => Set<Measurement>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Add a unique index to name identifier column
            
        }

    }
}
