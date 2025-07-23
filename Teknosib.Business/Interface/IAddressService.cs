using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.AddressDto;
using Teknosib.Business.Dto.ProjectDto;

namespace Teknosib.Business.Interface
{
    public interface IAddressService
    {
        Task<ResponseDto<List<AddressDto>>> GetAddress_ListAsync();
        Task<ResponseDto<List<AddressDto>>> GetAddressList_WithStatusFalseAsync();
        Task<ResponseDto<AddressDto>> GetById_AddressAsync(Guid id);
        Task<ResponseDto<AddressDto>> Create_AddressAsync(CreateAddressDto createAddressDto);
        Task<ResponseDto<UpdateAddressDto>> Update_AddressAsync(Guid id, UpdateAddressDto updateAddressDto);
        Task<ResponseDto<object>> Delete_AddressAsync(DeleteAddressDto deleteAddressDto);
        Task<ResponseDto<object>> HardDelete_AddressAsync(DeleteAddressDto deleteAddressDto);
    }
}
