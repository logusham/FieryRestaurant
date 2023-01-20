using FieryRestaurant.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieryRestaurant.Repository.DataAccess
{
    public class FieryDbContext : DbContext
    {
        public FieryDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Supplier> supplier { get; set; }
    }
}
