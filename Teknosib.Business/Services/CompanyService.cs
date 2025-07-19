using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.CompanyDto;
using Teknosib.Business.Dto.ProblemDto;
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

        public async Task<ResponseDto<object>> DeleteCompanyAsync(DeleteCompanyDto deleteCompanyDto)
        {
            try
            {
                var getcompany = await _unitOfWork.Companies.GetByIdAsync(deleteCompanyDto.Id);
                if(getcompany is null)
                {
                    _logger.LogWarning("Silinecek Şirket/Firma  bulunamadı. Gönderilen Id: {Id}", deleteCompanyDto.Id);
                    return ResponseDto<object>.Fail("Silinecek Şirket/Firma bulunamadı.", 404);
                }

                await _unitOfWork.Companies.SoftDeleteAsync(getcompany);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation("Silme işlemi başarılı. Silinen Id: {Id}", deleteCompanyDto.Id);
                return ResponseDto<object>.Success(getcompany, 200, "Şirket/Firma silme işlemi başarılı");

            }
            catch (Exception ex)
            {
                _logger.LogWarning("Silinecek Şirket/Firma  silinirken bir hata oluştu. Gönderilen Id: {Id}", deleteCompanyDto.Id);
                return ResponseDto<object>.Fail("Silinecek Şirket/Firma  silinirken bir hata oluştu. " + ex.Message, 500);
            }
        }

        public async Task<ResponseDto<CompanyDto>> GetByIdCompanyAsync(Guid id)
        {
            try
            {
                var getcompany = await _unitOfWork.Companies.GetByIdAsync(id);
                if( getcompany is null)
                {
                    _logger.LogWarning("Getirilecek Şirket/Firma  bulunamadı. Gönderilen Id: {Id}",id);
                    return ResponseDto<CompanyDto>.Fail("Silinecek Şirket/Firma bulunamadı.", 404);
                }
                var mappingdto= _mapper.Map<CompanyDto>(getcompany);
                _logger.LogInformation("Şirket/Firma getirme işlemi başarılı. Silinen Id: {Id}", id);
                return ResponseDto<CompanyDto>.Success(mappingdto, 200, "Şirket/Firma başarıyla getirildi.");

            }
            catch (Exception ex)
            {
                _logger.LogWarning(" Şirket/Firma getirilirken bir hata oluştu. Gönderilen Id: {Id}", id);
                return ResponseDto<CompanyDto>.Fail("Şirket/Firma getirlirken bir hata oluştu. "+ex.Message,500);
            }
        }

        public async Task<ResponseDto<List<CompanyDto>>> GetCompanyListAsync()
        {
            try
            {
                var getcompany = await _unitOfWork.Companies.GetListAllAsync();
                if( getcompany is null)
                {
                    _logger.LogWarning("Getirilecek Şirket/Firma bulunamadı");
                    return ResponseDto<List<CompanyDto>>.Fail("Getirilecek Şirket/Firma bulunamadı.", 404);
                }

                var mappingdto = _mapper.Map<List<CompanyDto>>(getcompany);
                _logger.LogInformation("Şirket/Firma başarıyla getirildi");
                return ResponseDto<List<CompanyDto>>.Success(mappingdto, 200, "Şirket/Firmalar başarıyla getirildi.");


            }
            catch (Exception ex)
            {
                _logger.LogWarning("Şirket/Firmalar getirilirken bir hata oluştu.");
                return ResponseDto<List<CompanyDto>>.Fail("Şirket/Firmalar getirlirken bir hata oluştu. " + ex.Message, 500);
            }
        }

        public async Task<ResponseDto<CompanyDto>> GetCompanyWithStatusFalseAsync()
        {
            try
            {
                var getcompany = await _unitOfWork.Companies.GetListIncludingStatusFalse();
                if( getcompany is null)
                {
                    _logger.LogWarning("Getirilecek Şirket/Firma bulunamadı.");
                    return ResponseDto<CompanyDto>.Fail("Getirilecek Şirket/Firma bulunamadı.", 404);
                }
                var mappingdto = _mapper.Map<CompanyDto>(getcompany);
                _logger.LogInformation("Tüm Şirket/Firmalar getirildi.");
                return ResponseDto<CompanyDto>.Success(mappingdto, 200, "Şirket/Firmalar başarıyla getirildi.");

            }
            catch (Exception ex)
            {

                _logger.LogWarning("Şirket/Firmalar getirilirken bir hata oluştu.");
                return ResponseDto<CompanyDto>.Fail("Şirket/Firmalar getirlirken bir hata oluştu. " + ex.Message, 500);
            }

        }

        public async Task<ResponseDto<object>> HardDeleteAsync(DeleteCompanyDto deleteCompanyDto)
        {
            try
            {
                var getcompany = await _unitOfWork.Companies.GetByIdAsync(deleteCompanyDto.Id);
                if( getcompany is null)
                {
                    _logger.LogWarning("Silinecek Şirket/Firma  bulunamadı. Gönderilen Id: {Id}",deleteCompanyDto.Id);
                    return ResponseDto<object>.Fail("Silinecek Şirket/Firma bulunamadı.", 404);
                }
                await _unitOfWork.Companies.HardDeleteAsync(getcompany);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation($"Hard Delete işlemi başarıyla tamamlandı. {deleteCompanyDto.Id} deleted");
                return ResponseDto<object>.Success(getcompany, 200, "Silme işlemi başarılı.");

            }
            catch (Exception ex)
            {
                _logger.LogWarning("Silinecek Şirket/Firma silinirken bir hata oluştu. Gönderilen Id: {Id}", deleteCompanyDto.Id);
                return ResponseDto<object>.Fail("Silinecek Şirket/Firma bulunamadı. "+ex.Message, 500);

            }
        }

        public async Task<ResponseDto<UpdateCompanyDto>> UpdateCompanyAsync(Guid id,UpdateCompanyDto updateCompanyDto)
        {
            try
            {
                var getcompany = await _unitOfWork.Companies.GetByIdAsync(id);
                if( getcompany is null)
                {
                    _logger.LogWarning("Güncellencek Şirket/Firma  bulunamadı. Gönderilen Id: {Id}", id);
                    return ResponseDto<UpdateCompanyDto>.Fail("Güncellenecek Şirket/Firma bulunamadı.", 404);
                }
                var mappingdto = _mapper.Map(updateCompanyDto, getcompany);
                await _unitOfWork.Companies.UpdateAsync(mappingdto);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation($"Şirket/Firma güncelleme işlemi başarılı.Update company: {id}");
                return ResponseDto<UpdateCompanyDto>.Success(updateCompanyDto, 200, "Güncelleme işlemi başarılı.");


            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Şirket/Firma güncellenirken bir hata oluştu. ID:{id}");
                return ResponseDto<UpdateCompanyDto>.Fail("Güncelleme işlemi sırasında bir hata oluştu" + ex.Message, 500);
            }
        }
    }
}
