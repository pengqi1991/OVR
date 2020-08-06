using OVR.IRepository;
using OVR.IRepository.Base;
using OVR.IServices;
using OVR.Model.Models;
using OVR.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OVR.Services
{
    public class AdvertisementServices : BaseServices<Advertisement>, IAdvertisementServices
    {
        IAdvertisementRepository _advertisementRepository;
        public AdvertisementServices(IBaseRepository<Advertisement> baseRepository)
        {
            base.BaseDal = baseRepository;
            _advertisementRepository = baseRepository as IAdvertisementRepository;
        }
        public Task<List<Advertisement>> ReadAllAd()
        {

            return BaseDal.GetList();
        }
    }
}
