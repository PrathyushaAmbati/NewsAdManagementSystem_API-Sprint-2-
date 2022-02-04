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
    public class EmployController_UI : Controller
    {
        private readonly ConnectionString _connection;
        public EmployController_UI(ConnectionString connection)
        {
            _connection = connection;
        }
        public IActionResult Index()//Select*from EmployDetails
        {
            var employdetails = _connection.EmployeeDetails.ToList();
            return View(employdetails);
        }
        public IActionResult EmployDetails()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EmployDetails(EmployDetails employDetails)//Insertion into EmployDetails values
        {
            _connection.Add(employDetails);
            _connection.SaveChanges();
            ViewBag.message = "Saved Successfully";
            return View(employDetails);
        }

        public IActionResult EditEmployDetails(int EmpID)//select*from set EmployDetails where EmpID
        {

            var employdetails = _connection.EmployeeDetails.Find(EmpID);

            return View(employdetails);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditEmployDetails(EmployDetails employDetails)
        {
            _connection.Entry(employDetails).State = EntityState.Modified;
            //_connection.Update(employDetailsClass);
            _connection.SaveChanges();
            ViewBag.message = "Updated Successfully";
            return View(employDetails);
        }
        public IActionResult DeleteEmployDetails(int EmpID)//Deletion
        {
            var employeeDetails = _connection.EmployeeDetails.Find(EmpID);
            return View(employeeDetails);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEmployDetails(EmployDetails employDetails)
        {
            //_connection.Entry(employDetailsClass).State = EntityState.Deleted;
            _connection.EmployeeDetails.Remove(employDetails);
            await _connection.SaveChangesAsync();
            ViewBag.message = "Deleted Successfully";
            return View(employDetails);
        }
    }
}
