using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknosib.Business.Dto.AddressDto
{
    public class AddressDto
    {
        public Guid AddressId { get; set; }
        public string Country { get; set; } 
        public string City { get; set; }
        public string? District { get; set; }
        public string? AddressLine { get; set; }
        public string? PostalCode { get; set; }
    }
}
