using Portal2.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal2.DAl.Repo.interfaces
{
    public interface IEmployeeRepo
    {
        List<Employee> GetEmployeeList();
        void Add(Employee employee);
        void SaveChanges();
        Employee GetById(int id);
        bool Update(Employee employee);
        bool Create(Employee employee);
        public bool Delete(int id);
    }
}
