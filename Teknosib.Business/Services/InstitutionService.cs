using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.CompanyDto;
using Teknosib.Business.Dto.InstitutionDto;
using Teknosib.Business.Interface;
using Teknosib.Business.Interface.File;
using Teknosib.Entity.Models;
using Teknosib.Entity.Models.Enums;

namespace Teknosib.Business.Services
{
    public class InstitutionService : IInstitutionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<InstitutionService> _logger;
        private readonly IFileService _fileService;

        public InstitutionService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<InstitutionService> logger, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _fileService = fileService;
        }

        public async Task<ResponseDto<InstitutionDto>> ApproveStatusInstitution(Guid id, ApproveStatus status)
        {
            try
            {
                var company = _unitOfWork.Institutions.UpdateApproveStatus(id, status);
                if (company is null)
                {
                    _logger.LogWarning($"Durum güncellenemedi. Id:{id}");
                    return ResponseDto<InstitutionDto>.Fail($"Durum güncellenemedi. Id:{id}", 404);

                }
                await _unitOfWork.SaveChangesAsync();
                var mappingdto = _mapper.Map<InstitutionDto>(company);
                return ResponseDto<InstitutionDto>.Success(mappingdto, 200, "Başarıyla durum güncellendi.");
            }
            catch (Exception)
            {
                _logger.LogWarning($"Durum güncellenirken bir hata oluştu. Id:{id}");
                return ResponseDto<InstitutionDto>.Fail($"Durum güncellenemedi. Id:{id}", 500);

            }
        }

        public async Task<ResponseDto<InstitutionDto>> CreateInstitutionAsync(CreateInstitutionDto createInstitutionDto)
        {
            try
            {
                var institution = await _unitOfWork.Institutions.GetByFilterAsync(x => x.InstitutionCode == createInstitutionDto.InstitutionCode);
                if (institution is not null)
                {
                    _logger.LogWarning("Kurum oluşturulurken hata oluştu. Zaten oluşturulmuş. {InstitutionCode}", institution.InstitutionCode);
                    return ResponseDto<InstitutionDto>.Fail("Bu kurum kaydı zaten var.", 404);
                }

                var mappingdto = _mapper.Map<Institution>(createInstitutionDto);
                await _unitOfWork.Institutions.AddAsync(mappingdto);
                await _unitOfWork.SaveChangesAsync();

                var responsedto = _mapper.Map<InstitutionDto>(mappingdto);
                _logger.LogInformation("Kurum başarıyla oluşturuldu :{Name}", mappingdto.Name);
                return ResponseDto<InstitutionDto>.Success(responsedto, 200, "Kurum başarıyla oluşturuldu. ");
            }
            catch (Exception ex)
            {

                _logger.LogWarning("Kurum oluşturulurken hata oluştu.{InstitutionCode}", createInstitutionDto.InstitutionCode);
                return ResponseDto<InstitutionDto>.Fail("Kurum oluşturulurken bir hata oluştu. " + ex.Message, 404);
            }
        }

        public async Task<ResponseDto<object>> DeleteInstitutionAsync(DeleteInstitutionDto deleteInstitutionDto)
        {
            try
            {
                var getinstitution = await _unitOfWork.Institutions.GetByIdAsync(deleteInstitutionDto.Id);
                if (getinstitution is null)
                {
                    _logger.LogWarning("Silinecek kurum bulunamadı. Gönderilen Id: {Id}", deleteInstitutionDto.Id);
                    return ResponseDto<object>.Fail("Silinecek kurum bulunamadı.", 404);
                }

                await _unitOfWork.Institutions.SoftDeleteAsync(getinstitution);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation("Silme işlemi başarılı. Silinen Id: {Id}", deleteInstitutionDto.Id);
                return ResponseDto<object>.Success(getinstitution, 200, "Kurum silme işlemi başarılı");

            }
            catch (Exception ex)
            {
                _logger.LogWarning("Silinecek kurum  silinirken bir hata oluştu. Gönderilen Id: {Id}", deleteInstitutionDto.Id);
                return ResponseDto<object>.Fail("Kurum  silinirken bir hata oluştu. " + ex.Message, 500);
            }
        }

        public async Task<ResponseDto<InstitutionDto>> GetByIdInstitutionAsync(Guid id)
        {
            try
            {
                var getinstitution = await _unitOfWork.Companies.GetByIdAsync(id);
                if (getinstitution is null)
                {
                    _logger.LogWarning("Getirilecek kurum  bulunamadı. Gönderilen Id: {Id}", id);
                    return ResponseDto<InstitutionDto>.Fail("Silinecek kurum bulunamadı.", 404);
                }
                var mappingdto = _mapper.Map<InstitutionDto>(getinstitution);
                _logger.LogInformation("Kurum getirme işlemi başarılı. Silinen Id: {Id}", id);
                return ResponseDto<InstitutionDto>.Success(mappingdto, 200, "Kurum başarıyla getirildi.");

            }
            catch (Exception ex)
            {
                _logger.LogWarning("Kurum getirilirken bir hata oluştu. Gönderilen Id: {Id}", id);
                return ResponseDto<InstitutionDto>.Fail("Kurum getirlirken bir hata oluştu. " + ex.Message, 500);
            }
        }

       

        public async Task<ResponseDto<List<InstitutionDto>>> GetInstitutionListAsync()
        {
            try
            {
                var getinstitution = await _unitOfWork.Institutions.GetListAllAsync();
                if (getinstitution is null)
                {
                    _logger.LogWarning("Getirilecek Şirket/Firma bulunamadı");
                    return ResponseDto<List<InstitutionDto>>.Fail("Getirilecek kurum bulunamadı.", 404);
                }

                var mappingdto = _mapper.Map<List<InstitutionDto>>(getinstitution);
                _logger.LogInformation("Kurum başarıyla getirildi");
                return ResponseDto<List<InstitutionDto>>.Success(mappingdto, 200, "Kurumlar başarıyla getirildi.");


            }
            catch (Exception ex)
            {
                _logger.LogWarning("Kurumlar getirilirken bir hata oluştu.");
                return ResponseDto<List<InstitutionDto>>.Fail("Kurumlar getirlirken bir hata oluştu. " + ex.Message, 500);
            }
        }

        public async Task<ResponseDto<InstitutionDto>> GetInstitutionWithStatusFalseAsync()
        {
            try
            {
                var getinstution = await _unitOfWork.Institutions.GetListIncludingStatusFalse();
                if (getinstution is null)
                {
                    _logger.LogWarning("Getirilecek kurum bulunamadı.");
                    return ResponseDto<InstitutionDto>.Fail("Getirilecek kurum bulunamadı.", 404);
                }
                var mappingdto = _mapper.Map<InstitutionDto>(getinstution);
                _logger.LogInformation("Tüm kurumlar getirildi.");
                return ResponseDto<InstitutionDto>.Success(mappingdto, 200, "Kurumlar başarıyla getirildi.");

            }
            catch (Exception ex)
            {

                _logger.LogWarning("Kurumlar getirilirken bir hata oluştu.");
                return ResponseDto<InstitutionDto>.Fail("Kurumlar getirlirken bir hata oluştu. " + ex.Message, 500);
            }
        }

        public async Task<ResponseDto<object>> HardDeleteInstitutionAsync(DeleteInstitutionDto deleteInstitutionDto)
        {
            try
            {
                var getinstituion = await _unitOfWork.Institutions.GetByIdAsync(deleteInstitutionDto.Id);
                if (getinstituion is null)
                {
                    _logger.LogWarning("Silinecek kurum  bulunamadı. Gönderilen Id: {Id}", deleteInstitutionDto.Id);
                    return ResponseDto<object>.Fail("Silinecek kurum bulunamadı.", 404);
                }
                await _unitOfWork.Institutions.HardDeleteAsync(getinstituion);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation($"Hard Delete işlemi başarıyla tamamlandı. {deleteInstitutionDto.Id} deleted");
                return ResponseDto<object>.Success(getinstituion, 200, "Silme işlemi başarılı.");

            }
            catch (Exception ex)
            {
                _logger.LogWarning("Silinecek kurum silinirken bir hata oluştu. Gönderilen Id: {Id}", deleteInstitutionDto.Id);
                return ResponseDto<object>.Fail("Silme işlemi sırasında bir hata oluştu. " + ex.Message, 500);

            }
        }

        public async Task<ResponseDto<InstitutionDto>> SaveInstitutionLogo(Guid institutionId, IFormFile formFile)
        {
            try
            {
                var getinstitution = await _unitOfWork.Institutions.GetByIdAsync(institutionId);
                if(getinstitution is null)
                {
                    _logger.LogWarning($"Şirket/Firma bulunamadı. Id:{institutionId}");
                    return ResponseDto<InstitutionDto>.Fail("Kurum bulunamadı.", 404);
                }
                var oldurl = getinstitution.Logo;
                if (!string.IsNullOrEmpty(oldurl))
                {
                    await _fileService.DeleteFileAsync(oldurl);  
                }
                var response = await _fileService.SaveInstitutionLogoAsync(formFile);
                if (!response.IsSuccess)
                {
                    _logger.LogWarning("Logo eklenirken bir hata oluştu.");
                    return ResponseDto<InstitutionDto>.Fail("Logo eklenirken bir hata oluştu.", 500);

                }
                getinstitution.Logo = response.Data.FileUrl;

                await _unitOfWork.Institutions.UpdateAsync(getinstitution);
                await _unitOfWork.SaveChangesAsync();
                var mappingdto=  _mapper.Map<InstitutionDto>(getinstitution);
                _logger.LogInformation($"Kurum logosu güncellendi. Id: {institutionId}");
                return ResponseDto<InstitutionDto>.Success(mappingdto, 200, "Logo başarıyla güncellendi.");
            }
            catch (Exception)
            {

                _logger.LogWarning($"Logo güncellenirken hata oluştu. Id: {institutionId}");
                return ResponseDto<InstitutionDto>.Fail("Logo güncellenirken bir sunucu hatası oluştu.", 500);
            }
        }

        public async Task<ResponseDto<UpdateInstitutionDto>> UpdateInstitutionAsync(Guid id, UpdateInstitutionDto updateInstitutionDto)
        {
            try
            {
                var getinstitution = await _unitOfWork.Institutions.GetByIdAsync(id);
                if (getinstitution is null)
                {
                    _logger.LogWarning("Güncellencek kurum bulunamadı. Gönderilen Id: {Id}", id);
                    return ResponseDto<UpdateInstitutionDto>.Fail("Güncellenecek kurum bulunamadı.", 404);
                }
                var mappingdto = _mapper.Map(updateInstitutionDto, getinstitution);
                await _unitOfWork.Institutions.UpdateAsync(mappingdto);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation($"Kurum güncelleme işlemi başarılı.Update institution: {id}");
                return ResponseDto<UpdateInstitutionDto>.Success(updateInstitutionDto, 200, "Güncelleme işlemi başarılı.");


            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Kurum güncellenirken bir hata oluştu. ID:{id}");
                return ResponseDto<UpdateInstitutionDto>.Fail("Güncelleme işlemi sırasında bir hata oluştu" + ex.Message, 500);
            }
        }
    }
}
