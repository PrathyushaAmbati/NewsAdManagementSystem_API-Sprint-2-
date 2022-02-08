using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NewsAdManagementSystem_Entity.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NewsAdManagementSystem_UI.Controllers
{
    public class CustomerController : Controller
    {
        private IConfiguration _configuration;
        public CustomerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region ShowCustomerDetails
        public async Task<IActionResult> ShowCustomerDetails()//Select*from CustomerDetails
        {
            IEnumerable<CustomerDetailsClass> customerResult = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Customer/GetCustomerDetails";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        customerResult = JsonConvert.DeserializeObject<IEnumerable<CustomerDetailsClass>>(result);
                    }
                }
            }
            return View(customerResult);  
        }
        #endregion ShowCustomerDetails


        #region Register
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Register(CustomerDetailsClass customerDetails)//Insertion into CustomerDetails 
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(customerDetails), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Customer/AddCustomer";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Saved Successfully";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries!";
                    }
                }
            }
            return View();
        }
        #endregion Register


        #region EditCustomerDetails

        //GET Method
        [HttpGet]
        public async Task<IActionResult> EditCustomerDetails(int CustID)//Update Customer Details 
        {
            CustomerDetailsClass customerDetailsClass = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Customer/GetCustomerDetailsByID?CustID=" + CustID;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        customerDetailsClass = JsonConvert.DeserializeObject<CustomerDetailsClass>(result);

                    }
                }
            }
            return View(customerDetailsClass);
        }

        //POST Method
        [HttpPost]
        public async Task<IActionResult> EditCustomerDetails(CustomerDetailsClass customerDetailsClass)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(customerDetailsClass), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Customer/UpdateCustomer";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Updated Successfully";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries!";
                    }
                }
            }
            return View(customerDetailsClass);
        }
        #endregion EditCustomerDetails


        #region DeleteCustomerDetails
        public async Task<IActionResult> DeleteCustomerDetails(int CustID)//Delete CustomerDetails 
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Customer/DeleteCustomer?CustID=" + CustID;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        ViewBag.message = "Deleted Successfully";
                    }
                }
            }
            return RedirectToAction("ShowCustomerDetails");

        }
        #endregion DeleteCustomerDetails


        #region Login
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(CustomerDetailsClass customerDetailsClass)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(customerDetailsClass), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Customer/Login";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        return RedirectToAction("ShowCustomerDetails");
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong credentials!";
                    }
                }
            }
            return View();
        }
        #endregion Login
    }
}