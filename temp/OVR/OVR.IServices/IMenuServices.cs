using OVR.IServices.Base;
using OVR.Model.Auth;
using OVR.Model.Param;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OVR.IServices
{
    public interface IMenuServices : IBaseServices<MenuEntity>
    {
        Task<List<MenuEntity>> FindList();
    }
}
