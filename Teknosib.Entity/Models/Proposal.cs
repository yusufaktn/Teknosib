using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Entity.Models.Enums;


namespace Teknosib.Entity.Models
{
    public class Proposal:BaseEntitiy
    {
        public Guid ProposalId { get; set; }
        public Guid ProblemId { get; set; }
        public Guid ProviderLegalEntityId { get; set; }
        public Guid? AppliedSupportCallId { get; set; }

        public string OfferDetails { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; } = "TRY";
        public ProposalStatus  ProposalStatus { get; set; } = ProposalStatus.Pending;       
        


        public virtual Problem Problem { get; set; }
        public  virtual LegalEntity ProviderLegalEntity { get; set; }
        public virtual SupportCall? AppliedSupportCall { get; set; }




    }
}
