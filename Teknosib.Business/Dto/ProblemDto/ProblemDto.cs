using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Entity.Models.Enums;

namespace Teknosib.Business.Dto.ProblemDto
{
    public class ProblemDto
    {
        public Guid ProblemId { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Guid OwnerLegalEntityId { get; set; }
        public string LegalEntityName { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public ProblemStatus P_Status { get; set; }
     
    }
}
