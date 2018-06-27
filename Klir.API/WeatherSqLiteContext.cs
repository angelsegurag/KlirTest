using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klir.API
{
    public class WeatherSqLiteContext : DbContext
    {
        public WeatherSqLiteContext(DbContextOptions<WeatherSqLiteContext> options) : base(options)
        {
        }

        public DbSet<Klir.Model.WeatherForecast> Forecasts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Klir.Model.WeatherForecast>().ToTable("forecast");
        }
    }
}
