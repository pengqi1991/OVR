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
   
    public class UserEntityRepository : BaseRepository<UserEntity>, IUserEntityRepository
    {
        public UserEntityRepository(IBaseContext mydbcontext) : base(mydbcontext)
        {

        }

        public async Task<OperatorInfo> GetOperatorInfo(string token)
        {

            return await base.Db.UserEntitys.Select(p => new OperatorInfo
            {
                UserId = p.Id,
                UserStatus = p.UserStatus,
                IsOnline = p.IsOnline,
                UserName = p.UserName,
                RealName = p.RealName,
                Portrait = p.Portrait,
                DepartmentId = p.DepartmentId,
                WebToken = p.WebToken,
                IsSystem = p.IsSystem
            }).Where(r => r.WebToken == token).FirstOrDefaultAsync();
        }
    }
}
