using Microsoft.EntityFrameworkCore;
using OVR.IRepository;
using OVR.Model.Auth;
using OVR.Model.EFCore;
using OVR.Model.Param;
using OVR.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OVR.Repository
{
    public class MenuRepository : BaseRepository<MenuEntity>, IMenuRepository
    {
        public MenuRepository(IBaseContext mydbcontext) : base(mydbcontext)
        {

        }

        public Task<List<MenuEntity>> GetMenusOrderBy(Expression<Func<MenuEntity, bool>> expression, MenuListParam param)
        {
            return base.Db.MenuEntitys.Where(expression).OrderBy(p => p.MenuSort).ToListAsync();
        }
    }
}
