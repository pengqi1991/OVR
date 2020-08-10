using OVR.Models.ViewModel;
using OVR.WebCore.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OVR.Services.RoleS
{
    public interface IRoleService : IBaseService
    {
        Task<ExecuteResult<OVR.Entities.Role>> Create(RoleViewModel viewModel);
        Task<ExecuteResult> Update(RoleViewModel viewModel);
        Task<ExecuteResult> Delete(RoleViewModel viewModel);
    }
}
