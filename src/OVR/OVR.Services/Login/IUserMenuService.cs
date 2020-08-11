using OVR.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OVR.Services.Login
{
    public interface IUserMenuService : IBaseService
    {
        Task<List<long>> GetUserMenuIdList(UserLogin user);
    }
}
