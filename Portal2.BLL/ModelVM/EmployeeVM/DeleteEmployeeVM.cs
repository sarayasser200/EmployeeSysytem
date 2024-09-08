using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal2.BLL.ModelVM.EmployeeVM
{
    public class DeleteEmployeeVM
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(10, 40)]
        public int? Age { get; set; }
        public string Email { get; set; }
        public string? Image { get; set; }
        public IFormFile? ImageName { get; set; }

        public double Salary { get; set; }
        [ForeignKey("Department")]
        public int? DeptId { get; set; }
    }
}
