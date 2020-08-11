using AutoMapper;
using OVR.Common.IDCode.Snowflake;
using OVR.DbContexts;
using OVR.Entities;
using OVR.UnitOfWork.UnitOfWork;
using OVR.WebCore.Core;
using System;
using OVR.Common.Extensions;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Internal;
using System.Linq;


namespace OVR.Services.Login
{
    public class UserLoginService : BaseService, IUserLoginService
    {

        public UserLoginService(IUnitOfWork<MSDbContext> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
        public async Task<TData<UserLogin>> CheckLogin(string userName, string password)
        {
            TData<UserLogin> obj = new TData<UserLogin>();
            if (userName.IsEmpty() || password.IsEmpty())
            {
                obj.Message = "用户名或密码不能为空";
                return obj;
            }

            
            UserLogin userLogin = await _unitOfWork.GetRepository<UserLogin>().GetFirstOrDefaultAsync( r=> r.Account == userName,null,null,true,false);
            if (userLogin != null)
            {
              
                    if (userLogin.Password == password)
                    {
                        
                        obj.Data = userLogin;
                        obj.Message = "登录成功";
                        obj.Tag = 1;
                    }
                    else
                    {
                        obj.Message = "密码不正确，请重新输入";
                    }
               
            }
            else
            {
                obj.Message = "账号不存在，请重新输入";
            }
            return obj;
        }
    }
}
