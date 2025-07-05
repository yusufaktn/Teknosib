using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Entity.Models.Enums;

namespace Teknosib.Business.Dto.AppUser
{
    public class RegisterIndividualDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? ProfileImageUrl { get; set; }
        public RoleTypes Role { get; set; }=RoleTypes.Individual;
    }
}
