using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NewsAdManagementSystem_Entity.Models
{
    public class CustomerDetailsClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustID { get; set; }
        public string CustName { get; set; }

        public string EmailID { get; set; }
        public string CustAddress { get; set; }
        public string CustContactNo { get; set; }
        public DateTime DOR { get; set; }
        public string Pwd { get; set; }
    }
}
