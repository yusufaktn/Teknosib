using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknosib.Entity.Models
{
    public class Company:BaseEntitiy
    {
        public Guid CompanyId { get; set; }
        public Guid AppUserId { get; set; }

        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }//Vergi Numarası
        public string Address { get; set; }
        public string? WebSite { get; set; }//Link
        public string? Description { get; set; }


        public virtual AppUser AppUser { get; set; }
        public virtual ICollection<Problem> Problem { get; set; }


    }
}
