using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tarea.Models;

namespace Tarea.Data
{
    public class TareaContext : DbContext
    {
        public TareaContext (DbContextOptions<TareaContext> options)
            : base(options)
        {
        }

        public DbSet<Tarea.Models.CasaConstruida> CasaConstruida { get; set; }

        public DbSet<Tarea.Models.ModeloCasa> ModeloCasa { get; set; }
    }
}
