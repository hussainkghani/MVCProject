using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //import for validation fields

namespace MVCProject.ViewModels
{
    public class RegisterViewModel:LoginViewModel //inherit from loginviewmodel class
    {
        [Required(ErrorMessage = "Please enter first name")]
        [DataType(DataType.Text)]
        [StringLength(10, ErrorMessage = "First name must not exceed 10 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        [DataType(DataType.Text)]
        [StringLength(10, ErrorMessage = "Last name must not exceed 10 characters")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Please enter phone number")]
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Format")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        //create a register view in account views folder
    }
}
