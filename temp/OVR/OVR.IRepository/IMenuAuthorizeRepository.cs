using OVR.IRepository.Base;
using OVR.Model.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OVR.IRepository
{
    public interface IMenuAuthorizeRepository : IBaseRepository<MenuAuthorizeEntity>
    {

        Task<List<MenuAuthorizeEntity>> GetListByMenuAuthorize(MenuAuthorizeEntity param);
    }
}
