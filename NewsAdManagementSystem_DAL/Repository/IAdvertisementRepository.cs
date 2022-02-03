using NewsAdManagementSystem_Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsAdManagementSystem_DAL.Repository
{
    public interface IAdvertisementRepository
    {
        void AddAdvertisement(AdvertisementDetailsClass advertisementDetailsClass);
        void UpdateAdvertisement(AdvertisementDetailsClass advertisementDetailsClass);
        void DeleteAdvertisement(int AdCode);
        AdvertisementDetailsClass GetAdvertisementDetailsByID(int AdCode);
        IEnumerable<AdvertisementDetailsClass> GetAdvertisementDetails();
    }
}
