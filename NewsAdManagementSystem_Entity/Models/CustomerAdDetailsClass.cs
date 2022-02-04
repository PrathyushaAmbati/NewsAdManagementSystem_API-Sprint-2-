using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NewsAdManagementSystem_Entity.Models
{
    public class CustomerAdDetailsClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SNo { get; set; }

        public EmployDetails EmployeeDetails { get; set; }
        [ForeignKey("EmpID")]
        public  int EmpID { get; set; }

        public CustomerDetailsClass CustomerDetails { get; set; }
        [ForeignKey("CustID")]
        public int CustID { get; set; }

        public AdvertisementDetailsClass advertisementDetails { get; set; }
        [ForeignKey("AdCode")]
        public int AdCode { get; set; }
        public DateTime DOI { get; set; }
        public DateTime DOP { get; set; }
        public int UnitCost { get; set; }
        public int AdvtSizesqcm { get; set; }
        public int TotalCost { get; set; }
        public string PageStatus { get; set; }


    }
}
