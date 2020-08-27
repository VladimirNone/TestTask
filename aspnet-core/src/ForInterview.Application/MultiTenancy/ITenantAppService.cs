using Abp.Application.Services;
using ForInterview.MultiTenancy.Dto;

namespace ForInterview.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

