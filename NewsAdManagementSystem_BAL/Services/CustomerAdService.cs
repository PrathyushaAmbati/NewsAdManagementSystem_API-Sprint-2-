using NewsAdManagementSystem_DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using NewsAdManagementSystem_Entity.Models;

namespace NewsAdManagementSystem_BAL.Services
{
    public class CustomerAdService
    {
        ICustomerAdRepository _iCustomerAdRepository;
        public CustomerAdService(ICustomerAdRepository iCustomerAdRepository)
        {
            _iCustomerAdRepository = iCustomerAdRepository;
        }
        public void AddCustomerAd(CustomerAdDetailsClass customerAdDetailsClass)
        {
            _iCustomerAdRepository.AddCustomerAd(customerAdDetailsClass);
        }
        public void UpdateCustomerAd(CustomerAdDetailsClass customerAdDetailsClass)
        {
            _iCustomerAdRepository.UpdateCustomerAd(customerAdDetailsClass);
        }
        public void DeleteCustomerAd(int SNo)
        {
            _iCustomerAdRepository.DeleteCustomerAd(SNo);
        }
        public void GetCustomerAdDetailsByID(int SNo)
        {
            _iCustomerAdRepository.GetCustomerAdDetailsByID(SNo);
        }
        public void GetCustomerAdDetails()
        {
            _iCustomerAdRepository.GetCustomerAdDetails();
        }
    }
}
