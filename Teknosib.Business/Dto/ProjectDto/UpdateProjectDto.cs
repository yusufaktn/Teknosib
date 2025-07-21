using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Entity.Models.Enums;

namespace Teknosib.Business.Dto.ProjectDto
{
    public class UpdateProjectDto
    {        
        public Guid ClientId { get; set; }
        public Guid ProviderId { get; set; }
        public Guid? FunderId { get; set; }

        public string ProjectName { get; set; } = string.Empty;
        public string ProjectDescription { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ComplatedDate { get; set; }
        public ProjectStatus ProjectStatus { get; set; } = ProjectStatus.NoStarted;
        public decimal FinalBudget { get; set; }
    }
}
