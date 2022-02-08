using SSentryTestBackend.Core.Entities;
using System.Threading.Tasks;

namespace SSentryTestBackend.Core.Interfaces.Services
{
    public interface ICompanyService
    {
        Task<Company> GetCompanyByIdentification(int id);
        Task<bool> UpdateCompany(Company entity);
    }
}
