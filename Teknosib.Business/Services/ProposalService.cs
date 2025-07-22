using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.ProjectDto;
using Teknosib.Business.Dto.ProposalDto;
using Teknosib.Business.Interface;
using Teknosib.Entity.Models;

namespace Teknosib.Business.Services
{
    public class ProposalService : IProposalService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ProposalService> _logger;

        public ProposalService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProposalService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseDto<ProposalDto>> CreateProposalAsync(CreateProposalDto createProposalDto)
        {
            try
            {
                var mappingdto = _mapper.Map<Proposal>(createProposalDto);
                await _unitOfWork.Proposals.AddAsync(mappingdto);
                await _unitOfWork.SaveChangesAsync();

                var responsedto = _mapper.Map<ProposalDto>(mappingdto);
                _logger.LogInformation("Teklif başarıyla oluşturuldu :{ProposalId}", mappingdto.ProposalId);
                return ResponseDto<ProposalDto>.Success(responsedto, 200, "Teklif başarıyla oluşturuldu. ");
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Teklif oluşturulurken hata oluştu.{Price}",createProposalDto.Price);
                return ResponseDto<ProposalDto>.Fail("Teklif oluşturulurken bir hata oluştu. " + ex.Message, 404);
            }
        }

        public async Task<ResponseDto<object>> DeleteProposalAsync(DeleteProposalDto deleteProposalDto)
        {
            try
            {
                var getproposal = await _unitOfWork.Proposals.GetByIdAsync(deleteProposalDto.ProposalId);
                if (getproposal is null)
                {
                    _logger.LogWarning("Silinecek teklif bulunamadı. Gönderilen Id: {ProposalId}", deleteProposalDto.ProposalId);
                    return ResponseDto<object>.Fail("Silinecek teklif bulunamadı.", 404);
                }

                await _unitOfWork.Proposals.SoftDeleteAsync(getproposal);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation("Silme işlemi başarılı. Silinen Id: {ProposalId}", deleteProposalDto.ProposalId);
                return ResponseDto<object>.Success(getproposal, 200, "Teklif silme işlemi başarılı");

            }
            catch (Exception ex)
            {
                _logger.LogWarning("Silinecek teklif silinirken bir hata oluştu. Gönderilen Id: {Id}", deleteProposalDto.ProposalId);
                return ResponseDto<object>.Fail("Teklif silinirken bir hata oluştu. " + ex.Message, 500);
            }
        }

        public async Task<ResponseDto<ProposalDto>> GetByIdProposalAsync(Guid id)
        {
            try
            {
                var getproposal = await _unitOfWork.Proposals.GetByIdAsync(id);
                if (getproposal is null)
                {
                    _logger.LogWarning("Getirilecek teklif  bulunamadı. Gönderilen Id: {Id}", id);
                    return ResponseDto<ProposalDto>.Fail("Silinecek teklif bulunamadı.", 404);
                }
                var mappingdto = _mapper.Map<ProposalDto>(getproposal);
                _logger.LogInformation("Teklif getirme işlemi başarılı. Silinen Id: {Id}", id);
                return ResponseDto<ProposalDto>.Success(mappingdto, 200, "Teklif başarıyla getirildi.");

            }
            catch (Exception ex)
            {
                _logger.LogWarning("Teklif getirilirken bir hata oluştu. Gönderilen Id: {Id}", id);
                return ResponseDto<ProposalDto>.Fail("Teklif getirlirken bir hata oluştu. " + ex.Message, 500);
            }
        }

        public async Task<ResponseDto<List<ProposalDto>>> GetProposalListAsync()
        {
            try
            {
                var getproposal = await _unitOfWork.Proposals.GetListAllAsync();
                if (getproposal is null)
                {
                    _logger.LogWarning("Getirilecek teklif bulunamadı");
                    return ResponseDto<List<ProposalDto>>.Fail("Getirilecek teklif bulunamadı.", 404);
                }

                var mappingdto = _mapper.Map<List<ProposalDto>>(getproposal);
                _logger.LogInformation("Teklif başarıyla getirildi");
                return ResponseDto<List<ProposalDto>>.Success(mappingdto, 200, "Teklif başarıyla getirildi.");


            }
            catch (Exception ex)
            {
                _logger.LogWarning("Teklif getirilirken bir hata oluştu.");
                return ResponseDto<List<ProposalDto>>.Fail("Teklif getirlirken bir hata oluştu. " + ex.Message, 500);
            }
        }

        public async Task<ResponseDto<List<ProposalDto>>> GetProposalListWithStatusFalseAsync()
        {
            try
            {
                var getproposal = await _unitOfWork.Proposals.GetListIncludingStatusFalse();
                if (getproposal is null)
                {
                    _logger.LogWarning("Getirilecek teklif bulunamadı.");
                    return ResponseDto<List<ProposalDto>>.Fail("Getirilecek teklif bulunamadı.", 404);
                }
                var mappingdto = _mapper.Map<List<ProposalDto>>(getproposal);
                _logger.LogInformation("Tüm teklifler getirildi.");
                return ResponseDto<List<ProposalDto>>.Success(mappingdto, 200, "Projeler başarıyla getirildi.");

            }
            catch (Exception ex)
            {

                _logger.LogWarning("Teklifler getirilirken bir hata oluştu.");
                return ResponseDto<List<ProposalDto>>.Fail("Teklifler getirlirken bir hata oluştu. " + ex.Message, 500);
            }
        }

        public async Task<ResponseDto<object>> HardDeleteProposalAsync(DeleteProposalDto deleteProposalDto)
        {
            try
            {
                var getproposal = await _unitOfWork.Proposals.GetByIdAsync(deleteProposalDto.ProposalId);
                if (getproposal is null)
                {
                    _logger.LogWarning("Silinecek teklif  bulunamadı. Gönderilen Id: {Id}", deleteProposalDto.ProposalId);
                    return ResponseDto<object>.Fail("Silinecek teklif bulunamadı.", 404);
                }
                await _unitOfWork.Proposals.HardDeleteAsync(getproposal);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation($"Hard Delete işlemi başarıyla tamamlandı. {deleteProposalDto.ProposalId} deleted");
                return ResponseDto<object>.Success(getproposal, 200, "Silme işlemi başarılı.");

            }
            catch (Exception ex)
            {
                _logger.LogWarning("Teklif silinirken bir hata oluştu. Gönderilen Id: {Id}", deleteProposalDto.ProposalId);
                return ResponseDto<object>.Fail("Silme işlemi sırasında bir hata oluştu. " + ex.Message, 500);

            }
        }

        public async Task<ResponseDto<UpdateProposalDto>> UpdateProposalAsync(Guid id, UpdateProposalDto updateProposalDto)
        {
            try
            {
                var getproposal = await _unitOfWork.Proposals.GetByIdAsync(id);
                if (getproposal is null)
                {
                    _logger.LogWarning("Güncellencek teklif bulunamadı. Gönderilen Id: {Id}", id);
                    return ResponseDto<UpdateProposalDto>.Fail("Güncellenecek teklif bulunamadı.", 404);
                }
                var mappingdto = _mapper.Map(updateProposalDto, getproposal);
                await _unitOfWork.Proposals.UpdateAsync(mappingdto);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation($"Teklif güncelleme işlemi başarılı.Update proposal: {id}");
                return ResponseDto<UpdateProposalDto>.Success(updateProposalDto, 200, "Güncelleme işlemi başarılı.");


            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Teklif güncellenirken bir hata oluştu. ID:{id}");
                return ResponseDto<UpdateProposalDto>.Fail("Güncelleme işlemi sırasında bir hata oluştu" + ex.Message, 500);
            }
        }
    }
}
