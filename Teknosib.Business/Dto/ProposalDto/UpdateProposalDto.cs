using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Entity.Models.Enums;

namespace Teknosib.Business.Dto.ProposalDto
{
    public class UpdateProposalDto
    {
        public Guid ProviderLegalEntityId { get; set; }
        public Guid? AppliedSupportCallId { get; set; }

        public string OfferDetails { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; } = "TRY";
        public ProposalStatus ProposalStatus { get; set; } = ProposalStatus.Pending;
    }
}
