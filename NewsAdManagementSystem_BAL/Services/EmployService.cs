using NewsAdManagementSystem_DAL.Repository;
using NewsAdManagementSystem_Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsAdManagementSystem_BAL.Services
{
    public class EmployService
    {
        IEmployRepository _iEmployRepository;
        public EmployService(IEmployRepository employRepository)
        {
            _iEmployRepository = employRepository;
        }
        public void AddEmploy(EmployDetails employDetails )
        {
            _iEmployRepository.AddEmploy(employDetails);
        }
        public void UpdateEmploy(EmployDetails employDetails)
        {
            _iEmployRepository.UpdateEmploy(employDetails);
        }
        public void DeleteEmploy(int EmpID)
        {
            _iEmployRepository.DeleteEmploy(EmpID);
        }
        public EmployDetails GetEmployDetailsByID(int EmpID)
        {
            return _iEmployRepository.GetEmployDetailsByID(EmpID);
        }
        public IEnumerable<EmployDetails> GetEmployDetails()
        {
            return _iEmployRepository.GetEmployDetails();
        }
    }
}
