using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.CompanyDto;
using Teknosib.Business.Interface;
using Teknosib.Entity.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Teknosib.Business.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CompanyService> _logger;

        public CompanyService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CompanyService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseDto<CompanyDto>> CreateCompanyAsync(CreateCompanyDto createCompanyDto)
        {
            try
            {
                var company = await _unitOfWork.Companies.GetByFilterAsync(x => x.TaxNumber == createCompanyDto.TaxNumber);
                if (company is not null)
                {
                    _logger.LogWarning("Firma/Şirket oluşturulurken hata oluştu. Zaten oluşturulmuş. {TaxNumber}",company.TaxNumber);
                    return ResponseDto<CompanyDto>.Fail("Bu firma/şirket zaten var.", 404);
                }

               var mappingdto= _mapper.Map<Company>(createCompanyDto);
               await _unitOfWork.Companies.AddAsync(mappingdto);
                await _unitOfWork.SaveChangesAsync();

                var responsedto = _mapper.Map<CompanyDto>(mappingdto);
               _logger.LogInformation("Firma/Şirket başarıyla oluşturuldu :{Name}",mappingdto.Name);
               return ResponseDto<CompanyDto>.Success(responsedto,200, "Firma/Şirket başarıyla oluşturuldu. ");
            }
            catch (Exception ex)
            {

                _logger.LogWarning("Firma/Şirket oluşturulurken hata oluştu.{TaxNumber}", createCompanyDto.TaxNumber);
                return ResponseDto<CompanyDto>.Fail("Firma/şirket oluşturulurken bir hata oluştu. "+ex.Message, 404);
            }
                  
        }

        public Task<ResponseDto<object>> DeleteCompanyAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<CompanyDto>> GetByIdCompanyAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<CompanyDto>> GetCompanyListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<CompanyDto>> GetCompanyWithStatusFalseAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<object>> HardDeleteAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<CompanyDto>> UpdateCompanyAsync()
        {
            throw new NotImplementedException();
        }
    }
}
