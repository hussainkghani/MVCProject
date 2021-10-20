using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCProject.Services;
using MVCProject.Models;
using Microsoft.AspNetCore.Authorization; //import to restrict acessability to certain users


namespace MVCProject.Controllers
{
    public class CustomerController : Controller
    {
        ICustomerRepository customerRepository; //declare variable of repository service
        public CustomerController(ICustomerRepository repository)
        {
            customerRepository = repository;
        }
        [Authorize/*(Roles = "Employee" + "Admin")*/] //all employees and admin are authorized to view this data
        public ViewResult AllCustomers()
        {
            var model = customerRepository.GetCustomers(); //get list of customers using repository method as model
            return View(model); // the view will display the model
        }
        [HttpGet]
        [Authorize]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize/*(Roles = "Employee" + "Admin")*/]
        public IActionResult Create(Customer obj) //create an object representing customer class
        {
            if (ModelState.IsValid)
            {
                Customer newcustomer = customerRepository.AddCustomer(obj); //if customer object is valid, use add customer method from repository
                return RedirectToAction("AllCustomers"); //redirects employee or Admin back to all customers page view
            }
            return View(); 
        }
        public IActionResult Index()
        {
            var list = customerRepository.GetCustomers();
            List<string> nameslist = new List<string>();
            foreach (var e in list)
            {
                nameslist.Add(e.CustFirstName);
                nameslist.Add(e.CustLastName);
            }
            return View();
        }
        public IActionResult Details(string custname) //details view will get customer name
        {
            ViewBag.selectedcustomer = custname;
            return View(); 
        }
        [HttpGet]
        [Authorize/*(Roles = "Employee" + "Admin")*/]
        public ViewResult Update(int id) //pass parameter id
        {
            Customer obj = customerRepository.GetCustomer(id); //search customer object using id in repository method
            return View(obj);  //pass customer to this view, this is the customer to edit
        }
        [HttpPost]
        [Authorize/*(Roles = "Employee" + "Admin")*/]
        public ViewResult Update(Customer cust, int id) 
        {
            cust.CustomerID = id;
            Customer changedcust = customerRepository.UpdateCustomer(cust);
            var model = customerRepository.GetCustomers(); //get list of all customers again
            return View("AllCustomers", model); 
        }
        [HttpGet]
        [Authorize/*(Roles = "Employee" + "Admin")*/]
        public IActionResult Delete(int id)
        {
            customerRepository.DeleteCustomer(id); //using customer repository delete method
            return RedirectToAction("AllCustomers"); //return view of all customers once deleted
        }
    }
}
