using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace APIOportunidade.Data
{
    public class APIOportunidadeContext : DbContext
    {
        public APIOportunidadeContext (DbContextOptions<APIOportunidadeContext> options)
            : base(options)
        {
        }

        public DbSet<Models.OportunidadeModel> OportunidadeModel { get; set; } = default!;
    }
}
