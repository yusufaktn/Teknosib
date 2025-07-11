using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.ProblemDto;
using Teknosib.Business.Interface;
using Teknosib.Entity.Models;

namespace Teknosib.Business.Services
{
    
    public class ProblemService : IProblemService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProblemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseDto<ProblemDto>> CreateProblemAsync(CreateProblemDto createProblemDto)
        {
            try
            {
                var mapping_problem = _mapper.Map<Problem>(createProblemDto);
                await _unitOfWork.Problems.AddAsync(mapping_problem);
                await _unitOfWork.SaveChangesAsync();
                var problem_dto = _mapper.Map<ProblemDto>(mapping_problem);
                return ResponseDto<ProblemDto>.Success(problem_dto, 200,"Problem oluşturma işlemi başarılı");
            }
            catch (Exception ex)
            {
                return ResponseDto<ProblemDto>.Fail("Problem oluşturulurken bir hata oluştu. "+ex.Message,500);
            }
        }

        public async Task<ResponseDto<object>> DeleteProblemAsync(DeleteProblemDto deleteProblemDto)
        {
            try
            {
                var getproblem = await _unitOfWork.Problems.GetByIdAsync(deleteProblemDto.ProblemId);
                if(getproblem is null)
                {
                    return ResponseDto<object>.Fail("Silinecek Problem bulunamadı.", 404);
                }
                await _unitOfWork.Problems.SoftDeleteAsync(getproblem);
                await _unitOfWork.SaveChangesAsync();
                return ResponseDto<object>.Success("Silme işlemi başarılı", 200);

            }
            catch(Exception ex)
            {
                return ResponseDto<object>.Fail("Silme işlemi sırasında bir hata oluştu "+ex.Message, 500);
            }
        }

        public async Task<ResponseDto<ProblemDto>> GetByIdProblemAsync(Guid id)
        {
            try
            {
                var getproblem = await _unitOfWork.Problems.GetByIdAsync(id);
                if(getproblem is null)
                {
                    return ResponseDto<ProblemDto>.Fail("Aranan Problem bulunamadı.", 404);
                }
               var mapping_problem=  _mapper.Map<ProblemDto>(getproblem);
                return ResponseDto<ProblemDto>.Success(mapping_problem, 200,id+" Problem başarıyla getirildi.");
                


            }
            catch (Exception ex)
            {
                return ResponseDto<ProblemDto>.Fail("Problem getirme sırasında bir hata oluştu "+ex.Message, 500);
            }
        }

        public Task<ResponseDto<ProblemDto>> GetProblemListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<ProblemDto>> GetProblemWithStatusFalseAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<object>> HardDeleteProblemAsync(DeleteProblemDto deleteProblemDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<UpdateProblemDto>> UpdateProblemAsync(UpdateProblemDto updateProblemDto)
        {
            throw new NotImplementedException();
        }
    }
}
