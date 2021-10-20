using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MVCProject.Models
{
    public class User:IdentityUser //base class is already present in aspnetcore.identity
    {
        public string Firstname { get; set; } //create a usercontext class in model
        public string Lastname { get; set; }
        public int Age { get; set; }
    }
}
