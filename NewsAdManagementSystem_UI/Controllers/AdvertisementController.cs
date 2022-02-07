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
    public class AdvertisementController : Controller
    {
        private IConfiguration _configuration;
        public AdvertisementController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> ShowAdvertisementDetails()//Select*from AdvertisementDetails
        {
            IEnumerable<AdvertisementDetailsClass> advertisementResult = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Advertisement/GetAdvertisementDetails";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        advertisementResult = JsonConvert.DeserializeObject<IEnumerable<AdvertisementDetailsClass>>(result);
                    }
                }
            }
            return View(advertisementResult);
        }

        public IActionResult AdvertisementEntry()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> AdvertisementEntry(AdvertisementDetailsClass advertisementDetails)//Insertion into EmployDetails values
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(advertisementDetails), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Advertisement/AddAdvertisement";
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

    }
}
