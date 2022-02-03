﻿using NewsAdManagementSystem_Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsAdManagementSystem_DAL.Repository
{
     public interface ICustomerRepository
    {
        void AddCustomer(CustomerDetailsClass customerDetailsClass);
        void UpdateCustomer(CustomerDetailsClass customerDetailsClass);
        void DeleteCustomer(int CustID);
        CustomerDetailsClass GetCustomerDetailsByID(int CustID);
        IEnumerable<CustomerDetailsClass> GetCustomerDetails();
        
        
    }
}
