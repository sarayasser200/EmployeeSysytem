using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal2.BLL.ModelVM.EmployeeVM
{
    public class GetEmployeeDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Image { get; set; }
        public bool IsDeleted { get; set; }
    }
}
