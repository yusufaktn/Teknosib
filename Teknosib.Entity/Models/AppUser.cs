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

        //Şahıs ise
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        //Şirket ise
        public string? CompanyName { get; set; }



        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? ProfileImageUrl { get; set; }
        public byte[] PasswordHash { get; set; }//Haslanmiş şifre
        public byte[] PasswordSalt { get; set; }
        public RoleTypes Role { get; set; }


        //Navigation
        public virtual Company? Company { get; set; }
        public  virtual SolutionProvider? SolutionProvider { get; set; }
        public  virtual ICollection <Review> ReviewWritten { get; set; }
        public  virtual ICollection<Review> ReviewsRecevid { get; set; }










    }

}
