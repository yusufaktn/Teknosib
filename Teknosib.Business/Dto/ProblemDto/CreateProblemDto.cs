using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Entity.Models.Enums;

namespace Teknosib.Business.Dto.ProblemDto
{
    public class CreateProblemDto
    {
        public Guid CategoryId { get; set; }
        public Guid OwnerLegalEntityId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
  
    }
}
