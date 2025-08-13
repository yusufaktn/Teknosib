using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Entity.Models.Enums;

namespace Teknosib.Business.Dto.LegalEntityDto
{
    public class ApproveDto
    {
       public Guid Id { get; set; }
       public ApproveStatus ApproveStatus { get; set; }
    }
}
