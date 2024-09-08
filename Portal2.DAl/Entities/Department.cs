using Portal2.DAL.Entities;
using System.Collections.Generic;

namespace Portal2.DAl.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        // Navigation property
        public List<Employee>? Employees { get; set; } = new List<Employee>();
    }
}
