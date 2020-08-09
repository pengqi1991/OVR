using OVR.IServices.Base;
using OVR.Model;
using OVR.Model.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OVR.IServices
{
    public interface IUserEntityServices : IBaseServices<UserEntity>
    {

        Task<OperatorInfo> GetUserByToken(string token);
    }
}
