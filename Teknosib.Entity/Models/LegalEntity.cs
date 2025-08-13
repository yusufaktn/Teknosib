using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Entity.Models.Enums;

namespace Teknosib.Entity.Models
{
    public abstract class LegalEntity:BaseEntitiy
    {
        public Guid Id { get; set; }
        public Guid AddressId { get; set; }

        public string Name { get; set; }     
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? WebSite { get; set; }
        public string? Logo { get; set; }
        public ApproveStatus AproveStatus { get; set; } = ApproveStatus.Gönderildi;


        public decimal AverageRating { get; set; } = 0;
        public int TotalReviews { get; set; } = 0;
        public int CompletedProjects { get; set; } = 0;


        // İlişkiler
        public virtual Address Address { get; set; }
        public virtual ICollection<AppUser> AppUsers { get; set; }
        public virtual ICollection<Problem> OwnedProblems { get; set; }
        public virtual ICollection<Proposal> SubmittedProposals { get; set; }
        public virtual ICollection<SupportCall> PublishedSupportCalls { get; set; }

        public virtual ICollection<Project> ClientProjects { get; set; }
        public virtual ICollection<Project> ProviderProjects { get; set; }
        public virtual ICollection<Project> FunderProjects { get; set; }

    }
}
