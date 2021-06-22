using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTT_DataLogger.Data
{
    public class MQTTDbContext : DbContext
    {
        public MQTTDbContext(DbContextOptions<MQTTDbContext> options)
            : base(options)
        {
        }

        public DbSet<Measurement> Measurements { get; set; }

    }
}
