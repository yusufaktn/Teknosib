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

        //Ortak Alanlar
        public string Email { get; set; }
        public string? ProfileImageUrl { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool IsProfileCompleted { get; set; } = false;
        public RoleTypes Role { get; set; }


       

        //Navigation
        public virtual Company? Company { get; set; }
        public  virtual IndividualProvider? IndividualProvider { get; set; }
        public  virtual BusinessProvider? BusinessProvider { get; set; }

        public  virtual ICollection <Review> ReviewWritten { get; set; }
        public  virtual ICollection<Review> ReviewsRecevid { get; set; }










    }

}
