using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominModels.Context
{
    public class LogContext: DbContext
    {
        public LogContext(DbContextOptions<LogContext> options)
    : base(options)
        {
        }

        public virtual DbSet<Log> Logs { get; set; }

    }
}
