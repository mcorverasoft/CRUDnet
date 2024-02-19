using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Cars.Models;

namespace Cars.DataAccess
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Car { get; set; }
    }
}

