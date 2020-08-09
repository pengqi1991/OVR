using OVR.IRepository.Base;
using OVR.Model.Auth;
using OVR.Model.Param;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OVR.IRepository
{
    public interface IMenuRepository : IBaseRepository<MenuEntity>
    {
        Task<List<MenuEntity>> GetMenusOrderBy(Expression<Func<MenuEntity, bool>> expression, MenuListParam param);
       
    }
}
