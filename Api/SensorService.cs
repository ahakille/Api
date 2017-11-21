using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api
{
    public class SensorService : ISensorService
    {
        private readonly ISensorContext _sensorContext;

        public SensorService(ISensorContext sensorContext)
        {
            _sensorContext = sensorContext;
        }

        public async Task<IEnumerable<Sensor>> GetAllSensors()
        {
            var allSensors = await _sensorContext.Sensors.ToListAsync();

            return allSensors;
        }

        public async Task<Sensor> GetSensor(int sensorId)
        {
            var sensor = await _sensorContext.Sensors.FirstOrDefaultAsync(
                x => x.SensorId == sensorId);

            return sensor;
        }

        public async Task<IEnumerable<Measure>> GetMeasurements()
        {
            var measurements = await _sensorContext.Measurements.ToListAsync();

            return measurements;
        }

        public async Task<IEnumerable<Measure>> GetMeasurements(DateTime start, DateTime end)
        {
            var measurements = await _sensorContext.Measurements
                .Where(x => x.TimeStamp >= start && x.TimeStamp <= end)
                .ToListAsync();

            return measurements;
        }

        public async Task<IEnumerable<Measure>> GetMeasurementsForSensor(int sensorId)
        {
            var measurements = await _sensorContext.Measurements
                .Where(x => x.SensorId == sensorId)
                .ToListAsync();

            return measurements;
        }

        public async Task<Measure> GetMeasure(int measureId)
        {
            var measure = await _sensorContext.Measurements
                .FirstOrDefaultAsync(x => x.MeasureId == measureId);

            return measure;
        }
    }
}