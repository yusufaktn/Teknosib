using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Entity.Models.Enums;

namespace Teknosib.Entity.Models
{
    public class Institution:LegalEntity
    {
        
        public InstitutionType Type { get; set; }
        public string? InstitutionCode { get; set; } // Örneğin: YÖK Kodu, Belediye Kodu, Kurum Kodu
        public string? OfficialTitle { get; set; } // T.C. Çankaya Belediyesi gibi resmi ad
        public string? AuthorityName { get; set; } // Rektör / Başkan / Vali adı
        public string? AuthorityTitle { get; set; } // Unvan: Belediye Başkanı, Rektör, Vali vs.
        
    }
}
