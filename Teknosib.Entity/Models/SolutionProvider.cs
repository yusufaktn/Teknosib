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
        public string FullName { get; set; }//Ad Soyad Firma ise unvanı
        public string ExpertiseAreas { get; set; }//Uzmanlık alanı veya hangi alanda çözüm sunduğu
        public int ExperienceYear { get; set; }//Deyneyim yılı
        public string? PortfolioUrl { get; set; }


        public AppUser AppUsers { get; set; }
        public ICollection<Proposal> Proposals { get; set; }



    }
}
