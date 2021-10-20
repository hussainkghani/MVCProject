using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//add entity framework core
namespace MVCProject.Models
{
    //step 2
    public class CustomerContext : DbContext //generate context to connect to a database
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) //passing options paramter and calling constructor of base class
            : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; } //Customer Table, naming convention follows single customer table => multiple customers
        public DbSet<Employee> Employees { get; set; } //Create employee table
        protected override void OnModelCreating(ModelBuilder modelBuilder) //when you're creating the model you will have some records created
        {
            //create Seeding 
            modelBuilder.Entity<Employee>().HasData(
                new Employee //adding new Employee objects in the collection of Employees
                {
                    EmployeeID = 101,
                    EmpFname = "Bruce",
                    EmpLname = "Lee",
                    EmpEmail = "BruceLee101@gmail.com",
                    EmpPhoneNum = 2121011234
                },
                new Employee
                {
                    EmployeeID = 102,
                    EmpFname = "Tony",
                    EmpLname = "Jaa",
                    EmpEmail = "TonyJaa102@gmail.com",
                    EmpPhoneNum = 2121021234
                },
                new Employee
                {
                    EmployeeID = 103,
                    EmpFname = "Jet",
                    EmpLname = "Li",
                    EmpEmail = "JetLi103@gmail.com",
                    EmpPhoneNum = 2121031234
                },
                new Employee
                {
                    EmployeeID = 104,
                    EmpFname = "Gordon",
                    EmpLname = "Lui",
                    EmpEmail = "GordonLui104@gmail.com",
                    EmpPhoneNum = 2121041234
                }
                );
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerID = 1,
                    EmployeeID = 101,
                    CustFirstName = "Kurt",
                    CustLastName = "Warner",
                    CustAge = 28,
                    CustAddress = "123 Fake Street",
                    CustEmail = "kurtwarner@gmail.com",
                    Dept = Department.JeetKuneDo,
                    CustNumber = 718101001
                },
                new Customer
                {
                    CustomerID = 2,
                    EmployeeID = 102,
                    CustFirstName = "Isaac",
                    CustLastName = "Bruce",
                    CustAge = 24,
                    CustAddress = "123 Turf Street",
                    CustEmail = "isaacbruce@gmail.com",
                    Dept = Department.MuayThai,
                    CustNumber = 718102002
                },
                new Customer
                {
                    CustomerID = 3,
                    EmployeeID = 103,
                    CustFirstName = "Torry",
                    CustLastName = "Holt",
                    CustAge = 21,
                    CustAddress = "123 Receiver Road",
                    CustEmail = "toryholt@gmail.com",
                    Dept = Department.Wushu,
                    CustNumber = 718103003
                },
                  new Customer
                  {
                      CustomerID = 4,
                      EmployeeID = 104,
                      CustFirstName = "Marshall",
                      CustLastName = "Faulk",
                      CustAge = 24,
                      CustAddress = "123 Running Back Road",
                      CustEmail = "marshallfaulk@gmail.com",
                      Dept = Department.HungGa,
                      CustNumber = 718104004
                  }
                );
        }
    }
}
