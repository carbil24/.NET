namespace MyTimeTracker.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    
    //Add this before
    using System.Collections.Generic;
    using MyTimeTracker.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MyTimeTracker.Models.TimeTrackerDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyTimeTracker.Models.TimeTrackerDBContext context)
        {
            /*
             * Only do this in test data
             * NEVER DROP ACTUAL PRODUCTION DATA
             */
            context.Employees.RemoveRange(context.Employees);
            context.TimeCards.RemoveRange(context.TimeCards);

            List<Employee> employees = new List<Employee>();

            employees.Add(new Employee()
            {
                FirstName = "Michael",
                LastName = "Lishaa",
                Department = "IT",
                Role = "Manager",
                HireDate = DateTime.Now.AddYears(-2),
                Salary = 15000,
                TimeCards = new List<TimeCard>()
                {
                    new TimeCard()
                    {
                        SubmissionDate = DateTime.Now.AddDays(-30),
                        MondayHours = 8, TuesdayHours = 7, WednesdayHours = 6,
                        ThursdayHours = 8, FridayHours = 5, SaturdayHours = 0, SundayHours = 0
                    },
                    new TimeCard()
                    {
                        SubmissionDate = DateTime.Now.AddDays(-7),
                        MondayHours = 0, TuesdayHours = 7, WednesdayHours = 7,
                        ThursdayHours = 7, FridayHours = 7, SaturdayHours = 7, SundayHours = 0
                    }
                }
            });

            employees.Add(new Employee()
            {
                FirstName = "Berri",
                LastName = "Allan",
                Department = "CSI Lab",
                Role = "Flash",
                HireDate = DateTime.Now.AddYears(-3),
                Salary=20000,
                DOB = DateTime.Now.AddYears(-40),
                TimeCards = new List<TimeCard>()
                {
                    new TimeCard()
                    {
                        SubmissionDate = DateTime.Now.AddDays(-14),
                        MondayHours = 10, TuesdayHours = 10, WednesdayHours = 10,
                        ThursdayHours = 10, FridayHours = 10, SaturdayHours = 0, SundayHours = 0
                    },
                    new TimeCard()
                    {
                        SubmissionDate = DateTime.Now.AddDays(-7),
                        MondayHours = 7, TuesdayHours = 7, WednesdayHours = 7,
                        ThursdayHours = 7, FridayHours = 7, SaturdayHours = 7, SundayHours = 0
                    }
                }
            });

            employees.Add(new Employee()
            {
                FirstName = "Oliver",
                LastName = "Queen",
                Department = "Management",
                Role = "CEO",
                HireDate = DateTime.Now.AddYears(-5),
                DOB = DateTime.Now.AddYears(-34),
                Salary = 50000,
                TimeCards = new List<TimeCard>()
                {
                    new TimeCard()
                    {
                        SubmissionDate = DateTime.Now.AddDays(-14),
                        MondayHours = 5, TuesdayHours = 5, WednesdayHours = 5,
                        ThursdayHours = 5, FridayHours = 5, SaturdayHours = 0, SundayHours = 0
                    },
                    new TimeCard()
                    {
                        SubmissionDate = DateTime.Now.AddDays(-7),
                        MondayHours = 7, TuesdayHours = 6, WednesdayHours = 6,
                        ThursdayHours = 6, FridayHours = 6, SaturdayHours = 0, SundayHours = 0
                    }
                }
            });

            context.Employees.AddRange(employees);
            base.Seed(context);
        }
    }
}
