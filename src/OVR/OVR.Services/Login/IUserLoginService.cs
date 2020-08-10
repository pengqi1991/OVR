using OVR.Entities;
using OVR.WebCore.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OVR.Services.Login
{
    public interface IUserLoginService : IBaseService
    {
         Task<TData<UserLogin>> CheckLogin(string userName, string password);
    }
}
