using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Teknosib.Entity.Models
{
    public class SolutionProvider
    {
        public Guid SolutionProviderId { get; set; }
        public Guid AppUserId { get; set; }

        public string FullName { get; set; }//Ad Soyad Firma ise unvanı veya Firma Adı
        public string ExpertiseAreas { get; set; }//Uzmanlık alanı veya hangi alanda çözüm sunduğu alan
        public int ExperienceYear { get; set; }//Deyneyim yılı
        public string? PortfolioUrl { get; set; }

        //Şirket ise
        public string? TaxNumber { get; set; }//Vergi Numarası
        public string? Address { get; set; }
        public string? WebSite { get; set; }//Link
        public string? Description { get; set; }

        

        public virtual AppUser AppUser { get; set; }
        public virtual ICollection<Project> Project { get; set; }
        public virtual ICollection<Proposal> Proposal { get; set; }



    }
}
