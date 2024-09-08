using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portal2.BLL.ModelVM.EmployeeVM
{
    public class UpdateEmployeeVM
    {
        [Required]
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
        public IEnumerable<SelectListItem>? Departments { get; set; }
        public int? SelectedDepartmentId { get; set; }
    }
}
