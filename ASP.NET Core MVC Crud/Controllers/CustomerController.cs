using ASP.NET_Core_MVC_Crud.Models;
using ASP.NET_Core_MVC_Crud.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_MVC_Crud.Controllers
{
    public class CustomerController : Controller
    {
        private readonly TestDbContext _testDbContext;
        private string UserID = "ADMIN";
        public CustomerController(TestDbContext testDbContext)
        {
            _testDbContext = testDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var res = await _testDbContext.Customers.OrderBy(x => x.FirstName).ToListAsync();
            return await Task.Run(() => View(res));
        }

        [HttpGet]
        public async Task<IActionResult> Add(int id = 0)
        {

            return await Task.Run(() => View());
        }

        [HttpPost]
        public async Task<IActionResult> Add(Customers customers)
        {
            customers.CustomerID = (new Random()).Next(100, 1000);
            customers.InsertDate = DateTime.Now;
            customers.InsertedBy = UserID;
            _testDbContext.Customers.Add(customers);
            await _testDbContext.SaveChangesAsync();
            return Json('Y');
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id = 0)
        {
            var res = await _testDbContext.Customers.Where(x => x.CustomerID == id).FirstOrDefaultAsync();
            return await Task.Run(() => View(res));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Customers customers)
        {
            _testDbContext.Customers.Attach(customers);
            _testDbContext.Entry(customers).Property(u => u.FirstName).IsModified = true;
            _testDbContext.Entry(customers).Property(u => u.LastName).IsModified = true;
            _testDbContext.Entry(customers).Property(u => u.Phone).IsModified = true;
            _testDbContext.Entry(customers).Property(u => u.Email).IsModified = true;
            await _testDbContext.SaveChangesAsync();

            return Json('Y');
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id = 0)
        {
            var res = await _testDbContext.Customers.Where(x => x.CustomerID == id).ToListAsync();
            _testDbContext.Customers.RemoveRange(res);
            await _testDbContext.SaveChangesAsync();

            return Json('Y');
        }
    }
}
