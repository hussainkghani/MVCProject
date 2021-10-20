using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCProject.Services;
using Microsoft.EntityFrameworkCore;
using MVCProject.Models;
using Microsoft.AspNetCore.Identity; //add for login verification
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; //add for login verification with database

namespace MVCProject
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>(); //add repository service
            services.AddIdentity<User, IdentityRole>(options => //IdentityRole adds roles to application
            {
                options.Password.RequiredLength = 9; //as you're getting identity, use usercontext database to save everything
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
            }
            ).AddEntityFrameworkStores<UserContext>(); //add to Usercontext
            //next establish connection to sql server for Users
            services.AddDbContext<UserContext>(options =>
            options.UseSqlServer("Server=localhost;Database=BankUsers;Trusted_Connection=True;MultipleActiveResultSets=true"));
            //establish connection to sql server for customers
            services.AddDbContext<CustomerContext>(options =>
            options.UseSqlServer("Server=localhost;Database=BankCustomers;Trusted_Connection=True;MultipleActiveResultSets=true"));
            services.AddMvc(options => options.EnableEndpointRouting = false); //set to false for this version of .netMVC
        }

        //public async Task CreateRoles(RoleManager<IdentityRole>roleManager) //call method later in configure method
        //{
        //    string[] rolenames = { "Admin", "Employee", "Customer" };
        //    foreach(var rolename in rolenames) 
        //    {
        //        bool roleExists = await roleManager.RoleExistsAsync(rolename);
        //        if(!roleExists) //if the role does not already exist
        //        {
        //            IdentityRole newrole = new IdentityRole(); //create new object
        //            newrole.Name = rolename;
        //            await roleManager.CreateAsync(newrole); //call in pipeline next
        //        }
        //    }
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CustomerContext customerContext, UserContext userContext/*, RoleManager<IdentityRole>roleManager*/) //pass the database into pipeline
        {
            customerContext.Database.EnsureCreated(); //create customer database
            userContext.Database.EnsureCreated(); //create users database
            //await CreateRoles(roleManager); 
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles(); //use static files for images and CSS
            app.UseAuthentication(); //use authentication functions, create a controller for login functionality
            app.UseMvcWithDefaultRoute();
            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
