using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal2.BLL.ModelVM.EmployeeVM
{
    public class LoginUserVM
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]   
        public string Password { get; set; }
        public bool RemenberMe { get; set; }

    }
}
