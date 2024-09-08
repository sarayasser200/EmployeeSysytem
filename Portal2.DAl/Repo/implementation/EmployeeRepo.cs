using Portal2.DAl.DB;
using Portal2.DAL.Entities;
using Portal2.DAl.Repo.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Portal2.DAl.Repo.implementation
{
    public class EmployeeRepo : IEmployeeRepo
    {

        private readonly ApplicationDbContext db;

        // Constructor injection
        public EmployeeRepo(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }
        public bool Create(Employee employee)
        {
            try
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;

            }
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }
        public void Add(Employee employee)
        {
            db.Employees.Add(employee);
        }

        public Employee GetById(int id) => db.Employees.Where(a => a.Id == id).FirstOrDefault();
        public List<Employee> GetEmployeeList() => db.Employees.Include(a=>a.Department).ToList();


        public bool Update(Employee employee)
        {
            try
            {
                var emp = db.Employees.Where(a => a.Id == employee.Id).FirstOrDefault();
                emp.Name = employee.Name;
                emp.Salary = employee.Salary;
                emp.Age = employee.Age;
                emp.Email = employee.Email;
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool Delete(int id)
        {
            try
            {
                var emp = db.Employees.FirstOrDefault(e => e.Id == id);
                if (emp != null)
                {
                    emp.IsDeleted = !emp.IsDeleted; 
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
