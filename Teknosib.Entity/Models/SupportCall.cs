using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Teknosib.Entity.Models
{
    public class SupportCall:BaseEntitiy
    {
        public Guid SupportCallId { get; set; }
        public Guid PublisherLegalEntityId { get; set; }


        public string Title { get; set; } 
        public string Description { get; set; }
        public decimal SupportAmount { get; set; }
       
       
      
        public virtual LegalEntity PublisherLegalEntity { get; set; }
        

    }
}
