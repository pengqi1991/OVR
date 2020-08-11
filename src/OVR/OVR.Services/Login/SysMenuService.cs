using AutoMapper;
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
    public class SysMenuService : BaseService, ISysMenuService
    {
        public SysMenuService(IUnitOfWork<MSDbContext> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {      
        }
        public async Task<IList<SysMenu>> GetAll()
        {
           return  await _unitOfWork.GetRepository<SysMenu>().GetAllAsync( null,q=>q.OrderBy(s => s.MenuSort) );
        }

    }
}
