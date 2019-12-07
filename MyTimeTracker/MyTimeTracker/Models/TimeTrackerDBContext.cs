using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//1- Add Namespace
using System.Data.Entity;

namespace MyTimeTracker.Models
{
    //2- Inherit from DBContext
    class TimeTrackerDBContext : DbContext
    {
        //Get the DB sets from DB Tables
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TimeCard> TimeCards { get; set; }
    }
}
