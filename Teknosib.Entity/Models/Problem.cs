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
        public Guid CompanyId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public ProblemStatus P_Status { get; set; } = ProblemStatus.Open;

        //Min-max bütçe
        public decimal? MinBudget { get; set; }
        public decimal? MaxBudget { get; set; }


        //Navigation
        public Category Category { get; set; }
        public Company Company { get; set; }
        public ICollection<Proposal> Proposal { get; set; }
        public Project? Project { get; set; }

    }
}
