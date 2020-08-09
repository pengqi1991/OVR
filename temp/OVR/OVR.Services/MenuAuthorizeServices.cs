using OVR.Common.Cache;
using OVR.Common.Helper;
using OVR.IRepository;
using OVR.IRepository.Base;
using OVR.IServices;
using OVR.Model;
using OVR.Model.Auth;
using OVR.Model.Base;
using OVR.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OVR.Services
{
    public class MenuAuthorizeServices : BaseServices<MenuAuthorizeEntity>, IMenuAuthorizeServices
    {

        public const string CacheKey = "MenuAuthorizeCache";
        private readonly IMenuServices menuServices;
        IMenuAuthorizeRepository _IMenuAuthorizeRepository;
        public MenuAuthorizeServices(IBaseRepository<MenuAuthorizeEntity> baseRepository,IMenuServices menuServices)
        {
            base.BaseDal = baseRepository;
            _IMenuAuthorizeRepository = baseRepository as IMenuAuthorizeRepository;
            this.menuServices = menuServices;
        }

        public  async Task<List<MenuAuthorizeEntity>> GetMenuAuthorizeList()
        {
            var cacheList = CacheFactory.Cache.GetCache<List<MenuAuthorizeEntity>>(CacheKey);
            if (cacheList == null)
            {
                var list = await _IMenuAuthorizeRepository.GetListByMenuAuthorize(null);
                CacheFactory.Cache.SetCache(CacheKey, list);
                return list;
            }
            else
            {
                return cacheList;
            }
        }


        #region 获取数据
        public async Task<TData<List<MenuAuthorizeInfo>>> GetAuthorizeList(OperatorInfo user)
        {
            TData<List<MenuAuthorizeInfo>> obj = new TData<List<MenuAuthorizeInfo>>();
            obj.Data = new List<MenuAuthorizeInfo>();

            List<MenuAuthorizeEntity> authorizeList = new List<MenuAuthorizeEntity>();
            List<MenuAuthorizeEntity> userAuthorizeList = null;
            List<MenuAuthorizeEntity> roleAuthorizeList = null;

            var menuAuthorizeCacheList = await GetMenuAuthorizeList();
            var menuList = await menuServices.FindList();
            var enableMenuIdList = menuList.Where(p => p.MenuStatus == (int)StatusEnum.Yes).Select(p => p.Id).ToList();

            menuAuthorizeCacheList = menuAuthorizeCacheList.Where(p => enableMenuIdList.Contains(p.MenuId.Value)).ToList();

            // 用户
            userAuthorizeList = menuAuthorizeCacheList.Where(p => p.AuthorizeId == user.UserId && p.AuthorizeType.Value == AuthorizeTypeEnum.User.ObjToInt()).ToList();

            // 角色
            if (!string.IsNullOrEmpty(user.RoleIds))
            {
                List<long> roleIdList = user.RoleIds.Split(',').Select(p => long.Parse(p)).ToList();
                roleAuthorizeList = menuAuthorizeCacheList.Where(p => roleIdList.Contains(p.AuthorizeId.Value) && p.AuthorizeType == AuthorizeTypeEnum.Role.ObjToInt()).ToList();
            }

            // 排除重复的记录
            if (userAuthorizeList.Count > 0)
            {
                authorizeList.AddRange(userAuthorizeList);
                roleAuthorizeList = roleAuthorizeList.Where(p => !userAuthorizeList.Select(u => u.AuthorizeId).Contains(p.AuthorizeId)).ToList();
            }
            if (roleAuthorizeList != null && roleAuthorizeList.Count > 0)
            {
                authorizeList.AddRange(roleAuthorizeList);
            }

            foreach (MenuAuthorizeEntity authorize in authorizeList)
            {
                obj.Data.Add(new MenuAuthorizeInfo
                {
                    MenuId = authorize.MenuId,
                    AuthorizeId = authorize.AuthorizeId,
                    AuthorizeType = authorize.AuthorizeType,
                    Authorize = menuList.Where(t => t.Id == authorize.MenuId).Select(t => t.Authorize).FirstOrDefault()
                });
            }
            obj.Tag = 1;
            return obj;
        }
        #endregion
    }
}
