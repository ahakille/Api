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
        Task<IEnumerable<Measure>> GetMeasurementsWithTimeAndId(DateTime? start, DateTime? end, int sensorId);
        Task<IEnumerable<Measure>> GetMeasurementsForSensor(int sensorId);
        Task<Measure> GetMeasure(int measureId);
        Task<int?> SetMeasure(int sensorId, string sensorData, DateTime timeStamp);
    }
}