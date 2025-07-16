using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknosib.Business.Dto.CompanyDto
{
    public class CompanyDto
    {
        public Guid Id { get; set; }
        public Guid AddressId { get; set; }

        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? WebSite { get; set; }
        public string? Logo { get; set; }
        public decimal AverageRating { get; set; } = 0;
        public int TotalReviews { get; set; } = 0;
        public int CompletedProjects { get; set; } = 0;

        //Company
        public string TaxNumber { get; set; }
        public string Industry { get; set; }
        public string? Description { get; set; }
        public int? EmployeeCount { get; set; }

        public string ExpertiseAreas { get; set; }
        public int ExperienceYear { get; set; }
        public string? ContentEmail { get; set; }
    }
}
