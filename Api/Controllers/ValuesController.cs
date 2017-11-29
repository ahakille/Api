using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators.Internal;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ISensorService _sensorService;

        public ValuesController(ISensorService sensorService)
        {
            _sensorService = sensorService;
        }

        // GET api/values/sensors
        [HttpGet("sensors")]
        public async Task<IActionResult> GetAllSensors()
        {
            var sensors = await _sensorService.GetAllSensors();

            if (sensors != null)
            {
                return Ok(sensors);
            }

            return BadRequest("Unable to get sensors, they have probably taken over your house by now....");
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSensor(int id)
        {
            var sensor = await _sensorService.GetSensor(id);
            if (sensor != null)
            {
                return Ok(sensor);
            }

            return BadRequest("Unable to get sensors, they have probably taken over your house by now....");
        }
        [HttpGet("sensor/{id}")]
        public async Task<IActionResult> GetMeasurementsForSensor(int id)
        {
            var sensor = await _sensorService.GetMeasurementsForSensor(id);
            if (sensor != null)
            {
                return Ok(sensor);
            }

            return BadRequest("Unable to get sensors, they have probably taken over your house by now....");
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromQuery] int sensorId, string sensorData)
        {
            var sensor = await _sensorService.SetMeasure(sensorId,sensorData,DateTime.Now);
            if (sensor != null)
            {
                return Ok(sensor);
            }

            return BadRequest("Unable to get sensors, they have probably taken over your house by now....");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
