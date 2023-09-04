using System.Threading.Tasks;
using Abp.Application.Services;
using Movie.Authorization.Accounts.Dto;

namespace Movie.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
