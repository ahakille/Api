using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public interface ISensorContext
    {
        DbSet<Sensor> Sensors { get; set; }
        DbSet<Measure> Measurements { get; set; }
    }
}
