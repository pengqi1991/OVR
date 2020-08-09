using OVR.IRepository;
using OVR.IRepository.Base;
using OVR.IServices;
using OVR.Model;
using OVR.Model.Auth;
using OVR.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OVR.Services
{
   
    public class UserEntityServices : BaseServices<UserEntity>, IUserEntityServices
    {
        private readonly IUserBelongEntityRepository _IUserBelongEntityRepository;
        IUserEntityRepository _UserEntityRepository;
        public UserEntityServices(IBaseRepository<UserEntity> baseRepository, IBaseRepository<UserBelongEntity> iUserBelongEntityRepository )
        {
            base.BaseDal = baseRepository;
            _UserEntityRepository = baseRepository as IUserEntityRepository;
            this._IUserBelongEntityRepository = iUserBelongEntityRepository as IUserBelongEntityRepository;
        }

        public async Task<OperatorInfo> GetUserByToken(string token)
        {
            var operatorInfo = await _UserEntityRepository.GetOperatorInfo(token);
            if (operatorInfo != null)
            {
                #region 角色
                

                
                IEnumerable<RoleInfo> roleList = await _IUserBelongEntityRepository.GetRoleInfos(operatorInfo.UserId.Value);
                operatorInfo.RoleIds = string.Join(",", roleList.Select(p => p.RoleId).ToArray());
                #endregion

                
            }
            return operatorInfo;
        }


    }
}
