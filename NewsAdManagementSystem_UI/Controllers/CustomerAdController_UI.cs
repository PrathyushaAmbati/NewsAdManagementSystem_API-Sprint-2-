using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsAdManagementSystem_DAL.Data;
using NewsAdManagementSystem_Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsAdManagementSystem_UI.Controllers
{
    public class CustomerAdController_UI : Controller
    {
        private readonly ConnectionString _connection;
        public CustomerAdController_UI(ConnectionString connection)
        {
            _connection = connection;
        }
        public IActionResult Index()//Select*from EmployDetails
        {
            var customerAddetails = _connection.CustomerAdDetails.ToList();
            return View(customerAddetails);
        }
        public IActionResult CustomerAdDetails()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CustomerAdDetails(CustomerAdDetailsClass customerAdDetailsClass)//Insertion into EmployDetails values
        {
            _connection.Add(customerAdDetailsClass);
            _connection.SaveChanges();
            ViewBag.message = "Saved Successfully";
            return View(customerAdDetailsClass);
        }

        public IActionResult EditCustomerAdDetails(int SNo)//select*from set EmployDetails where EmpID
        {

            var customerAdDetails = _connection.CustomerAdDetails.Find(SNo);

            return View(customerAdDetails);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCustomerAdDetails(CustomerAdDetailsClass customerAdDetailsClass)
        {
            _connection.Entry(customerAdDetailsClass).State = EntityState.Modified;
            //_connection.Update(employDetailsClass);
            _connection.SaveChanges();
            ViewBag.message = "Updated Successfully";
            return View(customerAdDetailsClass);
        }
        public IActionResult DeleteCustomerAdDetails(int SNo)//Deletion
        {
            var customerAdDetails = _connection.CustomerAdDetails.Find(SNo);
            return View(customerAdDetails);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCustomerAdDetails(CustomerAdDetailsClass customerAdDetailsClass)
        {
            //_connection.Entry(employDetailsClass).State = EntityState.Deleted;
            _connection.CustomerAdDetails.Remove(customerAdDetailsClass);
            await _connection.SaveChangesAsync();
            ViewBag.message = "Deleted Successfully";
            return View(customerAdDetailsClass);
        }
    }
}
