using SSentryTestBackend.Core.Entities;
using System.Threading.Tasks;

namespace SSentryTestBackend.Core.Interfaces.Repository
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<Company> GetCompanyByIdentification(int id);
    }
}
