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
    public class EmployController : Controller
    {
        private  IConfiguration _configuration;
        public EmployController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> ShowEmployDetails()//Select*from EmployDetails
        {
            IEnumerable<EmployDetails> employResult = null;
            using(HttpClient client=new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Employ/GetEmployDetails";
                using(var response=await client.GetAsync(endPoint))
                {
                    if(response.StatusCode==System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        employResult = JsonConvert.DeserializeObject<IEnumerable<EmployDetails>>(result);
                    }                    
                }
            }
            return View(employResult);
        }
        //GET Method
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        
        public async Task<IActionResult> Register(EmployDetails employDetails)//Insertion into EmployDetails values
        {
            ViewBag.status = "";
            using(HttpClient client=new HttpClient())
           {
                StringContent content = new StringContent(JsonConvert.SerializeObject(employDetails), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Employ/AddEmploy";
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
        
        //GET Method
        [HttpGet]
        public IActionResult EditEmployDetails(int EmpID)//Update EmployDetails 
        {
            

            return View();
                        
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployDetails([FromBody]EmployDetails employDetails)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(employDetails), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Employ/UpdateEmploy";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {

                        return RedirectToAction("ShowEmployDetails");
                    }
                }
            }
            return View(employDetails);
        }

    }
}
