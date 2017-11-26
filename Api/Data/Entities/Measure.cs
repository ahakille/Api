using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Data.Entities
{
    [Table("measure")]
    public class Measure
    {
        [Column("measureid")]
        public int MeasureId { get; set; }

        [Column("timestamp")]
        public DateTime TimeStamp { get; set; }

        [Column("sensorid")]
        public int SensorId { get; set; }

        [Column("sensordata")]
        public string SensorData { get; set; }
    }
}