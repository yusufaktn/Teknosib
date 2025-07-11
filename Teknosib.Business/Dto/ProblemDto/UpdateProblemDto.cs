using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Entity.Models.Enums;

namespace Teknosib.Business.Dto.ProblemDto
{
    public class UpdateProblemDto
    {       
        public Guid CategoryId { get; set; }
       
        public string Title { get; set; }
        public string Description { get; set; }
        public ProblemStatus P_Status { get; set; } 

        //Min-max bütçe
        public decimal? MinBudget { get; set; }
        public decimal? MaxBudget { get; set; }
    }
}
