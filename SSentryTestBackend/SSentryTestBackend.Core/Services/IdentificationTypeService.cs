using SSentryTestBackend.Core.Entities;
using SSentryTestBackend.Core.Interfaces;
using SSentryTestBackend.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSentryTestBackend.Core.Services
{
    public class IdentificationTypeService : ITypeIdentificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public IdentificationTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<IdentificationType>> GetIdentificationTypes()
        {
            return await _unitOfWork.IdentificationTypeRepository.GetIdentificationTypes();
        }
    }
}
