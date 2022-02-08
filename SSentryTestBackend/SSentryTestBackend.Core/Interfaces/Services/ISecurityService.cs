using SSentryTestBackend.Core.Entities;
using System.Threading.Tasks;

namespace SSentryTestBackend.Core.Interfaces.Services
{
    public interface ISecurityService
    {
        Task<Security> GetLoginByCredentials(UserLogin userLogin);
        Task RegisterUser(Security security);
    }
}
