using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknosib.Business.Dto.AuthDto.RegisterDto
{
    public class RegisterBusinessProviderDto
    {
        public string Email { get; set; }
        public string Password { get; set; }

        // SolutionProviderBase (ortak) alanlar
        public string ExpertiseAreas { get; set; }
        public int ExperienceYear { get; set; }
        public string Phone { get; set; }

        // BusinessProvider özel alanlar
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
        public string OfficialAddress { get; set; }
        public string? PhysicalAddress { get; set; }
        public string? WebSite { get; set; }
        public int? TeamSize { get; set; }
        public string? PortfolioUrl { get; set; }
    }
}
