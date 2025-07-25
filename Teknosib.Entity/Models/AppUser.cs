using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Entity.Models.Enums;

namespace Teknosib.Entity.Models
{
    public class AppUser :BaseEntitiy
    {
        public Guid AppUserId { get; set; }
        public Guid LegalEntityId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string? ProfileImageUrl { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public bool IsProfileCompleted { get; set; } = false;
        public RoleTypes Role { get; set; }


        //Navigation
        public virtual LegalEntity LegalEntity { get; set; }
        public  virtual ICollection <Review> ReviewWritten { get; set; }
        public  virtual ICollection<Review> ReviewsRecevid { get; set; }

    }

}
