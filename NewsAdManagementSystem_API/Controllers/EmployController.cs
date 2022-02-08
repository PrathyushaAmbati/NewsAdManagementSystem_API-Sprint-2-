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
    public class EmployController : ControllerBase
    {
        private  EmployService _employService;
        public EmployController(EmployService employService)
        {
            _employService = employService;
        }
        [HttpPost("AddEmploy")]
        public IActionResult AddEmploy([FromBody]EmployDetails employDetails)
        {
            _employService.AddEmploy(employDetails);
            return Ok("Inserted Successfully");
        }
        [HttpPut("UpdateEmploy")]
        public IActionResult UpdateEmploy( [FromBody]EmployDetails employDetails)
        {
            _employService.UpdateEmploy(employDetails);
            return Ok("Updated Successfully");
        }
        [HttpDelete("DeleteEmploy")]
        public IActionResult DeleteEmploy(int EmpID)
        {
            _employService.DeleteEmploy(EmpID);
            return Ok("Deleted Successfully");
        }
        [HttpGet("GetEmployDetails")]
        public  IEnumerable<EmployDetails> GetEmployDetails()
        {
            return _employService.GetEmployDetails();            
        }
        [HttpGet("GetEmployDetailsByID")]
        public EmployDetails GetEmployDetailsByID(int EmpID)
        {
            return _employService.GetEmployDetailsByID(EmpID);
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] EmployDetails employDetails)
        {
            //EmployDetails employ = _employService.Login(employDetails);
            if (employDetails != null)
                return Ok("Login success!!");
            else
                return NotFound();
        }




    }
}
