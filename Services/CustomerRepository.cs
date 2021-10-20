using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private CustomerContext customerContext; //create variable for CustomerContext database 
        public CustomerRepository(CustomerContext context)
        {
            customerContext = context; //context reference 
        }
        public Customer AddCustomer(Customer e)
        {
            /*e.CustomerID = customerContext.Customers.Max(e => e.CustomerID + 1)*//*;*/ //finds max number of customers and adds to last value
            if (e.Dept.ToString()=="JeetKuneDo")
            {
                e.EmployeeID = 101;
            } //pass to EmployeeID
            if(e.Dept.ToString()=="MuayThai")
            {
                e.EmployeeID = 102;
            }
            if (e.Dept.ToString()=="Wushu")
            {
                e.EmployeeID = 103;
            }
            if (e.Dept.ToString()=="HungGa")
            {
                e.EmployeeID = 104;
            }
            customerContext.Customers.Add(e); //add object e as Customer class to customer context
            customerContext.SaveChanges(); //saves changes to database
            return e; 
        }
        public Customer DeleteCustomer(int id)
        {
            Customer cust = customerContext.Customers.FirstOrDefault(e => e.CustomerID == id); //set object of class customer and search by id in database
            if(cust !=null)
            {
                customerContext.Customers.Remove(cust); //if object cust is found, remove from database
            }
            customerContext.SaveChanges();
            return cust;
        }

        public Customer GetCustomer(int id)
        {
            return customerContext.Customers.FirstOrDefault(e => e.CustomerID == id); //returns customer from database by referencing the id number
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return customerContext.Customers.ToList(); //retrieves all customers in Customer class as a list
        }
        public Customer UpdateCustomer(Customer custchanges)
        {
            Customer cust = customerContext.Customers.FirstOrDefault(e => e.CustomerID == custchanges.CustomerID); //pass values of custchanges by referenceing ID
            if (cust != null)
            {
                cust.CustFirstName = custchanges.CustFirstName; //set changes for cust object as custchanges
                cust.CustLastName = custchanges.CustLastName;
                cust.CustAge = custchanges.CustAge;
                cust.CustAddress = custchanges.CustAddress;
                cust.CustEmail = custchanges.CustEmail;
                cust.CustNumber = custchanges.CustNumber;
                cust.Dept = custchanges.Dept;
                if (cust.Dept.ToString() == "Banking") //reassigns employee that serves customer based on department
                {
                    cust.EmployeeID = 101;
                } 
                if (cust.Dept.ToString() == "Marketing")
                {
                    cust.EmployeeID = 102;
                }
                if (cust.Dept.ToString() == "Mortgage")
                {
                    cust.EmployeeID = 103;
                }
                if (cust.Dept.ToString() == "Equities")
                {
                    cust.EmployeeID = 104;
                }
            }
            customerContext.SaveChanges(); //save custchanges to customer database
            return cust;
        }
    }
}
