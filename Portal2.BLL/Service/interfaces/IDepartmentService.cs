using System.Collections.Generic;
using Portal2.DAl.Entities;
using Portal2.DAL.Entities;

namespace Portal2.BLL.Service.Interfaces
{
    public interface IDepartmentService
    {
        IEnumerable<Department> GetDepartments();
        Department GetDepartmentById(int id);
    }
}
