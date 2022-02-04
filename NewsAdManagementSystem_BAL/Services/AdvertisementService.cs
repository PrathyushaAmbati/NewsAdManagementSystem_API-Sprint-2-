using NewsAdManagementSystem_DAL.Repository;
using NewsAdManagementSystem_Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsAdManagementSystem_BAL.Services
{
    public class AdvertisementService
    {
        IAdvertisementRepository _iAdvertisementRepository;
        public AdvertisementService(IAdvertisementRepository advertisementRepository)
        {
            _iAdvertisementRepository = advertisementRepository;
        }
        public void AddAdvertisement(AdvertisementDetailsClass advertisementDetailsClass )
        {
            _iAdvertisementRepository.AddAdvertisement(advertisementDetailsClass);
        }
        public void UpdateAdvertisement(AdvertisementDetailsClass advertisementDetailsClass)
        {
            _iAdvertisementRepository.UpdateAdvertisement(advertisementDetailsClass);
        }
        public void DeleteAdvertisement(int AdCode)
        {
            _iAdvertisementRepository.DeleteAdvertisement(AdCode);
        }
        public AdvertisementDetailsClass GetAdvertisementDetailsByID(int AdCode)
        {
           return _iAdvertisementRepository.GetAdvertisementDetailsByID(AdCode);
        }
        public IEnumerable<AdvertisementDetailsClass> GetAdvertisementDetails()
        {
            return _iAdvertisementRepository.GetAdvertisementDetails();
        }
    }
}
