using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MQTT_DataLogger.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MQTT_DataLogger.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementController : ControllerBase
    {
        public record gackName(string deviceName);


        private readonly MQTTDbContext _context;

        public MeasurementController(MQTTDbContext context)
        {
            this._context = context;
        }
        
        [HttpPost("Data")]
        public async Task<IActionResult> GetAllMeasurements([FromBody] gackName g)
        {
            var measurement = _context.Measurements.Where(m => m.DeviceName == g.deviceName);
            return Ok(measurement);
        }
    }
}
