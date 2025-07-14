using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Teknosib.Entity.Models
{
    public abstract class LegalEntity:BaseEntitiy
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? WebSite { get; set; }
        public string? Logo { get; set; }

        public decimal AverageRating { get; set; } = 0;
        public int TotalReviews { get; set; } = 0;
        public int CompletedProjects { get; set; } = 0;


        // İlişkiler
        public virtual ICollection<AppUser> AppUsers { get; set; }
        public virtual ICollection<Problem> OwnedProblems { get; set; }
        public virtual ICollection<Proposal> SubmittedProposals { get; set; }
        public virtual ICollection<SupportCall> PublishedSupportCalls { get; set; }
    }
}
