using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Teknosib.Entity.Models
{
    public class KosgebSupport:BaseEntitiy
    {
        public Guid KosgebSupportId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string OfficialUrl { get; set; }//Kosgeb Sayfa Link
        public string  MaxSupportAmount { get; set; }//Destek Üst Limti


        public virtual Project Project { get; set; }


    }
}
