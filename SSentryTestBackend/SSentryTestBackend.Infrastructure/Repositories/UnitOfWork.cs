using SSentryTestBackend.Core.Interfaces;
using SSentryTestBackend.Core.Interfaces.Repository;
using SSentryTestBackend.Infrastructure.Data;
using System.Threading.Tasks;

namespace SSentryTestBackend.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SSentryTestContext _context;
        private readonly ICompanyRepository _companyRepository;
        private readonly ITypeIdentificationRepository _typeIdentificationRepository;
        private readonly ISecurityRepository _securityRepository;

        public UnitOfWork(SSentryTestContext context)
        {
            _context = context;
        }
        public ICompanyRepository CompanyRepository => _companyRepository ?? new CompanyRepository(_context);
        public ITypeIdentificationRepository IdentificationTypeRepository => _typeIdentificationRepository ?? new IdentificationTypeRepository(_context);
        public ISecurityRepository SecurityRepository => _securityRepository ?? new SecurityRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
