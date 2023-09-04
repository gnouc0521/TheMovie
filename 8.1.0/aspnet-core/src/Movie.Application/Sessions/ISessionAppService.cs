using System.Threading.Tasks;
using Abp.Application.Services;
using Movie.Sessions.Dto;

namespace Movie.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
