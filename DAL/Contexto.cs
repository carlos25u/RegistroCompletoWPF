using Microsoft.EntityFrameworkCore;
using RegistroCompletoWPF.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroCompletoWPF.DAL
{
    class Contexto : DbContext
    {
        public DbSet<Roles> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data source = DATA\TeacherControl.db");
        }
    }
}
