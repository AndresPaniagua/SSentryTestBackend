using Microsoft.EntityFrameworkCore;
using SSentryTestBackend.Core.Entities;
using SSentryTestBackend.Core.Interfaces.Repository;
using SSentryTestBackend.Infrastructure.Data;
using System.Threading.Tasks;

namespace SSentryTestBackend.Infrastructure.Repositories
{
    public class SecurityRepository : BaseRepository<Security>, ISecurityRepository
    {
        public SecurityRepository(SSentryTestContext context) : base(context) { }

        public async Task<Security> GetLoginByCredentials(UserLogin login)
        {
            return await _entities.FirstOrDefaultAsync(s => s.User == login.User);
        }
    }
}
