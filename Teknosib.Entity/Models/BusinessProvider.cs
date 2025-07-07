using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknosib.Entity.Models
{
    public class BusinessProvider:SolutionProviderBase
    {
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }//Vergi No 10 haneli
        

        public string OfficialAddress { get; set; } // Vergi dairesine kayıtlı adres
        public string? PhysicalAddress { get; set; }// Fiziksel işletme adresi (farklıysa)

        public string? WebSite { get; set; }
        public int? TeamSize { get; set; }
        public string? PortfolioUrl { get; set; }


        
    }
}
