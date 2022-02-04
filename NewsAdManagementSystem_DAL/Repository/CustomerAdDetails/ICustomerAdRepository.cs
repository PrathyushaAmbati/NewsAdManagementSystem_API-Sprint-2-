using NewsAdManagementSystem_Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsAdManagementSystem_DAL.Repository
{
   public interface ICustomerAdRepository
    {
        void AddCustomerAd(CustomerAdDetailsClass customerAdDetailsClass);
        void UpdateCustomerAd(CustomerAdDetailsClass customerAdDetailsClass);
        void DeleteCustomerAd(int SNo);
        CustomerAdDetailsClass GetCustomerAdDetailsByID(int SNo);
        IEnumerable<CustomerAdDetailsClass> GetCustomerAdDetails();
    }
}
