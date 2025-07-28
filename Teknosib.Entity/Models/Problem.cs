using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Entity.Models.Enums;


namespace Teknosib.Entity.Models
{
    public class Problem : BaseEntitiy
    {
        public Guid ProblemId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid OwnerLegalEntityId { get; set; }
        


        public string Title { get; set; }
        public string Description { get; set; }
        public ProblemStatus P_Status { get; set; } = ProblemStatus.Open;


        //Navigation   
        public virtual Category Category { get; set; }
        public virtual LegalEntity OwnerLegalEntity { get; set; }
        public virtual  Project Project { get; set; }
        public  virtual ICollection<Proposal> Proposal { get; set; }      

    }
}
