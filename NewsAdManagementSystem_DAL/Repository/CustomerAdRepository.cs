using NewsAdManagementSystem_DAL.Data;
using NewsAdManagementSystem_Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsAdManagementSystem_DAL.Repository
{
    public class CustomerAdRepository : ICustomerAdRepository
    {
        ConnectionString _connection;
        public CustomerAdRepository(ConnectionString connection)
        {
            _connection = connection;
        }
        public void AddCustomerAd(CustomerAdDetailsClass customerAdDetailsClass)
        {
            _connection.CustomerAdDetails.Add(customerAdDetailsClass);
            _connection.SaveChanges();
        }

        public void DeleteCustomerAd(int SNo)
        {
            var customerAdDetails = _connection.CustomerAdDetails.Find(SNo);
            _connection.CustomerAdDetails.Remove(customerAdDetails);
            _connection.SaveChanges();
        }

        public IEnumerable<CustomerAdDetailsClass> GetCustomerAdDetails()
        {
            return _connection.CustomerAdDetails.ToList();
        }

        public CustomerAdDetailsClass GetCustomerAdDetailsByID(int SNo)
        {
            return _connection.CustomerAdDetails.Find(SNo);
        }

        public void UpdateCustomerAd(CustomerAdDetailsClass customerAdDetailsClass)
        {
            _connection.CustomerAdDetails.Update(customerAdDetailsClass);
            _connection.SaveChanges();
        }
    }
}
