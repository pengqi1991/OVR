using OVR.IRepository;
using OVR.Model.EFCore;
using OVR.Model.Models;
using OVR.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace OVR.Repository
{
    public class AdvertisementRepository : BaseRepository<Advertisement>, IAdvertisementRepository
    {
        public AdvertisementRepository(IBaseContext mydbcontext) : base(mydbcontext)
        {

        }
    }
}
