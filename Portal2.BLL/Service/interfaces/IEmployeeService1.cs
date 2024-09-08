using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Portal2.BLL.ModelVM.EmployeeVM;
using Portal2.DAL.Entities;

namespace Portal2.BLL.Service.interfaces
{
    public interface IEmployeeService1
    {
        public List<GetAllEmployeeVM> GetEmployeeList();
        bool Create(CreateEmployeeVM employeevm);
        bool Update(UpdateEmployeeVM empvm);
        bool Delete(int id);
        Employee GetById(int id);

    }
}
