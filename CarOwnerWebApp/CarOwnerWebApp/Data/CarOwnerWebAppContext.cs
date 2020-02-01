using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarOwnerWebApp.Models;

namespace CarOwnerWebApp.Models
{
    public class CarOwnerWebAppContext : DbContext
    {
        public CarOwnerWebAppContext (DbContextOptions<CarOwnerWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<CarOwnerWebApp.Models.Car> Car { get; set; }

        public DbSet<CarOwnerWebApp.Models.Owner> Owner { get; set; }
    }
}
