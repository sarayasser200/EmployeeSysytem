using Portal2.DAl.Entities;
using System.Collections.Generic;

namespace Portal2.DAl.Repo.interfaces
{
    public interface IDepartmentRepo
    {
        List<Department> GetDepartmentList();
        Department GetById(int id);
        bool Update(Department department);
        bool Create(Department department);
        bool Delete(int id);
    }
}
