using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.AddressDto;
using Teknosib.Business.Interface;
using Teknosib.Entity.Models;

namespace Teknosib.Business.Services
{
    public class AddressService : IAddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<AddressService> _logger;

        public AddressService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<AddressService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseDto<AddressDto>> Create_AddressAsync(CreateAddressDto createAddressDto)
        {
            try
            {
                var getAddress = await _unitOfWork.Addresses.GetByFilterAsync(x => x.City == createAddressDto.City);
                if(getAddress is not null)
                {
                    _logger.LogWarning($"Aynı adresten daha önce eklenmiş. Adres:{createAddressDto.City}");
                    return ResponseDto<AddressDto>.Fail("Adres daha önce eklenmiş", 404);
                }
                var mappingdto = _mapper.Map<Address>(getAddress);
                await _unitOfWork.Addresses.AddAsync(mappingdto);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation($"Adres başarıyla eklendi. Adres:{createAddressDto.City}");
                var responsedto = _mapper.Map<AddressDto>(mappingdto);
                return ResponseDto<AddressDto>.Success(responsedto, 200, "Adres başarıyla eklendi.");

            }
            catch (Exception)
            {
                _logger.LogWarning($"Adres eklenirken bir hata oluştu.");
                return ResponseDto<AddressDto>.Fail("Adres eklenirken bir hata oluştu", 500);
                
            }
        }

        public Task<ResponseDto<object>> Delete_AddressAsync(DeleteAddressDto deleteAddressDto)
        {
            
        }

        public Task<ResponseDto<List<AddressDto>>> GetAddressList_WithStatusFalseAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<List<AddressDto>>> GetAddress_ListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<AddressDto>> GetById_AddressAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<object>> HardDelete_AddressAsync(DeleteAddressDto deleteAddressDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<UpdateAddressDto>> Update_AddressAsync(Guid id, UpdateAddressDto updateAddressDto)
        {
            throw new NotImplementedException();
        }
    }
}
