using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknosib.Business.Dto.CompanyDto
{
    public class CreateCompanyDto
    {
        
        public Guid AddressId { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        //Company özel alanlar
        public string TaxNumber { get; set; }
        public string? ContentEmail { get; set; }
        public string Industry { get; set; }
        public string? Description { get; set; }
        public int? EmployeeCount { get; set; }
        public string ExpertiseAreas { get; set; }
        public int ExperienceYear { get; set; }

    }
}
