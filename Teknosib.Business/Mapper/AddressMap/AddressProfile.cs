using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.AddressDto;
using Teknosib.Entity.Models;

namespace Teknosib.Business.Mapper.AddressMap
{
    public class AddressProfile:Profile
    {
        public AddressProfile()
        {
            //Output
            CreateMap<Address, AddressDto>();

            //Input
            CreateMap<UpdateAddressDto, Address>();
            CreateMap<CreateAddressDto, Address>();



        }
    }
}
