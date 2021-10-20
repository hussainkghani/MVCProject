using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; //add via nuget package
using Microsoft.EntityFrameworkCore; //for sql server

namespace MVCProject.Models
{
    public class UserContext:IdentityDbContext<User> //inherit properties from User class
    {
        public UserContext (DbContextOptions<UserContext>options)
            :base(options) //call base constructor to pass options
            //go to startup.cs next to add login functionality
        {

        }
    }
}
