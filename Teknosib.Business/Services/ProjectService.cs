using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.InstitutionDto;
using Teknosib.Business.Dto.ProjectDto;
using Teknosib.Business.Interface;
using Teknosib.Entity.Models;

namespace Teknosib.Business.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ProjectService> _logger;

        public ProjectService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProjectService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseDto<ProjectDto>> CreateProjectAsync(CreateProjectDto createProjectDto)
        {
            try
            {
                var mappingdto = _mapper.Map<Project>(createProjectDto);
                await _unitOfWork.Projects.AddAsync(mappingdto);
                await _unitOfWork.SaveChangesAsync();

                var responsedto = _mapper.Map<ProjectDto>(mappingdto);
                _logger.LogInformation("Proje başarıyla oluşturuldu :{Name}", mappingdto.ProjectName);
                return ResponseDto<ProjectDto>.Success(responsedto, 200, "Proje başarıyla oluşturuldu. ");
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Proje oluşturulurken hata oluştu.{ProjectName}", createProjectDto.ProjectName);
                return ResponseDto<ProjectDto>.Fail("Proje oluşturulurken bir hata oluştu. " + ex.Message, 404);
            }
        }

        public async Task<ResponseDto<object>> DeleteProjectAsync(DeleteProjectDto deleteProjectDto)
        {
            try
            {
                var getproject = await _unitOfWork.Institutions.GetByIdAsync(deleteProjectDto.ProjectId);
                if (getproject is null)
                {
                    _logger.LogWarning("Silinecek proje bulunamadı. Gönderilen Id: {Id}", deleteProjectDto.ProjectId);
                    return ResponseDto<object>.Fail("Silinecek proje bulunamadı.", 404);
                }

                await _unitOfWork.Institutions.SoftDeleteAsync(getproject);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation("Silme işlemi başarılı. Silinen Id: {Id}", deleteProjectDto.ProjectId);
                return ResponseDto<object>.Success(getproject, 200, "Proje silme işlemi başarılı");

            }
            catch (Exception ex)
            {
                _logger.LogWarning("Silinecek proje silinirken bir hata oluştu. Gönderilen Id: {Id}", deleteProjectDto.ProjectId);
                return ResponseDto<object>.Fail("Proje  silinirken bir hata oluştu. " + ex.Message, 500);
            }
        }

        public async Task<ResponseDto<ProjectDto>> GetByIdProjectAsync(Guid id)
        {
            try
            {
                var getproject = await _unitOfWork.Projects.GetByIdAsync(id);
                if (getproject is null)
                {
                    _logger.LogWarning("Getirilecek proje  bulunamadı. Gönderilen Id: {Id}", id) ;
                    return ResponseDto<ProjectDto>.Fail("Silinecek proje bulunamadı.", 404);
                }
                var mappingdto = _mapper.Map<ProjectDto>(getproject);
                _logger.LogInformation("Proje getirme işlemi başarılı. Silinen Id: {Id}", id);
                return ResponseDto<ProjectDto>.Success(mappingdto, 200, "Proje başarıyla getirildi.");

            }
            catch (Exception ex)
            {
                _logger.LogWarning("Proje getirilirken bir hata oluştu. Gönderilen Id: {Id}", id);
                return ResponseDto<ProjectDto>.Fail("Proje getirlirken bir hata oluştu. " + ex.Message, 500);
            }
        }

        

        public  async Task<ResponseDto<List<ProjectDto>>> GetProjectListAsync()
        {
            try
            {
                var getproject = await _unitOfWork.Projects.GetListAllAsync();
                if (getproject is null)
                {
                    _logger.LogWarning("Getirilecek proje bulunamadı");
                    return ResponseDto<List<ProjectDto>>.Fail("Getirilecek proje bulunamadı.", 404);
                }

                var mappingdto = _mapper.Map<List<ProjectDto>>(getproject);
                _logger.LogInformation("Proje başarıyla getirildi");
                return ResponseDto<List<ProjectDto>>.Success(mappingdto, 200, "Proje başarıyla getirildi.");


            }
            catch (Exception ex)
            {
                _logger.LogWarning("Proje getirilirken bir hata oluştu.");
                return ResponseDto<List<ProjectDto>>.Fail("Proje getirlirken bir hata oluştu. " + ex.Message, 500);
            }
        }

        public async Task<ResponseDto<List<ProjectDto>>> GetProjectListWithStatusFalseAsync()
        {
            try
            {
                var getproject = await _unitOfWork.Projects.GetListIncludingStatusFalse();
                if (getproject is null)
                {
                    _logger.LogWarning("Getirilecek proje bulunamadı.");
                    return ResponseDto<List<ProjectDto>>.Fail("Getirilecek proje bulunamadı.", 404);
                }
                var mappingdto = _mapper.Map<List<ProjectDto>>(getproject);
                _logger.LogInformation("Tüm proje getirildi.");
                return ResponseDto<List<ProjectDto>>.Success(mappingdto, 200, "Projeler başarıyla getirildi.");

            }
            catch (Exception ex)
            {

                _logger.LogWarning("Projeler getirilirken bir hata oluştu.");
                return ResponseDto<List<ProjectDto>>.Fail("Projeler getirlirken bir hata oluştu. " + ex.Message, 500);
            }
        }

        public async Task<ResponseDto<object>> HardDeleteProjectAsync(DeleteProjectDto deleteProjectDto)
        {
            try
            {
                var getproject = await _unitOfWork.Projects.GetByIdAsync(deleteProjectDto.ProjectId);
                if (getproject is null)
                {
                    _logger.LogWarning("Silinecek proje  bulunamadı. Gönderilen Id: {Id}", deleteProjectDto.ProjectId);
                    return ResponseDto<object>.Fail("Silinecek proje bulunamadı.", 404);
                }
                await _unitOfWork.Projects.HardDeleteAsync(getproject);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation($"Hard Delete işlemi başarıyla tamamlandı. {deleteProjectDto.ProjectId} deleted");
                return ResponseDto<object>.Success(getproject, 200, "Silme işlemi başarılı.");

            }
            catch (Exception ex)
            {
                _logger.LogWarning("Silinecek proje silinirken bir hata oluştu. Gönderilen Id: {Id}", deleteProjectDto.ProjectId);
                return ResponseDto<object>.Fail("Silme işlemi sırasında bir hata oluştu. " + ex.Message, 500);

            }
        }

        public async Task<ResponseDto<UpdateProjectDto>> UpdateProjectAsync(Guid id, UpdateProjectDto updateProjectDto)
        {
            try
            {
                var getproject = await _unitOfWork.Projects.GetByIdAsync(id);
                if (getproject is null)
                {
                    _logger.LogWarning("Güncellencek kurum bulunamadı. Gönderilen Id: {Id}", id);
                    return ResponseDto<UpdateProjectDto>.Fail("Güncellenecek kurum bulunamadı.", 404);
                }
                var mappingdto = _mapper.Map(updateProjectDto, getproject);
                await _unitOfWork.Projects.UpdateAsync(mappingdto);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation($"Kurum güncelleme işlemi başarılı.Update institution: {id}");
                return ResponseDto<UpdateProjectDto>.Success(updateProjectDto, 200, "Güncelleme işlemi başarılı.");


            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Kurum güncellenirken bir hata oluştu. ID:{id}");
                return ResponseDto<UpdateProjectDto>.Fail("Güncelleme işlemi sırasında bir hata oluştu" + ex.Message, 500);
            }
        }
    }
}
