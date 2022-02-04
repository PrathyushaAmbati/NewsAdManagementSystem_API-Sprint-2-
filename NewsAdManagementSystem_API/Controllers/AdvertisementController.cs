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
    public class AdvertisementController : ControllerBase
    {
        private readonly AdvertisementService _advertisementService;
        public AdvertisementController(AdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
        }
        [HttpPost("AddAdvertisement")]
        public IActionResult AddAdvertisement([FromBody] AdvertisementDetailsClass advertisementDetailsclass)
        {
            _advertisementService.AddAdvertisement(advertisementDetailsclass);
            return Ok("Inserted Successfully");

        }
        [HttpPut("UpdateAdvertisement")]
        public IActionResult UpdateAdvertisement([FromBody] AdvertisementDetailsClass advertisementDetailsclass)
        {
            _advertisementService.UpdateAdvertisement(advertisementDetailsclass);
            return Ok("Updated Successfully");
        }
        [HttpDelete("DeleteAdvertisement")]
        public IActionResult DeleteAdvertisement(int AdCode)
        {
            _advertisementService.DeleteAdvertisement(AdCode);
            return Ok("Deleted Successfully");
        }
        [HttpGet("GetAdvertisementDetailsByID")]
        public AdvertisementDetailsClass GetAdvertisementDetailsByID(int AdCode)
        {
            return _advertisementService.GetAdvertisementDetailsByID(AdCode);
        }
        [HttpGet("GetAdvertisementDetails")]
        public IEnumerable<AdvertisementDetailsClass> GetAdvertisementDetails()
        {
            return _advertisementService.GetAdvertisementDetails();
        }
    }
}
