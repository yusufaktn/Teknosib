using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknosib.Business.Dto.SupportCallDto
{
    public class CreateSupportCallDto
    {

        public Guid PublisherLegalEntityId { get; set; }


        public string Title { get; set; }
        public string Description { get; set; }
        public decimal SupportAmount { get; set; }
    }
}
