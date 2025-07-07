using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Teknosib.Entity.Models
{
    public abstract class SolutionProviderBase:BaseEntitiy
    {

        public Guid Id { get; set; }
       

        public string ExpertiseAreas { get; set; }//Uzmanlık alanı veya hangi alanda çözüm sunduğu alan
        public int ExperienceYear { get; set; }//Deyneyim yılı
        public string Phone { get; set; }
        public string  Email { get; set; }
        public decimal AverageRating { get; set; } = 0;
        public int TotalReviews { get; set; } = 0;
        public int CompletedProjects { get; set; } = 0;


        // Doğrulama Durumu
        public bool IsVerified { get; set; } // Admin eliyle doğrulandı mı?
        public DateTime? VerificationDate { get; set; }


        public virtual AppUser AppUser { get; set; }
        public virtual ICollection<Project> Project { get; set; }
        public virtual ICollection<Proposal> Proposal { get; set; }



        

    }
}
