using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Teknosib.Entity.Models
{
    public class SupportCall:BaseEntitiy
    {
        public string Title { get; set; } 
        public string Description { get; set; }
        public decimal SupportAmount { get; set; }

       
        public Guid? PublisherCompanyId { get; set; }
        public virtual Company? PublisherCompany { get; set; }

        public Guid? PublisherInstitutionId { get; set; }
        public virtual Institution? PublisherInstitution { get; set; }


        
        public virtual ICollection<Problem> Problems { get; set; }


    }
}
