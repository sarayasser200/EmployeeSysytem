using Microsoft.AspNetCore.Http;
using Portal2.DAl.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portal2.DAL.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(10, 40)]
        public int? Age { get; set; }
        public string Email { get; set; }

        public double Salary { get; set; }

        public DateTime? CreateOn { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; }

        public string? Image { get; set; }

        [ForeignKey("Department")]
        public int? DeptId { get; set; }

        public Department? Department { get; set; }
        //[ForeignKey("UserId")]
        //public string? UserId { get; set; }  // FK to the User entity
        
        //public User? User { get; set; }  // Navigation property to User entity
    }
}
