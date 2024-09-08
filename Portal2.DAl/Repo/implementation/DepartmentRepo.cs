using Portal2.DAl.DB;
using Portal2.DAl.Entities;
using Portal2.DAl.Repo.interfaces;
using Portal2.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Portal2.DAl.Repo.implementation
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly ApplicationDbContext db;

        public DepartmentRepo(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        public bool Create(Department department)
        {
            try
            {
                db.Departments.Add(department);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Department GetById(int id) => db.Departments.Where(d => d.Id == id).FirstOrDefault();

        public List<Department> GetDepartmentList() => db.Departments.ToList();

        public bool Update(Department department)
        {
            try
            {
                var dep = db.Departments.Where(d => d.Id == department.Id).FirstOrDefault();
                if (dep != null)
                {
                    dep.Name = department.Name;
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

        public bool Delete(int id)
        {
            try
            {
                var dep = db.Departments.FirstOrDefault(d => d.Id == id);
                if (dep != null)
                {
                    db.Departments.Remove(dep); 
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
