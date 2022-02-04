using Microsoft.EntityFrameworkCore;
using NewsAdManagementSystem_DAL.Data;
using NewsAdManagementSystem_Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsAdManagementSystem_DAL.Repository
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        private readonly ConnectionString _connection;
        public AdvertisementRepository(ConnectionString connection)
        {
            _connection = connection;
        }
        public void AddAdvertisement(AdvertisementDetailsClass advertisementDetailsClass)
        {
            _connection.AdvertisementDetails.Add(advertisementDetailsClass);
            _connection.SaveChanges();
        }

        public void DeleteAdvertisement(int AdCode)
        {
            var advertisementDetailsClass = _connection.AdvertisementDetails.Find(AdCode);
            _connection.AdvertisementDetails.Remove(advertisementDetailsClass);
            _connection.SaveChanges();
        }

        public IEnumerable<AdvertisementDetailsClass> GetAdvertisementDetails()
        {
           return _connection.AdvertisementDetails.ToList();
        }

        public AdvertisementDetailsClass GetAdvertisementDetailsByID(int AdCode)
        {
            return _connection.AdvertisementDetails.Find(AdCode);
        }

        public void UpdateAdvertisement(AdvertisementDetailsClass advertisementDetailsClass)
        {
            _connection.Entry(advertisementDetailsClass).State = EntityState.Modified;
            //_connection.AdvertisementDetails.Update(advertisementDetailsClass);
            _connection.SaveChanges();
        }
    }
}
