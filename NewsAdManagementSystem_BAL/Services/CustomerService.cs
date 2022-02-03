using NewsAdManagementSystem_DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using NewsAdManagementSystem_Entity.Models;

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
        public void GetCustomerDetailsByID(int CustID)
        {
            _iCustomerRepository.GetCustomerDetailsByID(CustID);
        }
        public void GetCustomerDetails()
        {
            _iCustomerRepository.GetCustomerDetails();
        }
    }


}
