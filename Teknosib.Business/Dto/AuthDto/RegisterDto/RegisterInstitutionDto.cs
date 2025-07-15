using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Entity.Models.Enums;

namespace Teknosib.Business.Dto.AuthDto.RegisterDto
{
    public class RegisterInstitutionDto
    {  
        //LegalEntitiy orak alanlar
        public string IntitutionName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? WebSite { get; set; }
        public string? Logo { get; set; }

        //Intitution özel alanlar
        public InstitutionType Type { get; set; }
        public string? InstitutionCode { get; set; } 
        public string? OfficialTitle { get; set; } 
        public string? AuthorityName { get; set; } 
        public string? AuthorityTitle { get; set; }

        // İlk Admin Kullanıcı Bilgileri
        public string AdminFirstName { get; set; }
        public string AdminLastName { get; set; }
        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; }

        //Addres
        public string City { get; set; }
        public string? District { get; set; }
        public string? AddressLine { get; set; }
        public string? PostalCode { get; set; }
    }
}
