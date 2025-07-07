using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknosib.Business.Dto.RegisterDto
{
    public class RegisterCompanyDto
    {
        public string Email { get; set; }
        public string Password { get; set; }

        
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
        public string Address { get; set; }
        public string? WebSite { get; set; }
        public string? Industry { get; set; }
        public string? Description { get; set; }
        public int? EmployeeCount { get; set; }
    }
}
