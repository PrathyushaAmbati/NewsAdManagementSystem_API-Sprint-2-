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
    public class CustomerAdController : Controller
    {
        private IConfiguration _configuration;
        public CustomerAdController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #region ShowCustomerAdDetails
        public async Task<IActionResult> ShowCustomerAdDetails()//Select*from CustomerAdDetails
        {
            IEnumerable<CustomerAdDetailsClass> customerAdResult = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "CustomerAd/GetCustomerAdDetails";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        customerAdResult = JsonConvert.DeserializeObject<IEnumerable<CustomerAdDetailsClass>>(result);
                    }
                }
            }
            return View(customerAdResult);
        }
        #endregion ShowCustomerAdDetails
        //Get Method
        #region BookAdSlot
        public IActionResult BookAdSlot()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> BookAdSlot(CustomerAdDetailsClass customerAdDetails)//Insertion into EmployDetails values
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(customerAdDetails), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Customer/AddCustomerAd";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Slot booked Successfully";
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
#endregion BookAdSlot