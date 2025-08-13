using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Entity.Models.Enums;

namespace Teknosib.Business.Dto.CompanyDto
{
    public class UpdateCompanyDto
    {
        //LegalEntitiy
        public Guid AddressId { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? WebSite { get; set; }
        public string? Logo { get; set; }
        public ApproveStatus ApproveStatus { get; set; }

        //Company
        public string TaxNumber { get; set; }
        public string? ContentEmail { get; set; }
        public string? Description { get; set; }
        public int? EmployeeCount { get; set; }
        public string Industry { get; set; }
        public string ExpertiseAreas { get; set; }
        public int ExperienceYear { get; set; }
    }
}
