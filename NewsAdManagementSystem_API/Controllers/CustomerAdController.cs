using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsAdManagementSystem_BAL.Services;
using NewsAdManagementSystem_Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsAdManagementSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAdController : ControllerBase
    {
        private CustomerAdService _customerAdService;
        public CustomerAdController(CustomerAdService customerAdService)
        {
            _customerAdService = customerAdService;
        }
        [HttpPost("AddCustomerAd")]
        public IActionResult AddCustomerAd([FromBody] CustomerAdDetailsClass customerAdDetailsClass)
        {
            _customerAdService.AddCustomerAd(customerAdDetailsClass);
            return Ok("Inserted Successfully");
        }
        [HttpPut("UpdateCustomerAd")]
        public IActionResult UpdateCustomerAd([FromBody] CustomerAdDetailsClass customerAdDetailsClass)
        {
            _customerAdService.UpdateCustomerAd(customerAdDetailsClass);
            return Ok("Updated Successfully");
        }
        [HttpDelete("DeleteCustomerAd")]
        public IActionResult DeleteCustomerAd(int AdCode)
        {
            _customerAdService.DeleteCustomerAd(AdCode);
            return Ok("Deleted Successfully");
        }
        [HttpGet("GetCustomerAdDetails")]
        public IEnumerable<CustomerAdDetailsClass> GetCustomerAdDetails()
        {
            return _customerAdService.GetCustomerAdDetails();
        }
        [HttpGet("GetCustomerAdDetailsByID")]
        public CustomerAdDetailsClass GetCustomerAdDetailsByID(int AdCode)
        {
            return _customerAdService.GetCustomerAdDetailsByID(AdCode);
        }
    }
}
