using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal2.BLL.ModelVM.EmployeeVM
{
    public  class RegisterUserVM
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

    }
}
