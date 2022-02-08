using SSentryTestBackend.Core.Entities;
using System.Threading.Tasks;

namespace SSentryTestBackend.Core.Interfaces.Repository
{
    public interface ISecurityRepository : IRepository<Security>
    {
        Task<Security> GetLoginByCredentials(UserLogin login);
    }
}
