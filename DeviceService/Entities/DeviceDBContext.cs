using DeviceService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceService.Entities
{
    public class DeviceDBContext : DbContext
    {
        public DeviceDBContext(DbContextOptions<DeviceDBContext> options) : base(options) { }

        public DbSet<Log> Logs { get; set; }
    }
}
