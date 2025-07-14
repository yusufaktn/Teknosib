using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknosib.Entity.Models
{
    public class Company:LegalEntity
    {
        public Guid CompanyId { get; set; }
        public Guid AppUserId { get; set; }
  
        public string TaxNumber { get; set; }//Vergi Numarası
        public string Industry { get; set; }//Sektör
        public string? Description { get; set; }
        public int? EmployeeCount { get; set; }

        public string ExpertiseAreas { get; set; }//Uzmanlık alanı veya hangi alanda çözüm sunduğu alan
        public int ExperienceYear { get; set; }//Deyneyim yılı
        public string? ContentEmail { get; set; }
        



        public virtual AppUser AppUser { get; set; }
        public virtual ICollection<Problem> Problem { get; set; }


    }
}
