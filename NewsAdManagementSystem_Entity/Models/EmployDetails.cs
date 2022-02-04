using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewsAdManagementSystem_Entity.Models
{
    public class EmployDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpContactNo { get; set; }
        public string EmailID { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Pwd { get; set; }
        public string Role { get; set; }
    }
}
