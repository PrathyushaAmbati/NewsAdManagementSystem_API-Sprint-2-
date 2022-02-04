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
    public class AdvertisementController_UI : Controller
    {
        private readonly ConnectionString _connection;
        public AdvertisementController_UI(ConnectionString connection)
        {
            _connection = connection;
        }
        public IActionResult Index()//Select*from EmployDetails
        {
            var advertisementDetails = _connection.AdvertisementDetails.ToList();
            return View(advertisementDetails);
        }
        public IActionResult AdvertisementDetails()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdvertisementDetails(AdvertisementDetailsClass advertisementDetailsClass)//Insertion into EmployDetails values
        {
            _connection.Add(advertisementDetailsClass);
            _connection.SaveChanges();
            ViewBag.message = "Saved Successfully";
            return View(advertisementDetailsClass);
        }

        public IActionResult EditAdvertisementDetails(int AdCode)//select*from set EmployDetails where EmpID
        {

            var advertisementDetails = _connection.AdvertisementDetails.Find(AdCode);

            return View(advertisementDetails);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditAdvertisementDetails(AdvertisementDetailsClass advertisementDetailsClass)
        {
            _connection.Entry(advertisementDetailsClass).State = EntityState.Modified;
            //_connection.Update(employDetailsClass);
            _connection.SaveChanges();
            ViewBag.message = "Updated Successfully";
            return View(advertisementDetailsClass);
        }
        public IActionResult DeleteAdvertisementDetails(int AdCode)//Deletion
        {
            var advertisementDetails = _connection.AdvertisementDetails.Find(AdCode);
            return View(advertisementDetails);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAdvertisementDetails(AdvertisementDetailsClass advertisementDetailsClass)
        {
            //_connection.Entry(employDetailsClass).State = EntityState.Deleted;
            _connection.AdvertisementDetails.Remove(advertisementDetailsClass);
            await _connection.SaveChangesAsync();
            ViewBag.message = "Deleted Successfully";
            return View(advertisementDetailsClass);
        }
    }
}
