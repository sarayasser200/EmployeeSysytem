using System.Collections.Generic;
using Portal2.BLL.Service.Interfaces;
using Portal2.DAl.Entities;
using Portal2.DAl.Repo.interfaces;
using Portal2.DAL.Entities;
using Portal2.DAl.Repo.interfaces;


namespace Portal2.BLL.Service.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepo departmentRepo;

        public DepartmentService(IDepartmentRepo departmentRepo)
        {
            this.departmentRepo = departmentRepo;
        }

        public IEnumerable<Department> GetDepartments()
        {
            return departmentRepo.GetDepartmentList(); // Assuming GetAll() fetches all departments
        }

        public Department GetDepartmentById(int id)
        {
            return departmentRepo.GetById(id); // Assuming GetById() fetches a department by ID
        }
    }
}
