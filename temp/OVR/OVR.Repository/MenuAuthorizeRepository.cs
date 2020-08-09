using OVR.Common;
using OVR.Common.Helper;
using OVR.IRepository;
using OVR.Model.Auth;
using OVR.Model.EFCore;
using OVR.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OVR.Repository
{
    public class MenuAuthorizeRepository : BaseRepository<MenuAuthorizeEntity>, IMenuAuthorizeRepository
    {
        public MenuAuthorizeRepository(IBaseContext mydbcontext) : base(mydbcontext)
        {

        }

        public async Task<List<MenuAuthorizeEntity>> GetListByMenuAuthorize(MenuAuthorizeEntity param)
        {
            var expression = LinqExtensions.True<MenuAuthorizeEntity>();
            if (param != null)
            {
                if (param.AuthorizeId.Value > 0)
                {
                    expression = expression.And(t => t.AuthorizeId == param.AuthorizeId);
                }
                if (param.AuthorizeType.Value > 0)
                {
                    expression = expression.And(t => t.AuthorizeType == param.AuthorizeType);
                }
                if (! string.IsNullOrEmpty( param.AuthorizeIds))
                {
                    int[] authorizeIdArr = TextHelper.SplitToArray<int>(param.AuthorizeIds, ',');
                    expression = expression.And(t => authorizeIdArr.Contains(t.AuthorizeId.Value));
                }
            }
            return await GetListBy(expression);
                
             
        }
    }
}
