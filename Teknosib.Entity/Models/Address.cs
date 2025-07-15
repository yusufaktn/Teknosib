using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknosib.Entity.Models
{
    public class Address:BaseEntitiy
    {
        public Guid AddressId { get; set; }
        public string Country { get; set; } = "Türkiye";
        public string City { get; set; }
        public string? District { get; set; }
        public string? AddressLine { get; set; }
        public string? PostalCode { get; set; }

    }
}
