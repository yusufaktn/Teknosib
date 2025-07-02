using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Entity.Models.Enums;

namespace Teknosib.Entity.Models
{
    public class Project:BaseEntitiy
    {
        public Guid ProjectId { get; set; }
        public Guid ProblemId { get; set; }
        public Guid? KosgebSupportId { get; set; }
        public Guid SolutionProviderId { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string ProjectDescription { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? ComplatedDate { get; set; }
        public ProjectStatus ProjectStatus { get; set; } = ProjectStatus.NoStarted;




        public virtual Problem Problem { get; set; }
        public virtual SolutionProvider SolutionProvider { get; set; }
        public virtual KosgebSupport? KosgebSupport { get; set; }
        public virtual Review? Review { get; set; }




    }
}
