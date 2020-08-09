using OVR.Common;
using OVR.Common.Cache;
using OVR.IRepository;
using OVR.IRepository.Base;
using OVR.IServices;
using OVR.Model.Auth;
using OVR.Model.Param;
using OVR.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OVR.Services
{
    public class MenuServices : BaseServices<MenuEntity>, IMenuServices
    {
        IMenuRepository _MenuRepository;
        public MenuServices(IBaseRepository<MenuEntity> baseRepository)
        {
            base.BaseDal = baseRepository;
            _MenuRepository = baseRepository as IMenuRepository;
        }
        public const string CacheKey = "MenuServices";
        public async Task<List<MenuEntity>> FindList()
        {


            var cacheList = CacheFactory.Cache.GetCache<List<MenuEntity>>(CacheKey);
            if (cacheList == null)
            {
                var list = await _MenuRepository.GetList();
               
                CacheFactory.Cache.SetCache(CacheKey, list);
                return list;
            }
            else
            {
                return cacheList;
            }



           
            
        }

        private Expression<Func<MenuEntity, bool>> ListFilter(MenuListParam param)
        {
            var expression = LinqExtensions.True<MenuEntity>();
            if (param != null)
            {
                if (!string.IsNullOrEmpty(param.MenuName))
                {
                    expression = expression.And(t => t.MenuName.Contains(param.MenuName));
                }
                if (param.MenuStatus > -1)
                {
                    expression = expression.And(t => t.MenuStatus == param.MenuStatus);
                }
            }
            return expression;
        }
    }
}
