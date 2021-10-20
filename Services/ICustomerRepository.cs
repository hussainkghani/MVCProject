using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCProject.Models;
//import the models for the project

namespace MVCProject.Services
{
    public interface ICustomerRepository //declare return type as interface
    {
        Customer GetCustomer(int id);
        IEnumerable<Customer> GetCustomers();
        Customer AddCustomer(Customer e);
        Customer UpdateCustomer(Customer custchanges);
        Customer DeleteCustomer(int id);
        //Crud interface that will be used for customer repository 
    }
}
