using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.ProjectDto;
using Teknosib.Business.Dto.SupportCallDto;
using Teknosib.Business.Interface;
using Teknosib.Entity.Models;

namespace Teknosib.Business.Services
{
    public class SupportCallService : ISupportCallService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<SupportCallService> _logger;

        public SupportCallService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<SupportCallService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseDto<SupportCallDto>> Create_SupportCallAsync(CreateSupportCallDto createSupportCallDto)
        {
            try
            {
                var mappingdto = _mapper.Map<SupportCall>(createSupportCallDto);
                await _unitOfWork.SupportCalls.AddAsync(mappingdto);
                await _unitOfWork.SaveChangesAsync();

                var responsedto = _mapper.Map<SupportCallDto>(mappingdto);
                _logger.LogInformation("Destek çağrısı başarıyla oluşturuldu :{Title}", mappingdto.Title);
                return ResponseDto<SupportCallDto>.Success(responsedto, 200, "Destek çağrısı başarıyla oluşturuldu. ");
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Destek çağrısı oluşturulurken hata oluştu.{Title}", createSupportCallDto.Title);
                return ResponseDto<SupportCallDto>.Fail("Destek çağrısı oluşturulurken bir hata oluştu. " + ex.Message, 404);
            }
        }

        public async Task<ResponseDto<object>> Delete_SupportCallAsync(DeleteSupportCallDto deleteSupportCallDto)
        {
            try
            {
                var getSupportCall = await _unitOfWork.SupportCalls.GetByIdAsync(deleteSupportCallDto.SupportCallId);
                if (getSupportCall is null)
                {
                    _logger.LogWarning("Silinecek destek çağrısı bulunamadı. Gönderilen Id: {Id}", deleteSupportCallDto.SupportCallId);
                    return ResponseDto<object>.Fail("Silinecek destek çağrısı bulunamadı.", 404);
                }

                await _unitOfWork.SupportCalls.SoftDeleteAsync(getSupportCall);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation("Silme işlemi başarılı. Silinen Id: {Id}", deleteSupportCallDto.SupportCallId);
                return ResponseDto<object>.Success(getSupportCall, 200, "Destek çağrısı silme işlemi başarılı");

            }
            catch (Exception ex)
            {
                _logger.LogWarning("Silinecek destek çağrısı silinirken bir hata oluştu. Gönderilen Id: {Id}", deleteSupportCallDto.SupportCallId);
                return ResponseDto<object>.Fail("Destek çağrısı silinirken bir hata oluştu. " + ex.Message, 500);
            }
        }

        public async Task<ResponseDto<SupportCallDto>> GetById_SupportCallAsync(Guid id)
        {
            try
            {
                var getSupportCall = await _unitOfWork.SupportCalls.GetByIdAsync(id);
                if (getSupportCall is null)
                {
                    _logger.LogWarning("Getirilecek destek çağrısı  bulunamadı. Gönderilen Id: {Id}", id);
                    return ResponseDto<SupportCallDto>.Fail("Silinecek proje bulunamadı.", 404);
                }
                var mappingdto = _mapper.Map<SupportCallDto>(getSupportCall);
                _logger.LogInformation("Destek çağrısı getirme işlemi başarılı. Silinen Id: {Id}", id);
                return ResponseDto<SupportCallDto>.Success(mappingdto, 200, "Proje başarıyla getirildi.");

            }
            catch (Exception ex)
            {
                _logger.LogWarning("Destek çağırsı getirilirken bir hata oluştu. Gönderilen Id: {Id}", id);
                return ResponseDto<SupportCallDto>.Fail("Proje getirlirken bir hata oluştu. " + ex.Message, 500);
            }
        }

        public async Task<ResponseDto<List<SupportCallDto>>> GetListSupportCall_WithStatusFalseAsync()
        {
            try
            {
                var getSupportCall = await _unitOfWork.SupportCalls.GetListIncludingStatusFalse();
                if (getSupportCall is null)
                {
                    _logger.LogWarning("Getirilecek desttek çağrısı bulunamadı.");
                    return ResponseDto<List<SupportCallDto>>.Fail("Getirilecek destek çağrısı bulunamadı.", 404);
                }
                var mappingdto = _mapper.Map<List<SupportCallDto>>(getSupportCall);
                _logger.LogInformation("Tüm destek çağrıları getirildi.");
                return ResponseDto<List<SupportCallDto>>.Success(mappingdto, 200, "Destek çağrıları başarıyla getirildi.");

            }
            catch (Exception ex)
            {

                _logger.LogWarning("Destek çağrıları getirilirken bir hata oluştu.");
                return ResponseDto<List<SupportCallDto>>.Fail("Destek çağrıları getirlirken bir hata oluştu. " + ex.Message, 500);
            }
        }

        public async Task<ResponseDto<List<SupportCallDto>>> GetList_SupportCallAsync()
        {
            try
            {
                var getSupportCall = await _unitOfWork.SupportCalls.GetListAllAsync();
                if (getSupportCall is null)
                {
                    _logger.LogWarning("Getirilecek destek çağrısı bulunamadı");
                    return ResponseDto<List<SupportCallDto>>.Fail("Getirilecek destek çağrısı bulunamadı.", 404);
                }

                var mappingdto = _mapper.Map<List<SupportCallDto>>(getSupportCall);
                _logger.LogInformation("Destek çağrısı başarıyla getirildi");
                return ResponseDto<List<SupportCallDto>>.Success(mappingdto, 200, "Destek çağrısı başarıyla getirildi.");


            }
            catch (Exception ex)
            {
                _logger.LogWarning("Destek çağrısı getirilirken bir hata oluştu.");
                return ResponseDto<List<SupportCallDto>>.Fail("Destek çağrısı getirlirken bir hata oluştu. " + ex.Message, 500);
            }
        }

        public async Task<ResponseDto<object>> HardDelete_SupportCallAsync(DeleteSupportCallDto deleteSupportCallDto)
        {
            try
            {
                var getSupportCall = await _unitOfWork.SupportCalls.GetByIdAsync(deleteSupportCallDto.SupportCallId);
                if (getSupportCall is null)
                {
                    _logger.LogWarning("Silinecek destek çağrısı bulunamadı. Gönderilen Id: {Id}", deleteSupportCallDto.SupportCallId);
                    return ResponseDto<object>.Fail("Silinecek destek çağrısı bulunamadı.", 404);
                }
                await _unitOfWork.SupportCalls.HardDeleteAsync(getSupportCall);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation($"Hard Delete işlemi başarıyla tamamlandı. {deleteSupportCallDto.SupportCallId} deleted");
                return ResponseDto<object>.Success(getSupportCall, 200, "Silme işlemi başarılı.");

            }
            catch (Exception ex)
            {
                _logger.LogWarning("Destek çağrısı silinirken bir hata oluştu. Gönderilen Id: {Id}", deleteSupportCallDto.SupportCallId);
                return ResponseDto<object>.Fail("Silme işlemi sırasında bir hata oluştu. " + ex.Message, 500);

            }
        }

        public async Task<ResponseDto<UpdateSupportCallDto>> Update_SupportCallAsync(Guid id, UpdateSupportCallDto updateSupportCallDto)
        {
            try
            {
                var getSupportCall = await _unitOfWork.SupportCalls.GetByIdAsync(id);
                if (getSupportCall is null)
                {
                    _logger.LogWarning("Güncellencek destek çağrısı bulunamadı. Gönderilen Id: {Id}", id);
                    return ResponseDto<UpdateSupportCallDto>.Fail("Güncellenecek destek çağrısı bulunamadı.", 404);
                }
                var mappingdto = _mapper.Map(updateSupportCallDto, getSupportCall);
                await _unitOfWork.SupportCalls.UpdateAsync(mappingdto);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation($"Destek çağrısı güncelleme işlemi başarılı.Update project: {id}");
                return ResponseDto<UpdateSupportCallDto>.Success(updateSupportCallDto, 200, "Güncelleme işlemi başarılı.");


            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Destek çağrısı güncellenirken bir hata oluştu. ID:{id}");
                return ResponseDto<UpdateSupportCallDto>.Fail("Güncelleme işlemi sırasında bir hata oluştu" + ex.Message, 500);
            }
        }
    }
}
