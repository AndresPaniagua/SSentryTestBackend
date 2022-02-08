using SSentryTestBackend.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSentryTestBackend.Core.Interfaces.Repository
{
    public interface ITypeIdentificationRepository : IRepository<IdentificationType>
    {
        Task<List<IdentificationType>> GetIdentificationTypes();
    }
}
