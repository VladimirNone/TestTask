using System.Threading.Tasks;
using Abp.Application.Services;
using ForInterview.Authorization.Accounts.Dto;

namespace ForInterview.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
