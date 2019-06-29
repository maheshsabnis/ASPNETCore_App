using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace CoreAppHome.Models
{
    public class Employee
    {
        [Key]
        public int EmpRowId { get; set; }
        [Required(ErrorMessage ="EmpNo is required")]
        public string EmpNo { get; set; }
        [Required(ErrorMessage = "EmpName is required")]
        public string EmpName { get; set; }
        [Required(ErrorMessage = "Designation is required")]
        public string Designation { get; set; }
        [Required(ErrorMessage = "Salary is required")]
        public int Salary { get; set; }
        [Required(ErrorMessage = "DeptRowId is required")]
        public int DeptRowId { get; set; } // foreign key
        public Department Department { get; set; } // referencial integrity
    }
}
