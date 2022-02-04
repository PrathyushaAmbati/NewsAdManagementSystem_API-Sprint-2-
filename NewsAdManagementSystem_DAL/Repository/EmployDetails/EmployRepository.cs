using NewsAdManagementSystem_DAL.Data;
using NewsAdManagementSystem_Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace NewsAdManagementSystem_DAL.Repository
{
   public class EmployRepository:IEmployRepository
    {
        ConnectionString _connection;
        public EmployRepository(ConnectionString connection )
        {
            _connection = connection;
        }

        public void AddEmploy(EmployDetails employDetails)
        {
            _connection.EmployeeDetails.Add(employDetails);
            _connection.SaveChanges();
        }

        public void DeleteEmploy(int EmpID)
        {
            var employDetails = _connection.EmployeeDetails.Find(EmpID);
            _connection.EmployeeDetails.Remove(employDetails);
            _connection.SaveChanges();
        }

        public IEnumerable<EmployDetails> GetEmployDetails()
        {
            return _connection.EmployeeDetails.ToList();
        }

        public EmployDetails GetEmployDetailsByID(int EmpID)
        {
            return _connection.EmployeeDetails.Find(EmpID);
        }

       

        public void UpdateEmploy(EmployDetails employDetails)
        {
            _connection.EmployeeDetails.Update(employDetails);
            _connection.SaveChanges();
        }
    }
}
