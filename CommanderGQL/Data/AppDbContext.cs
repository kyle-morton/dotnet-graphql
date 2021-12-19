using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommanderGQL.Domain;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Platform> Platforms {get;set;}
    }
}