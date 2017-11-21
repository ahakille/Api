using System;

namespace Api.Data
{
    public class Measure
    {
        public int MeasureId { get; set; }

        public DateTime TimeStamp { get; set; }

        public int SensorId { get; set; }

        public string SensorData { get; set; }
    }
}