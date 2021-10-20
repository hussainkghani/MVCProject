using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
//import data annotations
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProject.Models
{
    //1 employee can have many customers
   
    public class Employee
    {
        [Key] //set employee ID as primary Key
        [Display(Name = "Employee ID")]
        [Required]
        
        public int EmployeeID { get; set; }
        [Required]
        [StringLength(10, ErrorMessage ="First name cannot exceed 10 characters")]
        public string EmpFname{ get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "First name cannot exceed 10 characters")]
        public string EmpLname { get; set; }

        [Required]
        [Display(Name = "Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Format")]
        public string EmpEmail { get; set; }
        [Required]
        [Display(Name ="Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public int EmpPhoneNum { get; set; }
        public virtual ICollection<Customer>Customers { get; set; } //relation, 1 Employee will have a collection of Customers
    }
}
