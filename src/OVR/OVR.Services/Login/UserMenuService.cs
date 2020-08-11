using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OVR.DbContexts;
using OVR.Entities;
using OVR.UnitOfWork.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OVR.Services.Login
{
    
    public class UserMenuService : BaseService, IUserMenuService
    {

        public UserMenuService(IUnitOfWork<MSDbContext> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
        public async Task<List<long>> GetUserMenuIdList(UserLogin user)
        {
            return await _unitOfWork.DbContext.UserMenus.Select(p => p.SysMenuId).ToListAsync();

        }
    }
}
