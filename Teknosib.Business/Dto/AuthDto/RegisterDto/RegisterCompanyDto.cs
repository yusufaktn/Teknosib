using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknosib.Business.Dto.AuthDto.RegisterDto
{
    public class RegisterCompanyDto
    {
        //LegalEntitiy orak alanlar
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        //Company özel alanlar
        public string TaxNumber { get; set; }
        public string Industry { get; set; }
        public string ExpertiseAreas { get; set; }
        public int ExperienceYear { get; set; }

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
