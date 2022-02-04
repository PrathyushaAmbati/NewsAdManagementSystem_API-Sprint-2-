using Microsoft.EntityFrameworkCore;
using NewsAdManagementSystem_DAL.Data;
using NewsAdManagementSystem_DAL.Repository.CustomerDetails;
using NewsAdManagementSystem_Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsAdManagementSystem_DAL.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        ConnectionString _connection;
        public CustomerRepository(ConnectionString connection)
        {
            _connection = connection;
        }

        public void AddCustomer(CustomerDetailsClass customerDetailsClass)
        {
            _connection.CustomerDetails.Add(customerDetailsClass);
            _connection.SaveChanges();
        }

        public void DeleteCustomer(int CustID)
        {
            var customerDetails = _connection.CustomerDetails.Find(CustID);
            _connection.CustomerDetails.Remove(customerDetails);
        }

        public IEnumerable<CustomerDetailsClass> GetCustomerDetails()
        {
            return _connection.CustomerDetails.ToList();
        }

        public CustomerDetailsClass GetCustomerDetailsByID(int CustID)
        {
            return _connection.CustomerDetails.Find(CustID);
        }

        public void UpdateCustomer(CustomerDetailsClass customerDetailsClass)
        {
            _connection.Entry(customerDetailsClass).State = EntityState.Modified;
            _connection.SaveChanges();
        }
    }
}
