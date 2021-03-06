﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ISensorService _sensorService;
        private readonly IConfiguration _iconfiguration;

        public ValuesController(ISensorService sensorService, IConfiguration iconfiguration)
        {
            _sensorService = sensorService;
            _iconfiguration = iconfiguration;
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
        [HttpGet("sensor/time/{id}")]
        public async Task<IActionResult> GetMeasurementsForSensorTime(int id, DateTime? startTime , DateTime? endTime)
        {
            
            if(!startTime.HasValue)
            {
                startTime = DateTime.Now.AddDays(-1);
            }
            if(!endTime.HasValue)
            {
                endTime = DateTime.Now;
            }
            var sensor = await _sensorService.GetMeasurementsWithTimeAndId(startTime,endTime,id);
            if (sensor != null)
            {
                return Ok(sensor);
            }

            return BadRequest("Unable to get sensors, they have probably taken over your house by now....");
        }

        // POST api/values
        [HttpGet("post")]
        public async Task<IActionResult> Post([FromQuery] string key, int sensorId, string sensorData)
        {
            if (key != _iconfiguration["SecureKey"])
            {
                return Unauthorized();
            }

            var sensor = await _sensorService.SetMeasure(sensorId, sensorData, DateTime.Now);

            if (sensor > 0)
            {
                return Ok();
            }

            return BadRequest("Unable to update, try more to the left... ");
        }

    }
}
