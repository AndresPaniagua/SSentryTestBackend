using SSentryTestBackend.Core.Entities;
using SSentryTestBackend.Core.Exceptions;
using SSentryTestBackend.Core.Interfaces;
using SSentryTestBackend.Core.Interfaces.Services;
using System.Threading.Tasks;

namespace SSentryTestBackend.Core.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Company> GetCompanyByIdentification(int id)
        {
            if (id == 900674335)
            {
                throw new BussinesException("La empresa con esta identificación no está habilitada para realizar el registro");
            }

            if (id != 900674336 && id != 811033098)
            {
                throw new BussinesException("La identificación de esta empresa no está registrada");
            }

            return await _unitOfWork.CompanyRepository.GetCompanyByIdentification(id);
        }

        public async Task<bool> UpdateCompany(Company entity)
        {
            var company = await _unitOfWork.CompanyRepository.GetById(entity.Id);
            company.CompanyName = entity.CompanyName;
            company.FirstName = entity.FirstName;
            company.SecondName = entity.SecondName;
            company.FirstLastName = entity.FirstLastName;
            company.SecondLastName = entity.SecondLastName;
            company.Email = entity.Email;
            company.AllowCellphoneMessages = entity.AllowCellphoneMessages;
            company.AllowEmailMessages = entity.AllowEmailMessages;
            company.IdentificationTypeId = entity.IdentificationTypeId;
            _unitOfWork.CompanyRepository.Update(company);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
