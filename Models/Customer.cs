using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProject.Models
{
    public enum Department
    {
        JeetKuneDo,
        MuayThai,
        Wushu,
        HungGa
    }
    public class Customer
    {
        [Key] //Customer ID will be the primary key
        [Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerID { get; set; }
        [Required]
        public int EmployeeID { get; set; } //foreign key
        [Required(ErrorMessage ="First Name is Required")]
        [DataType(DataType.Text)]
        [StringLength(10, ErrorMessage ="First name must not exceed 10 characters")]
        public string CustFirstName { get; set; }
        [DataType(DataType.Text)]
        [StringLength(10, ErrorMessage ="Last name must not exceed 10 characters")]
        [Required(ErrorMessage ="Last Name is Required")]
        public string CustLastName { get; set; }
        [Required]
        public int CustAge { get; set; }
        [Required(ErrorMessage ="Please enter address")]
        [DataType(DataType.MultilineText)]
        [StringLength(50, MinimumLength = 10)]
        public string CustAddress { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Format")]
        public string CustEmail { get; set; }
        public Department Dept { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public int CustNumber { get; set; }
    }
}
