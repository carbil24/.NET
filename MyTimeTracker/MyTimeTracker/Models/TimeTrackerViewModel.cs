using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTimeTracker.Models
{
    //1- Make class public
    public class TimeTrackerViewModel
    {
        //2- Acces my data
        TimeTrackerDBContext context = new TimeTrackerDBContext();

        //Get all the employees
        public List<Employee> GetAllEmployees() //Without time cards
        {
            return context.Employees.ToList();
        }

        public List<Employee> SearchByLastName(string last)
        {
            return (from e in context.Employees.Include("TimeCards")
                    where e.LastName.Contains(last)
                    select e).ToList();
        }

        public List<Employee> GetAllEmployeesData() //with time cards
        {
            return context.Employees.Include("TimeCards").ToList();
            //include allow me to get foreign data - [known as Eager Loading]
        }

        //Get TimeCard for an employee
        public List<TimeCard> GetTimeCardsPerEmployee(int ID)
        {
            return (from e in context.Employees
                    where e.ID == ID
                    select e.TimeCards).SingleOrDefault();
        }

        //Delete employee Record
        public void DeleteEmployeeRecord(int ID)
        {
            Employee toBeDeleted = (from emp in context.Employees
                                    where emp.ID == ID
                                    select emp).SingleOrDefault();

            List<TimeCard> timeCardsToBeDeleted = GetTimeCardsPerEmployee(ID);

            context.TimeCards.RemoveRange(timeCardsToBeDeleted);
            context.Employees.Remove(toBeDeleted);
            context.SaveChanges();
        }

        public void UpdateEmployee(Employee updated)
        {
            Employee current = (from emp in context.Employees
                                where emp.ID == updated.ID
                                select emp).SingleOrDefault();

            current.FirstName = updated.FirstName;
            current.LastName = updated.LastName;
            current.Role = updated.Role;
            /* All other properties need to be copied. */

            context.SaveChanges();

        }

        public void AddNewEmployee(Employee newEmployee)
        {
            context.Employees.Add(newEmployee);
            context.SaveChanges();
        }
    }
}
