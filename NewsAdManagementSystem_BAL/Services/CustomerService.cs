using NewsAdManagementSystem_DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using NewsAdManagementSystem_Entity.Models;
using NewsAdManagementSystem_DAL.Repository.CustomerDetails;

namespace NewsAdManagementSystem_BAL.Services
{
    public class CustomerService
    {
        ICustomerRepository _iCustomerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _iCustomerRepository = customerRepository;
        }
        public void AddCustomer(CustomerDetailsClass customerDetailsClass)
        {
            _iCustomerRepository.AddCustomer(customerDetailsClass);
        }
        public void UpdateCustomer(CustomerDetailsClass customerDetailsClass)
        {
            _iCustomerRepository.UpdateCustomer(customerDetailsClass);
        }
        public void DeleteCustomer(int CustID)
        {
            _iCustomerRepository.DeleteCustomer(CustID);
        }
        public CustomerDetailsClass GetCustomerDetailsByID(int CustID)
        {
           return _iCustomerRepository.GetCustomerDetailsByID(CustID);
        }
        public IEnumerable<CustomerDetailsClass> GetCustomerDetails()
        {
           return _iCustomerRepository.GetCustomerDetails();
        }

        public CustomerDetailsClass Login(CustomerDetailsClass customerDetailsClass)
        {
            return _iCustomerRepository.Login(customerDetailsClass);
        }
    }


}
