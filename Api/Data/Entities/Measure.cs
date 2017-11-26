using System;

namespace Api.Data.Entities
{
    public class Measure
    {
        public int MeasureId { get; set; }

        public DateTime TimeStamp { get; set; }

        public int SensorId { get; set; }

        public string SensorData { get; set; }
    }
}