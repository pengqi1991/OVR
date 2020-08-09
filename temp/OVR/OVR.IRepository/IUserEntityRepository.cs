using OVR.IRepository.Base;
using OVR.Model;
using OVR.Model.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OVR.IRepository
{
    public interface IUserEntityRepository : IBaseRepository<UserEntity>
    {
        Task<OperatorInfo> GetOperatorInfo(string token);
    }
}
