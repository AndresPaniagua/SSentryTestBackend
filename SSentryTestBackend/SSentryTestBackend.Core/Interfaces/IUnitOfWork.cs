using SSentryTestBackend.Core.Interfaces.Repository;
using System;
using System.Threading.Tasks;

namespace SSentryTestBackend.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICompanyRepository CompanyRepository { get; }
        ITypeIdentificationRepository IdentificationTypeRepository { get; }
        ISecurityRepository SecurityRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
