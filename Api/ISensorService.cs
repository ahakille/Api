using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data;
using Api.Data.Entities;

namespace Api
{
    public interface ISensorService
    {
        Task<IEnumerable<Sensor>> GetAllSensors();
        Task<Sensor> GetSensor(int sensorId);
        Task<IEnumerable<Measure>> GetMeasurements();
        Task<IEnumerable<Measure>> GetMeasurements(DateTime start, DateTime end);
        Task<IEnumerable<Measure>> GetMeasurementsForSensor(int sensorId);
        Task<Measure> GetMeasure(int measureId);
    }
}