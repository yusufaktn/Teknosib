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

        public async Task<ResponseDto<object>> Delete_AddressAsync(DeleteAddressDto deleteAddressDto)
        {
            try
            {
                var getAddress = await _unitOfWork.Addresses.GetByIdAsync(deleteAddressDto.AddressId);
                if(getAddress is null)
                {
                    _logger.LogWarning($"Getirilecek adres bulunamadı. Id:{deleteAddressDto.AddressId}");
                    return ResponseDto<object>.Fail("Getirilecek adres bulunamadı.",404);

                }
                await _unitOfWork.Addresses.SoftDeleteAsync(getAddress);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation($"Adres silme işlemi başarılı. Id:{deleteAddressDto.AddressId}");
                return ResponseDto<object>.Success($"Silme işlemi başarılı. Id:{deleteAddressDto.AddressId}", 200);
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Adres silme işlemi sırasında bir hata oluştu. Id:{deleteAddressDto.AddressId}");
                return ResponseDto<object>.Fail($"Adres silme işlemi sırasında bir hata oluştu. Id:{deleteAddressDto.AddressId}",500);
               
            }
        }

        public async Task<ResponseDto<List<AddressDto>>> GetAddressList_WithStatusFalseAsync()
        {
            try
            {
                var getAddress = await _unitOfWork.Addresses.GetListIncludingStatusFalse();
                if(getAddress is null)
                {
                    _logger.LogWarning("Getirilecek adres bulunamadı.");
                    return ResponseDto<List<AddressDto>>.Fail("Getirilecek adres bulunamadı.", 404);                      
                }
                var mappingdto = _mapper.Map<List<AddressDto>>(getAddress);
                _logger.LogInformation("Tüm adresler başarıyla getirildi.");
                return ResponseDto<List<AddressDto>>.Success(mappingdto, 200, "Tüm adresler başarıyla getirildi");
            }
            catch (Exception)
            {
                _logger.LogWarning("Tüm adresler getirilirken bir hata oluştu");
                return ResponseDto<List<AddressDto>>.Fail("Tüm adresler getirilirken bir hata oluştu", 500);
            }
        }

        public async Task<ResponseDto<List<AddressDto>>> GetAddress_ListAsync()
        {
            try
            {
                var getAddress = await _unitOfWork.Addresses.GetListAllAsync();
                if(getAddress is null)
                {
                    _logger.LogWarning("Getirilecek adres bulunamadı.");
                    return ResponseDto<List<AddressDto>>.Fail("Getirilecek adres bulunamadı.", 404);
                }
                var mappingdto = _mapper.Map<List<AddressDto>>(getAddress);
                _logger.LogInformation("Tüm adresler başarıyla getirildi.");
                return ResponseDto<List<AddressDto>>.Success(mappingdto, 200, "Tüm adresler başarıyla getirildi");

            }
            catch (Exception)
            {

                _logger.LogWarning("Tüm adresler getirilirken bir hata oluştu");
                return ResponseDto<List<AddressDto>>.Fail("Tüm adresler getirilirken bir hata oluştu", 500);
            }
        }

        public async Task<ResponseDto<AddressDto>> GetById_AddressAsync(Guid id)
        {
            try
            {
                var getAddress = await _unitOfWork.Addresses.GetByIdAsync(id);
                if(getAddress is null)
                {
                    _logger.LogWarning($"Getirilecek adres bulunamadı. Id:{id}");
                    return ResponseDto<AddressDto>.Fail($"Getirilecek adres bulunamadı. Id:{id}", 404);
                }
                var mappingdto = _mapper.Map<AddressDto>(getAddress);
                _logger.LogInformation($"Adres başarıyla getirildi. Id:{id}");
                return ResponseDto<AddressDto>.Success(mappingdto, 200, $"Adres başarıyla getirildi. Id:{id}");

            }
            catch (Exception)
            {

                _logger.LogWarning($"Adres getirilirken bir hata oluştu. Id:{id}");
                return ResponseDto<AddressDto>.Fail($"Adres getirilirken bir hata oluştu. Id:{id}",500);
            }
        }

        public async Task<ResponseDto<object>> HardDelete_AddressAsync(DeleteAddressDto deleteAddressDto)
        {
            try
            {
                var getAddress = await _unitOfWork.Addresses.GetByIdAsync(deleteAddressDto.AddressId);
                if (getAddress is null)
                {
                    _logger.LogWarning($"Getirilecek adres bulunamadı. Id:{deleteAddressDto.AddressId}");
                    return ResponseDto<object>.Fail("Getirilecek adres bulunamadı.", 404);

                }
                await _unitOfWork.Addresses.HardDeleteAsync(getAddress);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation($"Adres silme işlemi başarılı. Id:{deleteAddressDto.AddressId}");
                return ResponseDto<object>.Success($"Silme işlemi başarılı. Id:{deleteAddressDto.AddressId}", 200);
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Adres silme işlemi sırasında bir hata oluştu. Id:{deleteAddressDto.AddressId}");
                return ResponseDto<object>.Fail($"Adres silme işlemi sırasında bir hata oluştu. Id:{deleteAddressDto.AddressId}", 500);

            }
        }

        public async Task<ResponseDto<UpdateAddressDto>> Update_AddressAsync(Guid id, UpdateAddressDto updateAddressDto)
        {
            try
            {
                var getAddress = await _unitOfWork.Addresses.GetByIdAsync(id);
                if(getAddress is null)
                {
                    _logger.LogWarning($"Güncellenecek adres bulunamadı. Id:{id}");
                    return ResponseDto<UpdateAddressDto>.Fail($"Güncellenecek adres bulunamadı. Id:{id}",404);
                }
               var mappingdto = _mapper.Map(updateAddressDto, getAddress);
                await _unitOfWork.Addresses.UpdateAsync(mappingdto);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation($"Adres başarıyla güncellendi. Id:{id}");
                return ResponseDto<UpdateAddressDto>.Success(updateAddressDto, 200, $"Adres başarıyla güncellendi. Id:{id}");

            }
            catch (Exception)
            {
                _logger.LogWarning($"Adres güncellenirken bir hata oluştu Id:{id}");
                return ResponseDto<UpdateAddressDto>.Fail($"Adres güncellenirken bir hata oluştu. Id:{id}",500);

            }
        }
    }
}
