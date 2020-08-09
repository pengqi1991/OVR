using OVR.IServices.Base;
using OVR.Model.Auth;
using OVR.Model.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OVR.IServices
{
    public interface IMenuAuthorizeServices : IBaseServices<MenuAuthorizeEntity>
    {

        Task<TData<List<MenuAuthorizeInfo>>> GetAuthorizeList(OperatorInfo user);
    }
}
