using Microsoft.AspNetCore.Identity;
using Portal2.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal2.DAl.Entities
{
    [Table ("User")]
    public class User:IdentityUser
    {
        public string? address { get; set; }
        public string? Image { get; set; }
        public string? FullName { get; set; }
        //// Navigation property for the relationship between User and Employee
        //public ICollection<Employee> Employees { get; set; } // HR manages these employees
    }
}
