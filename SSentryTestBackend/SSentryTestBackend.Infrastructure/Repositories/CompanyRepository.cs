using Microsoft.EntityFrameworkCore;
using SSentryTestBackend.Core.Entities;
using SSentryTestBackend.Core.Interfaces.Repository;
using SSentryTestBackend.Infrastructure.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SSentryTestBackend.Infrastructure.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(SSentryTestContext context) : base(context) { }
        public async Task<Company> GetCompanyByIdentification(int id)
        {
            return await _entities.Where(c => c.IdentificationNumber == id.ToString()).FirstOrDefaultAsync();
        }
    }
}
