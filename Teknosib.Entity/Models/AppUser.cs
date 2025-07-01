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
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? ProfileImageUrl { get; set; }

        //Güvenlik
        public byte[] PasswordHash { get; set; }//Haslanmiş şifre
        public byte[] PasswordSalt { get; set; }


        public RoleTypes Role { get; set; }



        



    }

}
