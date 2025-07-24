using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teknosib.Business.Dto.AddressDto;
using Teknosib.Business.Dto.ProposalDto;
using Teknosib.Business.Interface;
using Teknosib.Business.Services;

namespace Teknosib.Api.Controllers.AddressController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost("CreateAddress")]
        public async Task<IActionResult> CreateAddress(CreateAddressDto createAddressDto)
        {
            var response = await _addressService.Create_AddressAsync(createAddressDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("GetListAddress")]
        public async Task<IActionResult> GetListAddress()
        {
            var response = await _addressService.GetAddress_ListAsync();
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("DeleteAddress")]
        public async Task<IActionResult> DeleteAddress(DeleteAddressDto deleteAddressDto)
        {
            var response = await _addressService.Delete_AddressAsync(deleteAddressDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("HardDeleteAddress")]
        public async Task<IActionResult> HardDeleteAddress(DeleteAddressDto deleteAddressDto)
        {
            var response = await _addressService.HardDelete_AddressAsync(deleteAddressDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }


        [HttpGet("GetByIdAddress")]
        public async Task<IActionResult> GetByIdAddress(Guid id)
        {
            var response = await _addressService.GetById_AddressAsync(id);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("GetAddress_WithStatusFalse")]
        public async Task<IActionResult> GetAddresstWithStatusFalse()
        {
            var response = await _addressService.GetAddressList_WithStatusFalseAsync();
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("UpdateAddress")]
        public async Task<IActionResult> UpdateAddress(Guid id, UpdateAddressDto updateAddressDto)
        {
            var response = await _addressService.Update_AddressAsync(id,updateAddressDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }
    }
}
