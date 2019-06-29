using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace CoreAppHome.Models
{
    public class Department
    {
        [Key]
        public int DeptRowId { get; set; }
        [Required(ErrorMessage ="DeptNo is required")]
        public string DeptNo { get; set; }
        [Required(ErrorMessage = "DeptName is required")]
        public string DeptName { get; set; }
        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Capacity is required")]
        public int Capacity { get; set; }
        // one-to-many relationship
        public ICollection<Employee> Employees { get; set; }
    }

    
}
