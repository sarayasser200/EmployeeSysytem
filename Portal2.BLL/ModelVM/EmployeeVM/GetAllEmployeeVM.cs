using Portal2.DAl.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal2.BLL.ModelVM.EmployeeVM
{
   public class GetAllEmployeeVM
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(10, 40)]
        public int? Age { get; set; }

        public DateTime? CreateOn { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; }

        public string? Image { get; set; }
        public string? DepartmentName { get; set; }
    }
}
