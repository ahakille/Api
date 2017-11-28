using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Data.Entities
{
    [Table("sensors")]
    public class Sensor
    {
        [Column("sensorid")]
        public int SensorId { get; set; }

        [Column("sensorname")]
        public string SensorName { get; set; }
    }
}
