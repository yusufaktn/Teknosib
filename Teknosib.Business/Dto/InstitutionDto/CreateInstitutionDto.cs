using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Entity.Models.Enums;

namespace Teknosib.Business.Dto.InstitutionDto
{
    public class CreateInstitutionDto
    {
        public Guid AddressId { get; set; }
        public string InstitutionName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public InstitutionType Type { get; set; }
        public string? InstitutionCode { get; set; }
        public string? OfficialTitle { get; set; } 
        public string? AuthorityName { get; set; } 
        public string? AuthorityTitle { get; set; } 
    }
}
