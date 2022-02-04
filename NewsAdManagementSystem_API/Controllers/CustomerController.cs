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
    public class CustomerController : ControllerBase
    {
        private CustomerService  _customerService;
        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost("AddCustomer")]
        public IActionResult AddCustomer([FromBody] CustomerDetailsClass customerDetailsClass)
        {
            _customerService.AddCustomer(customerDetailsClass);
            return Ok("Inserted Successfully");
        }
        [HttpPut("UpdateCustomer")]
        public IActionResult UpdateCustomer([FromBody] CustomerDetailsClass customerDetailsClass)
        {
            _customerService.UpdateCustomer(customerDetailsClass);
            return Ok("Updated Successfully");
        }
        [HttpDelete("DeleteCustomer")]
        public IActionResult DeleteCustomer(int CustID)
        {
            _customerService.DeleteCustomer(CustID);
            return Ok("Deleted Successfully");
        }
        [HttpGet("GetCustomerDetails")]
        public IEnumerable<CustomerDetailsClass> GetCustomerDetails()
        {
            return _customerService.GetCustomerDetails();
        }
        [HttpGet("GetCustomerDetailsByID")]
        public CustomerDetailsClass GetCustomerDetailsByID(int CustID)
        {
            return _customerService.GetCustomerDetailsByID(CustID);
        }
    }
}

