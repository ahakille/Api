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
        private readonly SensorContext _sensorContext;

        public SensorService(SensorContext sensorContext)
        {
            _sensorContext = sensorContext;
        }

        public async Task<IEnumerable<Sensor>> GetAllSensors()
        {
            return await _sensorContext.Sensors.ToListAsync();
        }

        public async Task<Sensor> GetSensor(int sensorId)
        {
            return await _sensorContext.Sensors.FirstOrDefaultAsync(
                x => x.SensorId == sensorId);
        }

        public async Task<IEnumerable<Measure>> GetMeasurements()
        {
            return await _sensorContext.Measurements.ToListAsync();            
        }

        public async Task<IEnumerable<Measure>> GetMeasurements(DateTime start, DateTime end)
        {
            return await _sensorContext.Measurements
                .Where(x => x.TimeStamp >= start && x.TimeStamp <= end)
                .ToListAsync();
        }

        public async Task<IEnumerable<Measure>> GetMeasurementsForSensor(int sensorId)
        {
            return await _sensorContext.Measurements
                .Where(x => x.SensorId == sensorId)
                .ToListAsync();
        }

        public async Task<Measure> GetMeasure(int measureId)
        {
            return await _sensorContext.Measurements
                .FirstOrDefaultAsync(x => x.MeasureId == measureId);
        }
        public async Task<int?> SetMeasure(int sensorId, string sensorData, DateTime timeStamp)
        {
            await _sensorContext.Measurements
                .AddAsync(new Measure
                {
                    SensorId = sensorId,
                    SensorData = sensorData,
                    TimeStamp = timeStamp
                });

            var response = await _sensorContext.SaveChangesAsync();

            return response;
        }
    }
}