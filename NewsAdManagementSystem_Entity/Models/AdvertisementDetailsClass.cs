using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewsAdManagementSystem_Entity.Models
{
    public class AdvertisementDetailsClass
    {
        [Key]     
        public int AdCode { get; set; }
        public int PageNo { get; set; }
        public string PageLocation { get; set; }
        public int BWColorCost{ get; set; }
        public int ColorCost { get; set; }
        public string Title { get; set; }
    }
}
