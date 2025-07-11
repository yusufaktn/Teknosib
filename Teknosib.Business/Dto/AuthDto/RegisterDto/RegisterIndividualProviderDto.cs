using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknosib.Business.Dto.AuthDto.RegisterDto
{
    public class RegisterIndividualProviderDto
    {
        // AppUser alanları
        public string Email { get; set; }
        public string Password { get; set; }

        // SolutionProviderBase (ortak) alanlar
        public string ExpertiseAreas { get; set; }
        public int ExperienceYear { get; set; }
        public string Phone { get; set; }

        // IndividualProvider özel alanlar
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TCKN { get; set; }
        public string Biography { get; set; }
        public string? Education { get; set; }
        public string? Certifications { get; set; }
        public string? PortfolioUrl { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? GitHubUrl { get; set; }
    }
}
