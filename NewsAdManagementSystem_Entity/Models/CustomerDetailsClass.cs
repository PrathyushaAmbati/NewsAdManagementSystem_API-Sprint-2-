﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewsAdManagementSystem_Entity.Models
{
    public class CustomerDetailsClass
    {
        [Key]
        public int CustID { get; set; }
        public string CustName { get; set; }
        public string CustAddress { get; set; }
        public string CustContactNo { get; set; }
        public DateTime DOR { get; set; }
    }
}
