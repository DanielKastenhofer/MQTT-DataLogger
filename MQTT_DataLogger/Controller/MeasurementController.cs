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

        private readonly MQTTDbContext _context;

        public MeasurementController(MQTTDbContext context)
        {
            this._context = context;
        }
        
        [HttpGet("Data")]
        public async Task<IActionResult> GetAllMeasurements()
        {
            var measurements = _context.Measurements;

            return Ok(measurements);
        }

    }
}
