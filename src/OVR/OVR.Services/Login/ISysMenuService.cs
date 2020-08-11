using OVR.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OVR.Services.Login
{
    

    public interface ISysMenuService : IBaseService
    {
        Task<IList<SysMenu>> GetAll();
    }
}
