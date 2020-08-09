using Microsoft.EntityFrameworkCore;
using OVR.IRepository;
using OVR.Model;
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
   
    public class UserBelongEntityRepository : BaseRepository<UserBelongEntity>, IUserBelongEntityRepository
    {
        public UserBelongEntityRepository(IBaseContext mydbcontext) : base(mydbcontext)
        {

        }

        public Task<List<RoleInfo>> GetRoleInfos(int UserID)
        {
            return base.Db.UserBelongEntitys
                .Where(r => UserID  ==  r.UserId.Value )
                .Select(p => new RoleInfo
                {
                    RoleId = p.BelongId.Value
                }).ToListAsync();
        }
    }
}
