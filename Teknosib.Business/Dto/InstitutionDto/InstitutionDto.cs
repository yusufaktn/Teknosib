using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Entity.Models.Enums;

namespace Teknosib.Business.Dto.InstitutionDto
{
    public class InstitutionDto
    {

        public Guid Id { get; set; }
        public Guid AddressId { get; set; }

        public string InstitutionName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? WebSite { get; set; }
        public string? Logo { get; set; }
        public decimal AverageRating { get; set; } = 0;
        public int TotalReviews { get; set; } = 0;
        public int CompletedProjects { get; set; } = 0;

        public InstitutionType Type { get; set; }
        public string? InstitutionCode { get; set; } // Örneğin: YÖK Kodu, Belediye Kodu, Kurum Kodu
        public string? OfficialTitle { get; set; } // T.C. Çankaya Belediyesi gibi resmi ad
        public string? AuthorityName { get; set; } // Rektör / Başkan / Vali adı
        public string? AuthorityTitle { get; set; }
    }
}
