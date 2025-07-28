using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Teknosib.Business.Dto.File;


namespace Teknosib.Business.Interface.File
{
    public interface IFileService
    {
        Task<ResponseDto<FileResponseDto>> SaveCompanyLogoAsync(IFormFile file);
        Task<ResponseDto<object>> DeleteFileAsync(string fileUrl);
        Task<ResponseDto<FileResponseDto>> SaveProfileImageAsync(IFormFile file);
    }
}
