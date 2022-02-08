using Microsoft.EntityFrameworkCore;
using SSentryTestBackend.Core.Entities;
using SSentryTestBackend.Core.Interfaces.Repository;
using SSentryTestBackend.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSentryTestBackend.Infrastructure.Repositories
{
    public class IdentificationTypeRepository : BaseRepository<IdentificationType>, ITypeIdentificationRepository
    {
        public IdentificationTypeRepository(SSentryTestContext context) : base(context) { }

        public async Task<List<IdentificationType>> GetIdentificationTypes()
        {
            return await _entities.ToListAsync();
        }
    }
}
