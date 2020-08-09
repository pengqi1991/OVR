using OVR.IServices.Base;
using OVR.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OVR.IServices
{
    public interface IAdvertisementServices : IBaseServices<Advertisement>
    {
        Task<List<Advertisement>> ReadAllAd();
    }
}
