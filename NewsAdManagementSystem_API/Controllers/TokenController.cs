using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NewsAdManagementSystem_DAL.Data;
using NewsAdManagementSystem_Entity.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NewsAdManagementSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly ConnectionString _connection;

        public TokenController(IConfiguration config, ConnectionString connection)
        {
            _configuration = config;
            _connection = connection;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Post(EmployDetails _employDetails)
        {

            if (_employDetails != null && _employDetails.EmailID != null && _employDetails.Pwd != null)
            {
                var user = await GetUser(_employDetails.EmailID, _employDetails.Pwd);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("EmpID", user.EmpID.ToString()),
                    new Claim("EmpName", user.EmpName),
                    new Claim("EmailID", user.EmailID),
                    new Claim("EmpContactNo", user.EmpContactNo),
                    new Claim("Country", user.Country),
                    new Claim("State", user.State),
                    new Claim("City", user.City),
                      new Claim("Pwd", user.Pwd),
                        new Claim("Role", user.Role),
                   };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<EmployDetails> GetUser(string EmailID, string Pwd)
        {
            EmployDetails employDetails = null;
            var result = _connection.EmployeeDetails.Where(u => u.EmailID == EmailID && u.Pwd == Pwd);
            foreach (var item in result)
            {
                employDetails = new EmployDetails();
                employDetails.EmpID = item.EmpID;
                employDetails.EmpName = item.EmpName;
                employDetails.EmailID = item.EmailID;
                employDetails.EmpContactNo = item.EmpContactNo;
                employDetails.Country = item.Country;
                employDetails.State = item.State;
                employDetails.City = item.City;
                employDetails.Pwd = item.Pwd;
                employDetails.Role = item.Role;
            }
            return employDetails;

        }
    }
}
