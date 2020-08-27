using System.Threading.Tasks;
using Abp.Application.Services;
using ForInterview.Sessions.Dto;

namespace ForInterview.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
