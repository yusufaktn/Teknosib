using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknosib.Entity.Models
{
    public class Review:BaseEntitiy
    {
        public Guid ReviewId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public Guid ProjectId { get; set; }      
        public Guid ReviewerId { get; set; }//AppUserId
        public Guid RevieweeId { get; set; }//AppUserId

        public virtual AppUser Reviewee { get; set; }
        public virtual Project Project { get; set; }
        public virtual AppUser Reviewer { get; set; }


    }
}
