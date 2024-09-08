using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Portal2.BLL.ModelVM.EmployeeVM
{
    public class CreateEmployeeVM
    {

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

        //// Property to hold the selected department
        public int? SelectedDepartmentId { get; set; }

    }
}
