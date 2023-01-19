using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using project.Models;

namespace project.Data
{
    public class projectContext : DbContext
    {
        public projectContext (DbContextOptions<projectContext> options)
            : base(options)
        {
        }

        public DbSet<project.Models.Sosiri> Sosiri { get; set; } = default!;

        public DbSet<project.Models.Plecari> Plecari { get; set; }

        public DbSet<project.Models.Destinatie> Destinatie { get; set; }

        public DbSet<project.Models.Companie> Companie { get; set; }

        public DbSet<project.Models.Angajat> Angajat { get; set; }
    }
}
