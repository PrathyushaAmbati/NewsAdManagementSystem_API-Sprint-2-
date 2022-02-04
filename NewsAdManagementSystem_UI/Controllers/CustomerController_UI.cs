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
    public class CustomerController_UI : Controller
    {
        private readonly ConnectionString _connection;
        public CustomerController_UI(ConnectionString connection)
        {
            _connection = connection;
        }
        public IActionResult Index()//Select*from EmployDetails
        {
            var customerDetails = _connection.CustomerDetails.ToList();
            return View(customerDetails);
        }
        public IActionResult CustomerDetails()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CustomerDetails(CustomerDetailsClass customerDetailsClass)//Insertion into EmployDetails values
        {
            _connection.Add(customerDetailsClass);
            _connection.SaveChanges();
            ViewBag.message = "Saved Successfully";
            return View(customerDetailsClass);
        }

        public IActionResult EditCustomerDetails(int CustID)//select*from set EmployDetails where EmpID
        {

            var customerDetails = _connection.CustomerDetails.Find(CustID);

            return View(customerDetails);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCustomerDetails(CustomerDetailsClass customerDetailsClass)
        {
            _connection.Entry(customerDetailsClass).State = EntityState.Modified;
            //_connection.Update(employDetailsClass);
            _connection.SaveChanges();
            ViewBag.message = "Updated Successfully";
            return View(customerDetailsClass);
        }
        public IActionResult DeleteCustomerDetails(int CustID)//Deletion
        {
            var customerDetails = _connection.CustomerDetails.Find(CustID);
            return View(customerDetails);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCustomerDetails(CustomerDetailsClass customerDetailsClass)
        {
            //_connection.Entry(employDetailsClass).State = EntityState.Deleted;
            _connection.CustomerDetails.Remove(customerDetailsClass);
            await _connection.SaveChangesAsync();
            ViewBag.message = "Deleted Successfully";
            return View(customerDetailsClass);
        }
    }
}
